const db = require("../../database");
const { getEffectivePermissions } = require("../../repository/permissions");
const { parseSettings, mergeWithDefaults } = require("../tenant/settingsDefaults");

const RefCategoryRepo = {
  async init(filters = {}) {

    
    const meta = await db('conf_category')
      .select('categoryType', 'categoryTypeName')
      .where('isActive', 1);

    const userCompanies = await db('sec_userCompanies as uc')
      .join('sec_companies as c', 'c.companyId', 'uc.companyId')
      .leftJoin('gl_companies as gc', 'gc.companyId', 'c.companyId')
      .leftJoin('gl_financialMonths as fm', function () {
        this.on('fm.companyId', 'gc.companyId')
          .andOn('fm.fnYear', 'gc.currentFinYear')
          .andOn('fm.fnMonth', 'gc.currentFinMonth');
      })
      .select(
        'c.tenantId', 'c.groupId', 'c.companyId', 'c.companyName', 'uc.isDefault',
        'gc.financialYearStartMonth', 'gc.currentFinYear', 'gc.currentFinMonth',
        'fm.startDate as currentFinStartDate', 'fm.endDate as currentFinEndDate'
      )
      .where('uc.userId', filters.userID);

    const userGroups = await db('sec_userCompanies as uc')
      .join('sec_companies as c', 'c.companyId', 'uc.companyId')
      .join('sec_groups as g', 'g.groupId', 'c.groupId')
      .select('g.groupId', 'g.groupName')
      .where('uc.userId', filters.userID)
      .distinct();

    const userTenants = await db('sec_userTenants as ut')
      .join('sec_tenants as t', 't.tenantId', 'ut.tenantId')
      .select('t.tenantId', 't.tenantName', 'ut.isDefault')
      .where('ut.userId', filters.userID);

    // Collect ALL roleIds (now permGroupIds) for this user across all companies.
    const userRoles = await db('mas_userRoles as ur')
      .join('sec_userCompanies as uc', 'uc.id', 'ur.userCompanyId')
      .select('ur.roleID')
      .where('uc.userId', filters.userID);

    const roleIds = userRoles.map(r => r.roleID).filter(Boolean);

    let menuItems1 = [];
    if (roleIds.length) {
      // category menu items
      const catItems = await db('sec_userMenu as um')
        .join('conf_category as c', function() {
          this.on('c.tenantId', '=', 'um.tenantId')
            .andOn('c.companyId', '=', 'um.companyId')
            .andOn('c.categoryType', '=', 'um.Id');
        })
        .select(
          'c.categoryType as id',
          db.raw('160 as parentId'),
          db.raw(`CONCAT('/refferance/', LOWER(REPLACE(c.categoryTypeName, ' ', '-'))) as route`),
          'c.categoryTypeName as displayName',
          db.raw("'' as icon")
        )
        .whereIn('um.roleId', [...roleIds, -1])
        .where('um.iscategory', 1);

      // non-category menu items  
      const menuItems = await db('sec_userMenu as um')
        .join('sec_menu as m', function() {
          this.on('m.tenantId', '=', 'um.tenantId')
            .andOn('m.companyId', '=', 'um.companyId')
            .andOn('m.id', '=', 'um.Id');
        })
        .select('m.id', 'm.parentId', 'm.route', 'm.displayName', 'm.icon', 'm.isGroup')
        .where('um.iscategory', 0)
        .where('m.isActive', 1)
        .whereIn('um.roleId', [...roleIds, -1])
        .orderBy('m.order');

      menuItems1 = [...catItems, ...menuItems];
    }

    // Effective permission codes for the UI gate. Aggregates across all of the
    // user's roles in their default company, plus direct grants. Uses the same
    // resolver as the backend route guard, so init and enforcement agree.
    const defaultCompany = await db('sec_userCompanies')
      .where({ userId: filters.userID })
      .orderBy('isDefault', 'desc')
      .first('companyId');
    const permissions = await getEffectivePermissions(filters.userID, {
      companyId: defaultCompany ? defaultCompany.companyId : null,
    });

    // Tenant-level settings (theme defaults, table/behavior flags) for the
    // user's default tenant. Falls back to the app's hardcoded defaults when
    // the tenant has no row yet.
    const defaultTenant = userTenants.find((t) => t.isDefault) || userTenants[0];
    let tenantSettings = mergeWithDefaults(null);
    if (defaultTenant) {
      const tenantRow = await db('sec_tenants').where({ tenantId: defaultTenant.tenantId }).first('settings');
      tenantSettings = mergeWithDefaults(parseSettings(tenantRow && tenantRow.settings));
    }

    return { meta, menuItems: menuItems1, userCompanies, userGroups, userTenants, permissions, tenantSettings };
  },
};

module.exports = RefCategoryRepo;