// Seeds the global permission catalog (modules + permission codes) and, per
// tenant, a "Full Access" group holding every permission, linked to the Admin
// role. This keeps Admin fully enabled while the action-level layer comes online.
// Also backfills roleCode on the seeded roles. Idempotent by code.

const CATALOG = [
  { code: 'PETTY_CASH', name: 'Petty Cash', features: [
    { key: 'pc-cash-book',        label: 'Cash Book',         actions: ['view', 'view-detail', 'new', 'save', 'delete'] },
    { key: 'pc-voucher',          label: 'Payment Voucher',   actions: ['view', 'view-detail', 'new', 'save', 'pay', 'cancel'] },
    { key: 'pc-iou',              label: 'IOU',               actions: ['view', 'view-detail', 'new', 'save', 'certify', 'approve', 'pay', 'cancel'] },
    { key: 'pc-settlement',       label: 'IOU Settlement',    actions: ['view', 'view-detail', 'new', 'save', 'clear', 'cancel'] },
    { key: 'pc-replenishment',    label: 'Replenishment',     actions: ['view', 'view-detail', 'new', 'save', 'post', 'cancel'] },
    { key: 'pc-cash-count',       label: 'Cash Count',        actions: ['view', 'view-detail', 'new', 'save', 'countersign'] },
    { key: 'pc-expense-category', label: 'Petty Cash Category',  actions: ['view', 'view-detail', 'new', 'save', 'delete'] },
    { key: 'pc-param',            label: 'Parameters',        actions: ['view', 'view-detail', 'new', 'save', 'delete'] },
    { key: 'pc-approval-band',    label: 'Approval Bands',    actions: ['view', 'view-detail', 'new', 'save', 'delete'] },
  ]},
  { code: 'ACCOUNTING', name: 'Accounting', features: [
    { key: 'journal',         label: 'Journal Entries',    actions: ['view', 'new', 'save', 'post', 'delete'] },
    { key: 'ledger',          label: 'General Ledger',     actions: ['view', 'export'] },
    { key: 'coa',             label: 'Chart of Accounts',  actions: ['view', 'new', 'save', 'delete'] },
    { key: 'financial-month', label: 'Financial Month',    actions: ['view', 'close', 'open'] },
  ]},
  { code: 'REPORTS', name: 'Reports', features: [
    { key: 'report-trial-balance', label: 'Trial Balance', actions: ['view', 'export'] },
    { key: 'report-pnl',           label: 'P&L',           actions: ['view', 'export'] },
    { key: 'report-balance-sheet', label: 'Balance Sheet', actions: ['view', 'export'] },
  ]},
  { code: 'MASTERS', name: 'Masters', features: [
    { key: 'currency',         label: 'Currency',          actions: ['view', 'new', 'save', 'delete'] },
    { key: 'exchange-rate',    label: 'Exchange Rate',     actions: ['view', 'new', 'save', 'delete'] },
    { key: 'account-type',     label: 'Account Type',      actions: ['view', 'new', 'save', 'delete'] },
    { key: 'company',          label: 'Companies',         actions: ['view', 'new', 'save', 'delete'] },
    { key: 'tenant',           label: 'Tenants',           actions: ['view', 'new', 'save', 'delete'] },
    { key: 'group',            label: 'Groups',            actions: ['view', 'new', 'save', 'delete'] },
    { key: 'business-partner', label: 'Business Partners', actions: ['view', 'new', 'save', 'delete'] },
    { key: 'item',             label: 'Item Master',       actions: ['view', 'new', 'save', 'delete'] },
    { key: 'uom',              label: 'UOM Master',        actions: ['view', 'new', 'save', 'delete'] },
  ]},
  { code: 'SECURITY', name: 'User Management', features: [
    { key: 'user',             label: 'Users',             actions: ['view', 'view-detail', 'new', 'save', 'delete'] },
    { key: 'role',             label: 'Roles',             actions: ['view', 'view-detail', 'new', 'save', 'delete'] },
    { key: 'permission-group', label: 'Permission Groups', actions: ['view', 'view-detail', 'new', 'save', 'delete'] },
  ]},
  { code: 'AUDIT', name: 'Audit', features: [
    { key: 'audit-log', label: 'Audit Log', actions: ['view', 'export'] },
  ]},
];

