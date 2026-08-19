// The MR. K. BALAKUMAR tenant (30447eab-...) had zero sec_rolePermissionGroup
// rows at all — its Admin role wasn't linked to any permission group, so
// admin had no permissions whatsoever under this tenant for either company
// (PPE or PPS), even after the menu/tenantId fix. Separately, admin had no
// mas_userRoles row for the PPS company at all (only PPE), so PPS would have
// stayed permission-less even once the tenant-level link existed.
//
// Mirrors demo's own "Full Access = every permission" pattern
// (20270501000001_seed_permission_catalog.js): one group holding every
// sec_permission row, linked to the Admin role.

const TENANT_ID = '30447eab-a8c4-43c5-b370-23972a70cd17'; // MR. K. BALAKUMAR
const ADMIN_ROLE_ID = 1;
const ADMIN_USER_ID = 'f95cd6ff-7f81-11f1-9eaa-0200170168d9';
const PPS_USER_COMPANY_ID = 6; // sec_userCompanies.id for admin -> PPS

exports.up = async function (knex) {
  await knex.transaction(async (trx) => {
    let group = await trx('sec_permissionGroup')
      .where({ tenantId: TENANT_ID, permGroupName: 'Full Access' }).first();
    if (!group) {
      await trx('sec_permissionGroup').insert({ tenantId: TENANT_ID, permGroupName: 'Full Access' });
      group = await trx('sec_permissionGroup')
        .where({ tenantId: TENANT_ID, permGroupName: 'Full Access' }).first();
    }

    const allPerms = await trx('sec_permission').select('permId');
    await trx('sec_permissionGroupDetail').where({ permGroupId: group.permGroupId }).del();
    if (allPerms.length) {
      await trx('sec_permissionGroupDetail').insert(
        allPerms.map((p) => ({ permGroupId: group.permGroupId, permId: p.permId }))
      );
    }

    const link = await trx('sec_rolePermissionGroup')
      .where({ tenantId: TENANT_ID, roleId: ADMIN_ROLE_ID, permGroupId: group.permGroupId }).first();
    if (!link) {
      await trx('sec_rolePermissionGroup').insert({
        tenantId: TENANT_ID, roleId: ADMIN_ROLE_ID, permGroupId: group.permGroupId,
      });
    }

    const ppsRole = await trx('mas_userRoles').where({ userCompanyId: PPS_USER_COMPANY_ID }).first();
    if (!ppsRole) {
      const uc = await trx('sec_userCompanies').where({ id: PPS_USER_COMPANY_ID }).first();
      if (uc) {
        await trx('mas_userRoles').insert({
          tenantId: TENANT_ID, companyId: uc.companyId,
          userCompanyId: PPS_USER_COMPANY_ID, roleID: ADMIN_ROLE_ID,
          updatedBy: ADMIN_USER_ID, isDeleted: false,
        });
      }
    }
  });
};

exports.down = async function (knex) {
  await knex.transaction(async (trx) => {
    await trx('mas_userRoles').where({ userCompanyId: PPS_USER_COMPANY_ID, roleID: ADMIN_ROLE_ID }).del();

    const group = await trx('sec_permissionGroup')
      .where({ tenantId: TENANT_ID, permGroupName: 'Full Access' }).first();
    if (group) {
      await trx('sec_rolePermissionGroup')
        .where({ tenantId: TENANT_ID, roleId: ADMIN_ROLE_ID, permGroupId: group.permGroupId }).del();
      await trx('sec_permissionGroupDetail').where({ permGroupId: group.permGroupId }).del();
      await trx('sec_permissionGroup').where({ permGroupId: group.permGroupId }).del();
    }
  });
};
