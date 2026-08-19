exports.up = function(knex) {
  const data = [
    { tenantId:1,companyId:1,id: 200, parentId: 0,route: '/employee', displayName: 'Employee Master', icon: 'bi bi-gear', order:200, active: true,isGroup:true },
  ];

  const mappedData = data.map(({ active, ...item }) => ({
    ...item,
    isActive: active
  }));

  return knex('sec_menu').insert(mappedData).onConflict('id').ignore();
};
exports.down = function(knex) {
      return knex('sec_menu')
      .where('tenantId',1)
      .where('companyId',1)
      .where('id',200)
        .del();
};