const titleAction = (a) => a.split('-').map((w) => w.charAt(0).toUpperCase() + w.slice(1)).join(' ');

exports.up = async function (knex) {
  // Modules
  let moduleSort = 0;
  for (const m of CATALOG) {
    const existing = await knex('sec_module').where({ moduleCode: m.code }).first();
    if (!existing) {
      await knex('sec_module').insert({ moduleCode: m.code, moduleName: m.name, sortOrder: moduleSort });
    }
    moduleSort += 10;
  }
  const modules = await knex('sec_module').select('moduleId', 'moduleCode');
  const moduleId = Object.fromEntries(modules.map((r) => [r.moduleCode, r.moduleId]));

  // Permissions
  let permSort = 0;
  for (const m of CATALOG) {
    for (const f of m.features) {
      for (const a of f.actions) {
        const permCode = `${f.key}-${a}`;
        const existing = await knex('sec_permission').where({ permCode }).first();
        if (!existing) {
          await knex('sec_permission').insert({
            permCode,
            permName: `${f.label} - ${titleAction(a)}`,
            moduleId: moduleId[m.code],
            sortOrder: permSort,
          });
        }
        permSort += 1;
      }
    }
  }
  const allPerms = await knex('sec_permission').select('permId');

  // roleCode backfill
  const roleCodes = { Admin: 'ADMIN', User: 'USER', Guest: 'GUEST' };
  for (const [name, code] of Object.entries(roleCodes)) {
    await knex('ref_roles').where({ roleName: name }).whereNull('roleCode').update({ roleCode: code });
  }

  // Per tenant: a Full Access group with every permission, linked to Admin.
  const tenants = await knex('sec_tenants').select('tenantId');
  for (const t of tenants) {
    let group = await knex('sec_permissionGroup')
      .where({ tenantId: t.tenantId, permGroupName: 'Full Access' }).first();
    if (!group) {
      await knex('sec_permissionGroup').insert({ tenantId: t.tenantId, permGroupName: 'Full Access' });
      group = await knex('sec_permissionGroup')
        .where({ tenantId: t.tenantId, permGroupName: 'Full Access' }).first();
    }
    // Sync the group to hold every permission.
    await knex('sec_permissionGroupDetail').where({ permGroupId: group.permGroupId }).del();
    if (allPerms.length) {
      await knex('sec_permissionGroupDetail').insert(
        allPerms.map((p) => ({ permGroupId: group.permGroupId, permId: p.permId }))
      );
    }
    // Link the Admin role (per tenant) to the group.
    const admin = await knex('ref_roles').where({ tenantId: t.tenantId, roleName: 'Admin' }).first();
    if (admin) {
      const link = await knex('sec_rolePermissionGroup')
        .where({ tenantId: t.tenantId, roleId: admin.id, permGroupId: group.permGroupId }).first();
      if (!link) {
        await knex('sec_rolePermissionGroup')
          .insert({ tenantId: t.tenantId, roleId: admin.id, permGroupId: group.permGroupId });
      }
    }
  }
};

exports.down = async function (knex) {
  const groups = await knex('sec_permissionGroup').where({ permGroupName: 'Full Access' }).select('permGroupId');
  const ids = groups.map((g) => g.permGroupId);
  if (ids.length) {
    await knex('sec_rolePermissionGroup').whereIn('permGroupId', ids).del();
    await knex('sec_permissionGroupDetail').whereIn('permGroupId', ids).del();
    await knex('sec_permissionGroup').whereIn('permGroupId', ids).del();
  }
  await knex('sec_permission').del();
  await knex('sec_module').del();
};
