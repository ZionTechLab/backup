exports.up = async function(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();

  const users = await knex('mas_users').select('userId', 'userName');

  const companies = await knex('sec_companies')
    .where({ tenantId: tenant.tenantId })
    .select('companyId');

  const userMap = Object.fromEntries(users.map(u => [u.userName, u.userId]));
  const companyId = companies[0]?.companyId;

  if (!companyId) return;

  const rows = [];

  if (userMap['thilina']) {
    rows.push({ userId: userMap['thilina'], companyId, isDefault: true });
  }
  if (userMap['admin']) {
    rows.push({ userId: userMap['admin'],   companyId, isDefault: true });
  }
  if (userMap['user']) {
    rows.push({ userId: userMap['user'],    companyId, isDefault: true });
  }

  if (rows.length) await knex('sec_userCompanies').insert(rows);
};

exports.down = function(knex) {
  return knex('sec_userCompanies').del();
};
