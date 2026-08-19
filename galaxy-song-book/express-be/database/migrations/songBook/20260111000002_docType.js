

exports.up = function (knex) {
  // Deletes ALL existing entries

  // Inserts seed entries
  return knex('conf_docType').insert([
    { tenantId: 1, companyId: 1, docType: 'SNG',  isActive: true },

  ]);

};
exports.down = function (knex) {
  return knex('conf_docType').whereIn('docType', ['SNG']).del();
};
