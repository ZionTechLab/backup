exports.up = async function(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  if (!tenant) return;

  const userCompanies = await knex('sec_userCompanies as uc')
    .join('mas_users as u', 'u.userId', 'uc.userId')
    .select('uc.id as userCompanyId', 'uc.companyId', 'u.userName');

  // Map demo users to seeded ref_roles ids (1 = Admin, 2 = User)
  const roleByUser = { thilina: 1, admin: 1, user: 2 };

  const rows = userCompanies
    .filter(r => roleByUser[r.userName])
    .map(r => ({
      tenantId: tenant.tenantId,
      companyId: r.companyId,
      userCompanyId: r.userCompanyId,
      roleID: roleByUser[r.userName],
    }));

  if (rows.length) await knex('mas_userRoles').insert(rows);
};

exports.down = function(knex) {
  return knex('mas_userRoles').del();
};
