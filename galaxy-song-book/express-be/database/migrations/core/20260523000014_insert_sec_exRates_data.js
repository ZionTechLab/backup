exports.up = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const group   = await knex('sec_groups').where({ tenantId: tenant.tenantId, groupName: 'Headquarters' }).first();
  const user    = await knex('mas_users').where({ userName: 'admin' }).first();
  const buying  = await knex('sec_exRateTypes').where({ tenantId: tenant.tenantId, typeName: 'Buying' }).first();
  const selling = await knex('sec_exRateTypes').where({ tenantId: tenant.tenantId, typeName: 'Selling' }).first();

  const base = {
    tenantId:  tenant.tenantId,
    groupId:   group.groupId,
    updatedBy: user.userId,
    effectiveDate: '2026-05-23',
  };

  return knex('sec_exRates').insert([
    { ...base, fromCurrencyCode: 'USD', toCurrencyCode: 'LKR', rateTypeId: buying.rateTypeId,  rate: 299.500000 },
    { ...base, fromCurrencyCode: 'USD', toCurrencyCode: 'LKR', rateTypeId: selling.rateTypeId, rate: 303.750000 },
    { ...base, fromCurrencyCode: 'EUR', toCurrencyCode: 'LKR', rateTypeId: buying.rateTypeId,  rate: 322.100000 },
    { ...base, fromCurrencyCode: 'EUR', toCurrencyCode: 'LKR', rateTypeId: selling.rateTypeId, rate: 327.400000 },
    { ...base, fromCurrencyCode: 'GBP', toCurrencyCode: 'LKR', rateTypeId: buying.rateTypeId,  rate: 376.200000 },
    { ...base, fromCurrencyCode: 'GBP', toCurrencyCode: 'LKR', rateTypeId: selling.rateTypeId, rate: 381.500000 },
    { ...base, fromCurrencyCode: 'INR', toCurrencyCode: 'LKR', rateTypeId: buying.rateTypeId,  rate:   3.580000 },
    { ...base, fromCurrencyCode: 'INR', toCurrencyCode: 'LKR', rateTypeId: selling.rateTypeId, rate:   3.620000 },
    { ...base, fromCurrencyCode: 'USD', toCurrencyCode: 'EUR', rateTypeId: buying.rateTypeId,  rate:   0.921000 },
    { ...base, fromCurrencyCode: 'USD', toCurrencyCode: 'EUR', rateTypeId: selling.rateTypeId, rate:   0.934000 },
  ]);
};

exports.down = async function(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  return knex('sec_exRates').where({ tenantId: tenant.tenantId }).del();
};
