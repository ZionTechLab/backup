// Collapse ref_roles into permission groups.
//
// Background: the old 3-tier chain was Permission Group → Role → User.
// A "Role" was just a named alias for a set of permission groups, adding a
// pointless indirection. This migration collapses it to 2 tiers:
// Permission Group → User.  mas_userRoles.roleID now stores a permGroupId.
//
// Steps:
//   1. Add unique (tenantId, permGroupId) on sec_permissionGroup (idempotent).
//   2. Build a mapping: old roleId → list of permGroupIds (via sec_rolePermissionGroup).
//      Roles with NO mapping default to the same tenant's "Full Access" permGroup
//      so users and menu grants are never orphaned.
//   3. Update sec_userMenu: remap roleId to the FIRST permGroupId in each role's
//      list.  Handle PK conflicts (when two old roles merge into the same
//      permGroup) by deleting duplicate rows before the update.
//   4. Expand mas_userRoles: LEFT JOIN to capture unmapped users too.
//   5. Drop old FK, replace rows, add new FK → sec_permissionGroup.
//   6. Drop sec_rolePermissionGroup and ref_roles.

exports.up = async function (knex) {
  // ── 1. Unique key for the new composite FK (idempotent) ─────────────
  try {
    await knex.schema.alterTable('sec_permissionGroup', function (t) {
      t.unique(['tenantId', 'permGroupId'], 'uq_sec_permissiongroup_tenant_permgroup');
    });
  } catch (e) {
    if (!e.message || !e.message.includes('Duplicate key name')) throw e;
  }

  // ── 2. Build roleId → [permGroupIds] mapping per tenant ─────────────
  const rpgRows = await knex('sec_rolePermissionGroup')
    .select('tenantId', 'roleId', 'permGroupId')
    .orderBy('permGroupId');

  // roleMap: key = "tenantId::roleId", value = [permGroupId, ...]
  const roleMap = {};
  for (const r of rpgRows) {
    const key = `${r.tenantId}::${r.roleId}`;
    if (!roleMap[key]) roleMap[key] = [];
    roleMap[key].push(r.permGroupId);
  }

  // Find each tenant's "Full Access" fallback permGroupId
  const tenants = await knex('sec_tenants').select('tenantId');
  const fallbackPg = {}; // tenantId → permGroupId
  for (const t of tenants) {
    const pg = await knex('sec_permissionGroup')
      .where({ tenantId: t.tenantId, permGroupName: 'Full Access' })
      .first('permGroupId');
    if (pg) fallbackPg[t.tenantId] = pg.permGroupId;
  }

  function getFirstPgId(tenantId, oldRoleId) {
    const key = `${tenantId}::${oldRoleId}`;
    if (roleMap[key] && roleMap[key].length) return roleMap[key][0];
    // Unmapped role → fall back to Full Access
    return fallbackPg[tenantId] || null;
  }

  // ── 3. Remap sec_userMenu.roleId → 1 (universal full-access) ─────
  // sec_userMenu is cross-tenant in practice (init() queries without tenant
  // filter). Map ALL old roleIds to 1, the equivalent of the old Admin role.
  // Remove duplicate (tenantId, companyId, id) rows that would collide.
  const dupes = await knex('sec_userMenu')
    .select('tenantId', 'companyId', 'id')
    .count('* as cnt')
    .where('roleId', '>=', 0)
    .groupBy('tenantId', 'companyId', 'id')
    .having(knex.raw('count(*) > 1'));

  for (const d of dupes) {
    // Keep the row with the smallest roleId, delete the rest
    const rows = await knex('sec_userMenu')
      .select('roleId')
      .where({ tenantId: d.tenantId, companyId: d.companyId, id: d.id })
      .where('roleId', '>=', 0)
      .orderBy('roleId');
    const [keep, ...remove] = rows;
    for (const r of remove) {
      await knex('sec_userMenu')
        .where({ tenantId: d.tenantId, companyId: d.companyId, id: d.id, roleId: r.roleId })
        .del();
    }
  }

  await knex('sec_userMenu').where('roleId', '>=', 0).update({ roleId: 1 });

  // ── 4. Expand mas_userRoles (LEFT JOIN to keep unmapped users) ──────
  // For mapped roles: expand into N rows (one per permGroupId).
  const expandedMapped = await knex('mas_userRoles as ur')
    .join('sec_rolePermissionGroup as rpg', function () {
      this.on('rpg.tenantId', 'ur.tenantId').andOn('rpg.roleId', 'ur.roleID');
    })
    .select(
      'ur.tenantId', 'ur.companyId', 'ur.userCompanyId',
      'rpg.permGroupId as roleID', 'ur.updatedBy', 'ur.updatedAt',
    );

  // For unmapped roles: use the fallback permGroupId.
  const allMappedRoleIds = new Set(Object.keys(roleMap).map(k => {
    const [tid, rid] = k.split('::');
    return `${tid}::${rid}`;
  }));

  const unmappedUsers = await knex('mas_userRoles as ur')
    .select('ur.tenantId', 'ur.companyId', 'ur.userCompanyId',
      'ur.roleID as oldRoleId', 'ur.updatedBy', 'ur.updatedAt');

  const expandedUnmapped = [];
  for (const u of unmappedUsers) {
    const key = `${u.tenantId}::${u.oldRoleId}`;
    if (allMappedRoleIds.has(key)) continue; // already covered by INNER JOIN
    const newPg = fallbackPg[u.tenantId];
    if (!newPg) continue; // skip if no fallback (shouldn't happen)
    expandedUnmapped.push({
      tenantId: u.tenantId,
      companyId: u.companyId,
      userCompanyId: u.userCompanyId,
      roleID: newPg,
      updatedBy: u.updatedBy,
      updatedAt: u.updatedAt,
    });
  }

  const expanded = [...expandedMapped, ...expandedUnmapped];

  // ── 5. Drop old FK, replace rows, add new FK ────────────────────────
  await knex.schema.alterTable('mas_userRoles', function (t) {
    t.dropForeign(['tenantId', 'roleID'], 'mas_userroles_tenantid_roleid_foreign');
  });

  await knex('mas_userRoles').del();

  if (expanded.length) {
    const chunkSize = 200;
    for (let i = 0; i < expanded.length; i += chunkSize) {
      await knex('mas_userRoles').insert(expanded.slice(i, i + chunkSize));
    }
  }

  await knex.schema.alterTable('mas_userRoles', function (t) {
    t.foreign(['tenantId', 'roleID'], 'fk_mas_userroles_permgroup')
      .references(['tenantId', 'permGroupId'])
      .inTable('sec_permissionGroup');
  });

  // ── 6. Drop old role tables ──────────────────────────────────────────
  await knex.schema.dropTableIfExists('sec_rolePermissionGroup');
  await knex.schema.dropTableIfExists('ref_roles');
};

