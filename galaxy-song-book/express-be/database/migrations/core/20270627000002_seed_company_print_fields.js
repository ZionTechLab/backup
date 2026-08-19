exports.up = async function(knex) {
  await knex('sec_companies')
    .where({ companyName: 'Demo Company' })
    .update({
      description: 'Importers of Heavy Equipments, Hiring of Earth Moving Machineries & Transporters and Spare Parts Suppliers',
      tel2: '031 2278 365',
      mobile: '0777 712 213',
    });
};

exports.down = async function(knex) {
  await knex('sec_companies')
    .where({ companyName: 'Demo Company' })
    .update({
      description: null,
      tel2: null,
      mobile: null,
    });
};
