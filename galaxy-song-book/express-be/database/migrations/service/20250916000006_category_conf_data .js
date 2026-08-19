exports.up = function(knex) {
  return knex('conf_category').insert([
    { tenantId:1,companyId:1,categoryType: 1, parentCategoryType: 0, categoryTypeName: 'job Type', serialNo: 0,metaValue:'Job Type',metaDesc:'Description',isActive:true,menuParentId:160,icon:'',order:10},
    { tenantId:1,companyId:1,categoryType: 2, parentCategoryType: 0, categoryTypeName: 'Job Priority', serialNo: 0,metaValue:'Job Priority',metaDesc:'Description',isActive:true,menuParentId:160,icon:'',order:20},
    { tenantId:1,companyId:1,categoryType: 3, parentCategoryType: 0, categoryTypeName: 'Job Tags', serialNo: 0,metaValue:'Job Tags',metaDesc:'Description',isActive:true,menuParentId:160,icon:'',order:30},
    { tenantId:1,companyId:1,categoryType: 4, parentCategoryType: 0, categoryTypeName: 'Job Status', serialNo: 0,metaValue:'Job Status',metaDesc:'Description',isActive:true,menuParentId:160,icon:'',order:30},
  ]);

};
exports.down = function(knex) {
      return knex('conf_category')
        .whereIn('categoryType', [1, 2, 3])
        .del();
};


