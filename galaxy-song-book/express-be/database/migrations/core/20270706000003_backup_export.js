// Backup Export feature:
// 1. conf_backupTable — registry of exportable tables. Not itself tenant
//    scoped (one shared catalog); each row says which module a table
//    belongs to and how to scope its rows to a tenant/company:
//      tenantCompany — has both tenantId and companyId columns
//      tenantOnly    — has tenantId only
//      company       — has companyId only (still one tenant's data)
//      child         — has neither; scoped by joining parentTable via
//                      parentKey (that column on this table references the
//                      parent table's primary key)
//    sortOrder keeps parents ahead of children in the exported manifest.
// 2. Permissions: backup-export (tenant/module scope) is grantable like any
//    other permission. backup-export-full (whole database, every tenant) is
//    seeded but deliberately NOT auto-granted to any group — it crosses
//    tenant boundaries and should only go to a platform-level admin, added
//    by hand via Permission Groups.
// 3. Menu item under Settings (route /settings/backup-export).

const REGISTRY = [
  // Petty Cash
  { moduleCode: 'PETTY_CASH', tableName: 'pc_mas_cashBook', scopeType: 'tenantCompany', sortOrder: 10 },
  { moduleCode: 'PETTY_CASH', tableName: 'pc_ref_expenseCategory', scopeType: 'tenantCompany', sortOrder: 11 },
  { moduleCode: 'PETTY_CASH', tableName: 'pc_ref_param', scopeType: 'tenantCompany', sortOrder: 12 },
  { moduleCode: 'PETTY_CASH', tableName: 'conf_pcApprovalBand', scopeType: 'tenantCompany', sortOrder: 13 },
  { moduleCode: 'PETTY_CASH', tableName: 'pc_txn_iouRequest', scopeType: 'tenantCompany', sortOrder: 20 },
  { moduleCode: 'PETTY_CASH', tableName: 'pc_txn_iouRequestDoc', scopeType: 'company', sortOrder: 21 },
  { moduleCode: 'PETTY_CASH', tableName: 'pc_txn_iou', scopeType: 'tenantCompany', sortOrder: 22 },
  { moduleCode: 'PETTY_CASH', tableName: 'pc_txn_iouDoc', scopeType: 'company', sortOrder: 23 },
  { moduleCode: 'PETTY_CASH', tableName: 'pc_log_iouAudit', scopeType: 'tenantCompany', sortOrder: 24 },
  { moduleCode: 'PETTY_CASH', tableName: 'pc_txn_voucher', scopeType: 'tenantCompany', sortOrder: 30 },
  { moduleCode: 'PETTY_CASH', tableName: 'pc_txn_voucherDetail', scopeType: 'company', sortOrder: 31 },
  { moduleCode: 'PETTY_CASH', tableName: 'pc_txn_iouSettlement', scopeType: 'tenantCompany', sortOrder: 40 },
  { moduleCode: 'PETTY_CASH', tableName: 'pc_txn_settlementDetail', scopeType: 'company', sortOrder: 41 },
  { moduleCode: 'PETTY_CASH', tableName: 'pc_txn_settlementAllocation', scopeType: 'child', parentTable: 'pc_txn_iouSettlement', parentKey: 'settlementId', sortOrder: 42 },
  { moduleCode: 'PETTY_CASH', tableName: 'pc_txn_replenishment', scopeType: 'tenantCompany', sortOrder: 50 },
  { moduleCode: 'PETTY_CASH', tableName: 'pc_txn_cashCount', scopeType: 'tenantCompany', sortOrder: 60 },
  { moduleCode: 'PETTY_CASH', tableName: 'pc_txn_cashCountDenom', scopeType: 'child', parentTable: 'pc_txn_cashCount', parentKey: 'cashCountId', sortOrder: 61 },

  // Accounting (GL)
  { moduleCode: 'ACCOUNTING', tableName: 'gl_chartOfAccounts', scopeType: 'tenantOnly', sortOrder: 10 },
  { moduleCode: 'ACCOUNTING', tableName: 'gl_financialMonths', scopeType: 'tenantCompany', sortOrder: 11 },
  { moduleCode: 'ACCOUNTING', tableName: 'gl_transactions', scopeType: 'tenantCompany', sortOrder: 20 },
  { moduleCode: 'ACCOUNTING', tableName: 'gl_transactionDetail', scopeType: 'tenantCompany', sortOrder: 21 },
  { moduleCode: 'ACCOUNTING', tableName: 'gl_accountBalances', scopeType: 'tenantCompany', sortOrder: 22 },

  // Masters
  { moduleCode: 'MASTERS', tableName: 'mas_businessPartner', scopeType: 'tenantOnly', sortOrder: 10 },
  { moduleCode: 'MASTERS', tableName: 'mas_businessPartnerCompany', scopeType: 'company', sortOrder: 11 },
  { moduleCode: 'MASTERS', tableName: 'mas_orgUnit', scopeType: 'tenantCompany', sortOrder: 12 },
];

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
  await knex.schema.createTable('conf_backupTable', (t) => {
    t.increments('id').primary();
    t.string('moduleCode', 30).notNullable();
    t.string('tableName', 100).notNullable().unique();
    t.string('scopeType', 20).notNullable(); // tenantCompany | tenantOnly | company | child
    t.string('parentTable', 100);
    t.string('parentKey', 100);
    t.integer('sortOrder').notNullable().defaultTo(0);
    t.boolean('isActive').notNullable().defaultTo(true);
    t.uuid('updatedBy').references('userId').inTable('mas_users');
    t.dateTime('updatedAt').defaultTo(knex.fn.now());
  });

  await knex('conf_backupTable').insert(REGISTRY.map((r) => ({
    moduleCode: r.moduleCode, tableName: r.tableName, scopeType: r.scopeType,
    parentTable: r.parentTable || null, parentKey: r.parentKey || null,
    sortOrder: r.sortOrder, isActive: true,
  })));

  // Permissions
  const module = await knex('sec_module').where({ moduleCode: 'SECURITY' }).first();
  if (module) {
    const mx = await knex('sec_permission').max('sortOrder as m').first();
    let nextSort = (mx?.m ?? 0) + 1;

    const exportPerm = await knex('sec_permission').where({ permCode: 'backup-export' }).first();
    if (!exportPerm) {
      await knex('sec_permission').insert({
        permCode: 'backup-export', permName: 'Backup - Export', moduleId: module.moduleId, sortOrder: nextSort++,
      });
    }
    const fullPerm = await knex('sec_permission').where({ permCode: 'backup-export-full' }).first();
    if (!fullPerm) {
      await knex('sec_permission').insert({
        permCode: 'backup-export-full', permName: 'Backup - Export Full Database', moduleId: module.moduleId, sortOrder: nextSort++,
      });
    }

    // backup-export (tenant/module scope) goes to each tenant's Full Access
    // group, same as other admin features. backup-export-full is left
    // ungranted — it crosses tenant boundaries and must be assigned by hand.
    const perm = await knex('sec_permission').where({ permCode: 'backup-export' }).first();
    const tenants = await knex('sec_tenants').select('tenantId');
    for (const t of tenants) {
      const group = await knex('sec_permissionGroup').where({ tenantId: t.tenantId, permGroupName: 'Full Access' }).first();
      if (!group) continue;
      const exists = await knex('sec_permissionGroupDetail').where({ permGroupId: group.permGroupId, permId: perm.permId }).first();
      if (!exists) await knex('sec_permissionGroupDetail').insert({ permGroupId: group.permGroupId, permId: perm.permId });
    }
  }

  // Menu item under Settings (340)
  const scope = await scopeFor(knex);
  if (scope) {
    const admin = await knex('mas_users').where({ userName: 'admin' }).first();
    const updatedBy = admin ? admin.userId : null;
    const now = new Date();

    const existing = await knex('sec_menu').where({ ...scope, route: '/settings/backup-export' }).first();
    if (!existing) {
      const mxId = await knex('sec_menu').max('id as m').first();
      const id = (mxId?.m ?? 0) + 1;
      const mxOrder = await knex('sec_menu').where({ ...scope, parentId: 340 }).max('order as m').first();

      await knex('sec_menu').insert({
        ...scope, id, parentId: 340, route: '/settings/backup-export', displayName: 'Backup Export',
        icon: 'bi bi-cloud-download', order: (mxOrder?.m ?? 0) + 1, isGroup: false, isActive: true,
        updatedBy, updatedAt: now,
      });
      await knex('sec_userMenu').insert({ ...scope, id, roleId: 1, isCategory: 0, updatedBy, updatedAt: now });
    }
  }
};

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (scope) {
    const row = await knex('sec_menu').where({ ...scope, route: '/settings/backup-export' }).first();
    if (row) {
      await knex('sec_userMenu').where({ ...scope, id: row.id }).del();
      await knex('sec_menu').where({ ...scope, id: row.id }).del();
    }
  }

  for (const code of ['backup-export', 'backup-export-full']) {
    const perm = await knex('sec_permission').where({ permCode: code }).first();
    if (perm) {
      await knex('sec_permissionGroupDetail').where({ permId: perm.permId }).del();
      await knex('sec_permission').where({ permId: perm.permId }).del();
    }
  }

  await knex.schema.dropTableIfExists('conf_backupTable');
};
