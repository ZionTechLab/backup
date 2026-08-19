exports.up = function(knex) {
  return knex('sec_userMenu').insert([
    { tenantId:1,companyId:1,id: 10, roleId: 1 },
    {tenantId:1,companyId:1,id: 20, roleId: 1},
    {tenantId:1,companyId:1,id: 30, roleId: 1},
    {tenantId:1,companyId:1,id: 40, roleId: 1},
    {tenantId:1,companyId:1,id: 50, roleId: 1},
    {tenantId:1,companyId:1,id: 60, roleId: 1},
    {tenantId:1,companyId:1,id: 70, roleId: 1},
    {tenantId:1,companyId:1,id: 80, roleId: 1},
    // {tenantId:1,companyId:1,id: 130, roleId: 1},
    // {tenantId:1,companyId:1,id: 140, roleId: 1},
    // {tenantId:1,companyId:1,id: 150, roleId: 1},
    // {tenantId:1,companyId:1,id: 160, roleId: 1},

   { tenantId:1,companyId:1,id: 10, roleId: -1 },
    {tenantId:1,companyId:1,id: 20, roleId: -1},
    {tenantId:1,companyId:1,id: 30, roleId: -1},
    {tenantId:1,companyId:1,id: 40, roleId: -1},
    {tenantId:1,companyId:1,id: 50, roleId: -1},
    {tenantId:1,companyId:1,id: 60, roleId: -1},
    {tenantId:1,companyId:1,id: 70, roleId: -1},
    {tenantId:1,companyId:1,id: 80, roleId: -1},
    {tenantId:1,companyId:1,id: 90, roleId: -1},
    {tenantId:1,companyId:1,id: 100, roleId: -1},
    {tenantId:1,companyId:1,id: 110, roleId: -1},
    {tenantId:1,companyId:1,id: 120, roleId: -1},
    // {tenantId:1,companyId:1,id: 130, roleId: -1},
    // {tenantId:1,companyId:1,id: 140, roleId: -1},
    // {tenantId:1,companyId:1,id: 150, roleId: -1},
    // {tenantId:1,companyId:1,id: 160, roleId: -1},

]);

};
exports.down = function(knex) {
      return knex('sec_userMenu')
        .del();
};


