exports.up = function(knex) {
  return knex('ref_category').insert([
    { tenantId:1,companyId:1, id: 1, categoryType: 2000, parentId: 0, value: 'General', isActive: 1},

    { tenantId:1,companyId:1, id: 1, categoryType: 2001,parentId: 1, value: 'Book 1', isActive: 1},
    { tenantId:1,companyId:1, id: 2, categoryType: 2001,parentId: 1, value: 'Book 2', isActive: 1},
    { tenantId:1,companyId:1, id: 3, categoryType: 2001,parentId: 1, value: 'Book 3', isActive: 1},

    { tenantId:1,companyId:1, id: 1, categoryType: 2002, parentId: 0, value: 'cat 1', isActive: 1},
    { tenantId:1,companyId:1, id: 2, categoryType: 2002, parentId: 0, value: 'cat 2', isActive: 1},

  ]);

};
exports.down = function(knex) {
      return knex('ref_category')
        .whereIn('categoryType', [2000,2001,2002])
        .del();
};
