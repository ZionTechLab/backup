exports.up = function(knex) {
  return knex('ref_category').insert([
    { tenantId:1,companyId:1, id: 1, categoryType: 1, value: 'Service Job', isActive: 1},

    { tenantId:1,companyId:1, id: 1, categoryType: 2, value: 'Low', isActive: 1},
    { tenantId:1,companyId:1, id: 2, categoryType: 2, value: 'Medium', isActive: 1},
    { tenantId:1,companyId:1, id: 3, categoryType: 2, value: 'High', isActive: 1},
     
    { tenantId:1,companyId:1, id: 1, categoryType: 3, value: 'Charger', isActive: 1},
    { tenantId:1,companyId:1, id: 2, categoryType: 3, value: 'Battery', isActive: 1},
    { tenantId:1,companyId:1, id: 3, categoryType: 3, value: 'Power Cable', isActive: 1},
    { tenantId:1,companyId:1, id: 4, categoryType: 3, value: 'Bag', isActive: 1},
    { tenantId:1,companyId:1, id: 5, categoryType: 3, value: 'Mouse', isActive: 1},
    { tenantId:1,companyId:1, id: 6, categoryType: 3, value: 'Keyboard', isActive: 1},
    { tenantId:1,companyId:1, id: 7, categoryType: 3, value: 'Toner', isActive: 1},
    { tenantId:1,companyId:1, id: 8, categoryType: 3, value: 'Cartridge', isActive: 1},
    { tenantId:1,companyId:1, id: 9, categoryType: 3, value: 'Ribbon', isActive: 1},
    { tenantId:1,companyId:1, id: 10, categoryType: 3, value: 'USB Cable', isActive: 1},
    { tenantId:1,companyId:1, id: 11, categoryType: 3, value: 'Video Cable', isActive: 1},

    { tenantId:1,companyId:1, id: 1, categoryType: 4, value: 'New', isActive: 1},
    { tenantId:1,companyId:1, id: 2, categoryType: 4, value: 'In Progress', isActive: 1},
    { tenantId:1,companyId:1, id: 3, categoryType: 4, value: 'Completed', isActive: 1},
    { tenantId:1,companyId:1, id: 4, categoryType: 4, value: 'Cancelled', isActive: 1},
  ]);

};
exports.down = function(knex) {
      return knex('ref_category')
        // .whereIn('categoryType', [10, 20, 30, 40, 50, 60])
        .del();
};