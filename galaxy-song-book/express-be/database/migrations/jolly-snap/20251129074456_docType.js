

exports.up = function (knex) {
  // Deletes ALL existing entries

  // Inserts seed entries
  return knex('conf_docType').insert([
    { tenantId: 1, companyId: 1, docType: 'js',  isActive: true },

  ]);

};
exports.down = function (knex) {
  return knex('conf_docType').whereIn('docType', ['js']).del();
};
