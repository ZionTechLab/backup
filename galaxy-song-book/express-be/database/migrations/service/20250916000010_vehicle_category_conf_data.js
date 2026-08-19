exports.up = function(knex) {
  return knex('conf_category').insert([
    { tenantId:1,companyId:1,categoryType: 10, parentCategoryType: 0, categoryTypeName: 'Make', serialNo: 0,metaValue:'Make',metaDesc:'Description',isActive:false,menuParentId:160,icon:'',order:10},
    { tenantId:1,companyId:1,categoryType: 20, parentCategoryType: 10, categoryTypeName: 'Model', serialNo: 0,metaValue:'Model',metaDesc:'Description',isActive:false,menuParentId:160,icon:'',order:20},
    { tenantId:1,companyId:1,categoryType: 30, parentCategoryType: 20, categoryTypeName: 'Grade', serialNo: 0,metaValue:'Grade',metaDesc:'Description',isActive:false,menuParentId:160,icon:'',order:30},
    { tenantId:1,companyId:1,categoryType: 40, parentCategoryType: 0, categoryTypeName: 'Fuel Type', serialNo: 0,metaValue:'Fuel Type',metaDesc:'Description',isActive:false,menuParentId:160,icon:'',order:40},
    { tenantId:1,companyId:1,categoryType: 50, parentCategoryType: 0, categoryTypeName: 'Transmission', serialNo: 0,metaValue:'Transmission',metaDesc:'Description',isActive:false,menuParentId:160,icon:'',order:50},
    { tenantId:1,companyId:1,categoryType: 60, parentCategoryType: 0, categoryTypeName: 'Colour', serialNo: 0,metaValue:'Colour',metaDesc:'Description',isActive:false,menuParentId:160,icon:'',order:60},
    { tenantId:1,companyId:1,categoryType: 70, parentCategoryType: 0, categoryTypeName: 'Machine Type', serialNo: 0,metaValue:'Vehicle / Machine Type',metaDesc:'Description',isActive:true,menuParentId:160,icon:'',order:70},
    { tenantId:1,companyId:1,categoryType: 80, parentCategoryType: 0, categoryTypeName: 'Vehicle', serialNo: 0,metaValue:'Vehicle No',metaDesc:'Description',isActive:true,menuParentId:170,icon:'',order:80},
  ]);

};
exports.down = function(knex) {
      return knex('conf_category')
        .whereIn('categoryType', [10, 20, 30, 40, 50, 60, 70, 80])
        .del();
};
