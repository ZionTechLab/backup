


exports.up = function(knex) {
  const data = [
     { tenantId:1,companyId:1,docType: 'EMP', txnType: 'EMP', txnTypename: 'Employee', serialNo: 0,active:true,isReport:true },
  ];

  const mappedData = data.map(({ active, txnTypename, ...item }) => ({
    ...item,
    isActive: active
  }));

  return knex('conf_txnType').insert(mappedData);
};
exports.down = function(knex) {
   return knex('conf_txnType').whereIn('docType', ['EMP']).del();
};
