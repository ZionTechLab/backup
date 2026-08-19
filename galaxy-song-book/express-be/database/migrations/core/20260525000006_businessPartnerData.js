const { randomUUID } = require('crypto');

exports.up = async function(knex) {
  const tenant  = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const company = await knex('sec_companies').where({ tenantId: tenant.tenantId, companyName: 'Demo Company' }).first();

  const partners = [
    { partnerCode: 'A1',   partnerName: 'TechNova',       contactPerson: 'Alice Fernando', email: 'alice@technova.lk',   address: 'No. 22, Colombo Rd, Kandy', phone1: '(071) 555-1122', phone2: '0112233445', isActive: true  },
    { partnerCode: 'B2',   partnerName: 'Lanka Supplies', contactPerson: 'Bandara Silva',  email: 'bandara@lankasup.lk', address: 'Industrial Zone, Galle',    phone1: '(075) 223-4433', phone2: '0112244556', isActive: true  },
    { partnerCode: 'EMP3', partnerName: 'Nuwan Perera',   contactPerson: 'Nuwan',          email: 'nuwan@company.lk',    address: '123 Main St, Negombo',      phone1: '(070) 456-7890', phone2: '0114567890', isActive: false },
    { partnerCode: 'EMP4', partnerName: 'Dilshan',        contactPerson: 'Dilshan',        email: 'dilshan@company.lk',  address: '123 Main St, Negombo',      phone1: '(070) 456-7890', phone2: '0114567890', isActive: false },
    { partnerCode: 'EMP5', partnerName: 'Kumara',         contactPerson: 'Kumara',         email: 'kumara@company.lk',   address: '123 Main St, Negombo',      phone1: '(070) 456-7890', phone2: '0114567890', isActive: false },
  ];

  const rows = partners.map(p => ({ businessPartnerId: randomUUID(), tenantId: tenant.tenantId, ...p }));
  await knex('mas_businessPartner').insert(rows);

  await knex('mas_businessPartnerCompany').insert(
    rows.map(r => ({ businessPartnerId: r.businessPartnerId, companyId: company.companyId, isDefault: true }))
  );
};

exports.down = async function(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  const ids = await knex('mas_businessPartner').where({ tenantId: tenant.tenantId }).pluck('businessPartnerId');
  await knex('mas_businessPartnerCompany').whereIn('businessPartnerId', ids).del();
  await knex('mas_businessPartner').where({ tenantId: tenant.tenantId }).del();
};
