


exports.up = function (knex) {
   // Deletes ALL existing entries

   // Inserts seed entries
   return knex('conf_txnType').insert([
      { tenantId: 1, companyId: 1, docType: 'js', txnType: 'js',  serialNo: 1000, isActive: true, isReport: true },

   ]);

};
exports.down = function (knex) {
   return knex('conf_txnType').whereIn('docType', ['js']).del();
};
