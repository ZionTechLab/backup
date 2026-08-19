exports.up = function(knex) {
  return knex('gl_accountTypes').insert([
    { accountType: 'A', typeName: 'Asset',     sortOrder: 1, isActive: true },
    { accountType: 'L', typeName: 'Liability', sortOrder: 2, isActive: true },
    { accountType: 'E', typeName: 'Equity',    sortOrder: 3, isActive: true },
    { accountType: 'I', typeName: 'Income',    sortOrder: 4, isActive: true },
    { accountType: 'X', typeName: 'Expense',   sortOrder: 5, isActive: true },
  ]);
};

exports.down = function(knex) {
  return knex('gl_accountTypes').whereIn('accountType', ['A', 'L', 'E', 'I', 'X']).del();
};