exports.down = async function (knex) {
  // ── 1. Clear mas_userRoles before recreating FK ─────────────────────
  // roleID values are permGroupIds that won't exist in ref_roles.
  await knex('mas_userRoles').del();

  // ── 2. Recreate ref_roles ────────────────────────────────────────────
  await knex.schema.createTable('ref_roles', function (table) {
    table.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    table.uuid('groupId').notNullable().references('groupId').inTable('sec_groups');
    table.increments('index').primary();
    table.integer('id').unsigned();
    table.string('roleName').notNullable();
    table.string('roleCode', 40);
    table.boolean('isActive').notNullable();
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
    table.unique(['tenantId', 'id']);
  });

  // ── 3. Recreate sec_rolePermissionGroup ──────────────────────────────
  await knex.schema.createTable('sec_rolePermissionGroup', function (t) {
    t.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    t.integer('roleId').notNullable();
    t.integer('permGroupId').unsigned().notNullable().references('permGroupId').inTable('sec_permissionGroup');
    t.primary(['tenantId', 'roleId', 'permGroupId']);
    t.index(['tenantId', 'roleId']);
  });

  // ── 4. Drop new FK, add old FK (safe now that mas_userRoles is empty) ─
  await knex.schema.alterTable('mas_userRoles', function (t) {
    t.dropForeign(['tenantId', 'roleID'], 'fk_mas_userroles_permgroup');
    t.foreign(['tenantId', 'roleID'], 'mas_userroles_tenantid_roleid_foreign')
      .references(['tenantId', 'id'])
      .inTable('ref_roles');
  });

  // ── 5. Drop the unique key added in up() ─────────────────────────────
  await knex.schema.alterTable('sec_permissionGroup', function (t) {
    t.dropUnique(['tenantId', 'permGroupId'], 'uq_sec_permissiongroup_tenant_permgroup');
  });

  // ── 6. Revert sec_userMenu.roleId from permGroupId back to 1 (Admin) ─
  // This is a best-effort revert — original per-role menu grants cannot be
  // perfectly reconstructed.
  await knex('sec_userMenu').where('roleId', '>=', 0).update({ roleId: 1 });
};
