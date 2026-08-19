exports.up = function(knex) {
  return knex('sec_txnType').insert([
    { docType: 'USR', txnType: 'USR', txnTypename: 'User',             isActive: true },
    { docType: 'BP',  txnType: 'BP',  txnTypename: 'Business Partner', isActive: true },
  ]);
};

exports.down = function(knex) {
  return knex('sec_txnType').whereIn('txnType', ['USR', 'BP']).del();
};
