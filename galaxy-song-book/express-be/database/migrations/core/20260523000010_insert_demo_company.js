exports.up = async function(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const group  = await knex('sec_groups').where({ tenantId: tenant.tenantId, groupName: 'Headquarters' }).first();

  await knex('sec_companies').insert({
    tenantId:            tenant.tenantId,
    groupId:             group.groupId,
    companyCode:       'DEMO',
    companyName:         'Demo Company',
    legalName:           'Demo Legal Name',
    registrationNumber:  'REG-001',
    addressLine1:        '456 Company Lane',
    addressLine2:        'Building 2',
    city:                'Company City',
    stateProvince:       'Company State',
    postalCode:          '67890',
    country:             '23',
    phoneNumber:         '9876543210',
    // tel2 removed
    // mobile removed
    // description removed
    email:               'contact@democompany.com',
    baseCurrencyCode:    'USD',
    isActive:            true,
  });
};

exports.down = async function(knex) {
  await knex('sec_companies').where({ companyName: 'Demo Company' }).del();
};
