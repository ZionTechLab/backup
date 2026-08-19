

exports.up = function(knex) {
  const data = [
    {tenantId:1,companyId:1, docType: 'EMP', docname: 'Employee',active:true  },
  ];

  const mappedData = data.map(({ active, docname, ...item }) => ({
    ...item,
    isActive: active
  }));

  return knex('conf_docType').insert(mappedData);
};
exports.down = function(knex) {
    return knex('conf_docType').whereIn('docType', ['EMP']).del();
};
