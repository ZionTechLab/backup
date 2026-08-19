exports.up = function(knex) {
  return knex('conf_category').update({ parentCategoryType: 70 }).where({ categoryType: 80 });
};

exports.down = function(knex) {
  return null
  // knex('conf_category').update({ parentCategoryType: null }).where({ categoryType: 160 });
};



