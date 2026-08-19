


exports.up = function(knex) {
  const data = [
     { tenantId:1,companyId:1,docType: 'INV', txnType: 'NT', txnTypename: 'Invoice', serialNo: 0,active:true,isReport:true },
     { tenantId:1,companyId:1,docType: 'INV', txnType: 'TAX', txnTypename: 'Tax Invoice', serialNo: 0,active:true,isReport:true },
     { tenantId:1,companyId:1,docType: 'ADV', txnType: 'ADV', txnTypename: 'Advance', serialNo: 0,active:true,isReport:true },
     { tenantId:1,companyId:1,docType: 'PAY', txnType: 'PAY', txnTypename: 'Payment', serialNo: 0,active:true,isReport:true },
     { tenantId:1,companyId:1,docType: 'ACT', txnType: 'ACT', txnTypename: 'Activity Log', serialNo: 0 ,active:true,isReport:true },
     { tenantId:1,companyId:1,docType: 'VCO', txnType: 'VCO', txnTypename: 'Vehicle Confirmation', serialNo: 0 ,active:true,isReport:true },
  ];

  const mappedData = data.map(({ active, txnTypename, ...item }) => ({
    ...item,
    isActive: active
  }));

  return knex('conf_txnType').insert(mappedData);
};
exports.down = function(knex) {
   return knex('conf_txnType').whereIn('docType', ['INV', 'REC', 'ACT','VCO']).del();
};
