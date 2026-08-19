exports.up = function(knex) {
  return knex('sec_docType').insert([
    { docType: 'USR', docTypename: 'User',             isActive: true },
    { docType: 'BP',  docTypename: 'Business Partner', isActive: true },
  ]);
};

exports.down = function(knex) {
  return knex('sec_docType').whereIn('docType', ['USR', 'BP']).del();
};
