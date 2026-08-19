// IOU Request enhancements: org unit scoping, currency, a separate requester,
// revised-amount tracking mirroring the IOU (PIOU) confirmedAmount/
// approvedAmount pattern, and a manual early-close state distinct from
// fully-issued (Settled).
//
// - branchOrgUnitId / departmentOrgUnitId / sectionOrgUnitId: mas_orgUnit
//   already supports these unitTypes; this seeds a placeholder hierarchy so
//   the dropdowns aren't empty.
// - currencyCode: the request had no currency before; the IOU (PIOU) does.
// - requesterUserId: the staff member requesting on behalf of the party.
//   Distinct from requestedByUserId (the submitter/audit field, set from the
//   logged-in user) and partyId (who receives the money).
// - confirmedAmount / approvedAmount: revised amounts at level 1 / level 2 of
//   approval. requestAmount (the original ask) is never overwritten.
// - status: rebuilt from a CHECK-constrained enum to free text so 'Closed'
//   can be added (an approver stopping further issuing early, distinct from
//   'Settled' which means the approved amount was fully issued).
// - iou-request-close permission: gates the new manual close action.

const crypto = require('crypto');

async function scopeFor(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  if (!tenant) return null;
  const company = await knex('sec_companies')
    .where({ tenantId: tenant.tenantId, companyName: 'Demo Company' })
    .first();
  if (!company) return null;
  return { tenantId: tenant.tenantId, companyId: company.companyId };
}

exports.up = async function (knex) {
  await knex.schema.alterTable('pc_txn_iouRequest', (t) => {
    t.uuid('branchOrgUnitId').references('orgUnitId').inTable('mas_orgUnit');
    t.uuid('departmentOrgUnitId').references('orgUnitId').inTable('mas_orgUnit');
    t.uuid('sectionOrgUnitId').references('orgUnitId').inTable('mas_orgUnit');
    t.specificType('currencyCode', 'CHAR(3)').references('currencyCode').inTable('sec_currencies');
    t.uuid('requesterUserId').references('userId').inTable('mas_users');
    t.decimal('confirmedAmount', 18, 2);
    t.decimal('approvedAmount', 18, 2);
  });

  // Rebuild status as free text so 'Closed' can be used. Same shuffle used
  // elsewhere in this stream for CHECK-constrained SQLite columns.
  await knex.schema.alterTable('pc_txn_iouRequest', (t) => {
    t.string('statusNew', 30).notNullable().defaultTo('Draft');
  });
  await knex('pc_txn_iouRequest').update({ statusNew: knex.raw('status') });
  await knex.schema.alterTable('pc_txn_iouRequest', (t) => {
    t.dropColumn('status');
  });
  await knex.schema.alterTable('pc_txn_iouRequest', (t) => {
    t.renameColumn('statusNew', 'status');
  });

  // Seed a placeholder org hierarchy so the new dropdowns aren't empty.
  const scope = await scopeFor(knex);
  if (scope) {
    const admin = await knex('mas_users').where({ userName: 'admin' }).first();
    const updatedBy = admin ? admin.userId : null;
    const now = new Date();

    const upsertUnit = async (unitType, code, name, parentId = null) => {
      const existing = await knex('mas_orgUnit')
        .where({ companyId: scope.companyId, unitType, code, deleted: false })
        .first();
      if (existing) return existing.orgUnitId;
      const orgUnitId = crypto.randomUUID();
      await knex('mas_orgUnit').insert({
        orgUnitId, tenantId: scope.tenantId, companyId: scope.companyId,
        unitType, code, name, parentId, isActive: true, deleted: false,
        updatedBy, updatedAt: now,
      });
      return orgUnitId;
    };

    const branchId = await upsertUnit('Branch', 'HO', 'Head Office');
    const financeId = await upsertUnit('Department', 'FIN', 'Finance', branchId);
    await upsertUnit('Department', 'OPS', 'Operations', branchId);
    await upsertUnit('Section', 'AP', 'Accounts Payable', financeId);
    await upsertUnit('Section', 'TRE', 'Treasury', financeId);
  }

  // New permission for the manual early-close action.
  const module = await knex('sec_module').where({ moduleCode: 'PETTY_CASH' }).first();
  if (module) {
    const code = 'iou-request-close';
    const existing = await knex('sec_permission').where({ permCode: code }).first();
    if (!existing) {
      const maxPermSort = await knex('sec_permission').max('sortOrder as mx').first();
      await knex('sec_permission').insert({
        permCode: code, permName: 'IOU Request - Close', moduleId: module.moduleId,
        sortOrder: (maxPermSort?.mx ?? 0) + 1,
      });
    }
    const perm = await knex('sec_permission').where({ permCode: code }).first();
    const tenants = await knex('sec_tenants').select('tenantId');
    for (const t of tenants) {
      const group = await knex('sec_permissionGroup').where({ tenantId: t.tenantId, permGroupName: 'Full Access' }).first();
      if (!group) continue;
      const exists = await knex('sec_permissionGroupDetail').where({ permGroupId: group.permGroupId, permId: perm.permId }).first();
      if (!exists) {
        await knex('sec_permissionGroupDetail').insert({ permGroupId: group.permGroupId, permId: perm.permId });
      }
    }
  }
};

exports.down = async function (knex) {
  const perm = await knex('sec_permission').where({ permCode: 'iou-request-close' }).first();
  if (perm) {
    await knex('sec_permissionGroupDetail').where({ permId: perm.permId }).del();
    await knex('sec_permission').where({ permId: perm.permId }).del();
  }

  // Drop FKs first so columns can be removed (MySQL requires this; SQLite
  // has no named constraints and rebuilds the table on dropColumn).
  if (knex.client.config.client === 'mysql') {
    await knex.raw('ALTER TABLE ?? DROP FOREIGN KEY IF EXISTS ??', ['pc_txn_iouRequest', 'pc_txn_iourequest_branchorgunitid_foreign']);
    await knex.raw('ALTER TABLE ?? DROP FOREIGN KEY IF EXISTS ??', ['pc_txn_iouRequest', 'pc_txn_iourequest_departmentorgunitid_foreign']);
    await knex.raw('ALTER TABLE ?? DROP FOREIGN KEY IF EXISTS ??', ['pc_txn_iouRequest', 'pc_txn_iourequest_sectionorgunitid_foreign']);
    await knex.raw('ALTER TABLE ?? DROP FOREIGN KEY IF EXISTS ??', ['pc_txn_iouRequest', 'pc_txn_iourequest_currencycode_foreign']);
    await knex.raw('ALTER TABLE ?? DROP FOREIGN KEY IF EXISTS ??', ['pc_txn_iouRequest', 'pc_txn_iourequest_requesteruserid_foreign']);
  }

  await knex.schema.alterTable('pc_txn_iouRequest', (t) => {
    t.dropColumn('branchOrgUnitId');
    t.dropColumn('departmentOrgUnitId');
    t.dropColumn('sectionOrgUnitId');
    t.dropColumn('currencyCode');
    t.dropColumn('requesterUserId');
    t.dropColumn('confirmedAmount');
    t.dropColumn('approvedAmount');
  });
  // status stays free text on rollback; restoring the CHECK would fail if any
  // row already holds 'Closed'.
};
