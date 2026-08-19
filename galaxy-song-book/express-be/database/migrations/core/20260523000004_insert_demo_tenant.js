/**
 * @param {import('knex')} knex
 */
exports.up = async function(knex) {
  await knex('sec_tenants').insert({
    tenantName: 'demo',
    legalName: 'Demo Legal Name',
    status: 'active',
    email: 'demo@example.com',
    phone: '1234567890',
    addressLine1: '123 Demo Street',
    addressLine2: 'Suite 100',
    city: 'Demo City',
    stateProvince: 'Demo State',
    postalCode: '12345',
    country: 'Demo Country'
  });
};

/**
 * @param {import('knex')} knex
 */
exports.down = async function(knex) {
  await knex('sec_tenants').where({ tenantName: 'demo' }).del();
};
