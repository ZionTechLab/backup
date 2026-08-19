exports.up = function(knex) {
  return knex('sec_userMenu').insert([
    {tenantId:1,companyId:1,id: 2100, roleId: 1,isCategory:false},
    {tenantId:1,companyId:1,id: 2100, roleId: -1,isCategory:false},



]);

};
exports.down = function(knex) {
      return knex('sec_userMenu').whereIn('id', ['2100','2100'])
        .del();
};


