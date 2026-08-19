exports.up = function(knex) {
  return knex('sec_userMenu').insert([
    {tenantId:1,companyId:1,id: 2000, roleId: 1,isCategory:true},
    {tenantId:1,companyId:1,id: 2001, roleId: 1,isCategory:true},
    {tenantId:1,companyId:1,id: 2002, roleId: 1,isCategory:true},

    {tenantId:1,companyId:1,id: 2000, roleId: -1,isCategory:true},
    {tenantId:1,companyId:1,id: 2001, roleId: -1,isCategory:true},
    {tenantId:1,companyId:1,id: 2002, roleId: -1,isCategory:true},

]);

};
exports.down = function(knex) {
      return knex('sec_userMenu').whereIn('id', ['2000','2001','2002'])
        .del();
};


