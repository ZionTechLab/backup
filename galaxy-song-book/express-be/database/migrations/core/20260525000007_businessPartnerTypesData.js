exports.up = async function(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const partners = await knex('mas_businessPartner')
    .where({ tenantId: tenant.tenantId })
    .select('businessPartnerId', 'partnerCode');

  const byCode = Object.fromEntries(partners.map(p => [p.partnerCode, p.businessPartnerId]));
  const typeByCode = { A1: 'C', B2: 'S', EMP3: 'E', EMP4: 'D', EMP5: 'H' };

  const rows = Object.entries(typeByCode)
    .filter(([code]) => byCode[code])
    .map(([code, partnerType]) => ({
      tenantId: tenant.tenantId,
      businessPartnerId: byCode[code],
      partnerType,
    }));

  if (rows.length) await knex('mas_businessPartnerTypes').insert(rows);
};

exports.down = async function(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const ids = await knex('mas_businessPartner').where({ tenantId: tenant.tenantId }).pluck('businessPartnerId');
  return knex('mas_businessPartnerTypes').whereIn('businessPartnerId', ids).del();
};
