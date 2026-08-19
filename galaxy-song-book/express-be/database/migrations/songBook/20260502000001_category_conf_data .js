exports.up = function(knex) {
  return knex('conf_category').insert([
    {
      tenantId: 1,
      companyId: 1,
      categoryType: 2000,
      parentCategoryType: 0,
      categoryTypeName: 'Book Category',
      serialNo: 0,
      metaValue: JSON.stringify({
        "name": "value",
        "type": "text",
        "className": "col-md-9 col-sm-6 col-12",
        "validation": {
          "message": "Book Category is required",
          "required": true
        },
        "placeholder": "Book Category",
        "initialValue": ""
      }),
      metaDesc: JSON.stringify({
        "name": "description",
        "type": "text",
        "className": "col-md-12 col-sm-6 col-12",
        "placeholder": "Description",
        "initialValue": ""
      }),
      isActive: true,
      menuParentId: 160,
      icon: '',
      order: 10
    },

    { tenantId:1,companyId:1,categoryType: 2001, parentCategoryType: 2000, categoryTypeName: 'Book', serialNo: 0,      metaValue: JSON.stringify({
        "name": "value",
        "type": "text",
        "className": "col-md-9 col-sm-6 col-12",
        "validation": {
          "message": "Book is required",
          "required": true
        },
        "placeholder": "Book",
        "initialValue": ""
      }),metaDesc:JSON.stringify({
        "name": "description",
        "type": "text",
        "className": "col-md-12 col-sm-6 col-12",
        "placeholder": "Description",
        "initialValue": ""
      }),isActive:true,menuParentId:160,icon:'',order:20},
      
    { tenantId:1,companyId:1,categoryType: 2002, parentCategoryType: 0, categoryTypeName: 'Song Category', serialNo: 0,metaValue:JSON.stringify({
        "name": "value",
        "type": "text",
        "className": "col-md-9 col-sm-6 col-12",
        "validation": {
          "message": "Song Category is required",
          "required": true
        },
        "placeholder": "Song Category",
        "initialValue": ""
      }),metaDesc:JSON.stringify({
        "name": "description",
        "type": "text",
        "className": "col-md-12 col-sm-6 col-12",
        "placeholder": "Description",
        "initialValue": ""
      }),isActive:true,menuParentId:160,icon:'',order:30},

  ]);

};
exports.down = function(knex) {
  return knex('conf_category')
    .whereIn('categoryType', [2000,2001,2002])
    .del();
};
