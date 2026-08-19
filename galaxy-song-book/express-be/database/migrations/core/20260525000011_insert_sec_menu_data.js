exports.up = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();
  const base = { tenantId: tenant.tenantId, companyId: company.companyId };

  return knex('sec_menu').insert([
    { ...base, id: 10,  parentId: 0,   route: '/',                 displayName: 'Dashboard',         icon: 'bi bi-speedometer2', order: 10,  isActive: true },
    { ...base, id: 130, parentId: 0,   route: '/master',           displayName: 'Master Files',      icon: 'bi bi-gear',         order: 130, isActive: true, isGroup: true },
    { ...base, id: 140, parentId: 130, route: '/business-partner', displayName: 'Business Partners', icon: 'bi bi-people-fill',  order: 140, isActive: true },
    { ...base, id: 150, parentId: 130, route: '/user-master',      displayName: 'Users',             icon: 'bi bi-person-badge', order: 150, isActive: true },
    { ...base, id: 160, parentId: 0,   route: '/references',       displayName: 'References',        icon: 'bi bi-bookmarks',    order: 160, isActive: true, isGroup: true },
  ]);
};

exports.down = async function(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  return knex('sec_menu').where({ tenantId: tenant.tenantId }).whereIn('id', [10, 130, 140, 150, 160]).del();
};
