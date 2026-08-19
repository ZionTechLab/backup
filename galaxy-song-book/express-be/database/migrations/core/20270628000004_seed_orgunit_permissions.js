// Adds the Organization module and org-unit-* permissions to the catalog.
// Grants all four codes to every tenant's Full Access group so Admin keeps working.
// Idempotent by permCode.

exports.up = async function (knex) {
  // Module
  const moduleRow = await knex('sec_module').where({ moduleCode: 'ORGANIZATION' }).first();
  let moduleId;
  if (!moduleRow) {
    const maxSort = await knex('sec_module').max('sortOrder as mx').first();
    await knex('sec_module').insert({ moduleCode: 'ORGANIZATION', moduleName: 'Organization', sortOrder: (maxSort?.mx ?? 0) + 10 });
    const created = await knex('sec_module').where({ moduleCode: 'ORGANIZATION' }).first();
    moduleId = created.moduleId;
  } else {
    moduleId = moduleRow.moduleId;
  }

  // Permissions
  const perms = [
    { code: 'org-unit-view',   name: 'Organization Unit - View' },
    { code: 'org-unit-new',    name: 'Organization Unit - New' },
    { code: 'org-unit-save',   name: 'Organization Unit - Save' },
    { code: 'org-unit-delete', name: 'Organization Unit - Delete' },
  ];

  const maxPermSort = await knex('sec_permission').max('sortOrder as mx').first();
  let permSort = (maxPermSort?.mx ?? 0) + 1;

  for (const p of perms) {
    const existing = await knex('sec_permission').where({ permCode: p.code }).first();
    if (!existing) {
      await knex('sec_permission').insert({
        permCode: p.code,
        permName: p.name,
        moduleId,
        sortOrder: permSort,
      });
      permSort += 1;
    }
  }

  const newPerms = await knex('sec_permission')
    .whereIn('permCode', perms.map((p) => p.code))
    .select('permId', 'permCode');

  // Add new perms to every tenant's Full Access group
  const tenants = await knex('sec_tenants').select('tenantId');
  for (const t of tenants) {
    const group = await knex('sec_permissionGroup')
      .where({ tenantId: t.tenantId, permGroupName: 'Full Access' }).first();
    if (!group) continue;

    for (const p of newPerms) {
      const exists = await knex('sec_permissionGroupDetail')
        .where({ permGroupId: group.permGroupId, permId: p.permId })
        .first();
      if (!exists) {
        await knex('sec_permissionGroupDetail').insert({
          permGroupId: group.permGroupId,
          permId: p.permId,
        });
      }
    }
  }
};

exports.down = async function (knex) {
  const perms = await knex('sec_permission')
    .whereIn('permCode', ['org-unit-view', 'org-unit-new', 'org-unit-save', 'org-unit-delete'])
    .select('permId');
  const permIds = perms.map((p) => p.permId);
  if (permIds.length) {
    await knex('sec_permissionGroupDetail').whereIn('permId', permIds).del();
    await knex('sec_permission').whereIn('permId', permIds).del();
  }
  // Do not delete the module; other features may use it later.
};
