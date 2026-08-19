

exports.up = function(knex) {
  const data = [
    {tenantId:1,companyId:1, docType: 'INV', docname: 'Invoice',active:true  },
    {tenantId:1,companyId:1, docType: 'ADV', docname: 'Advance',active:true  },
    {tenantId:1,companyId:1, docType: 'PAY', docname: 'Payment',active:true  },
    {tenantId:1,companyId:1, docType: 'REC', docname: 'Receipt',active:true  },
    {tenantId:1,companyId:1, docType: 'ACT', docname: 'Activity Log',active:true  },
    {tenantId:1,companyId:1, docType: 'VCO', docname: 'Vehicle Confirmation',active:true },
  ];

  const mappedData = data.map(({ active, docname, ...item }) => ({
    ...item,
    isActive: active
  }));

  return knex('conf_docType').insert(mappedData);
};
exports.down = function(knex) {
    return knex('conf_docType').whereIn('docType', ['INV', 'REC', 'ACT','VCO']).del();
};
