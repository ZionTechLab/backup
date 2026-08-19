exports.up = function(knex) {
  return knex('sec_userMenu').insert([
    { tenantId:1,companyId:1,id: 10, roleId: 4 },
    { tenantId:1,companyId:1,id: 200, roleId: 4 },
    {tenantId:1,companyId:1,id: 160, roleId: 4},

   {tenantId:1,companyId:1,id: 2100, roleId: 4,isCategory:true},
   {tenantId:1,companyId:1,id: 2101, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2102, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2103, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2104, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2105, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2106, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2107, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2108, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2109, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2110, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2111, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2112, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2113, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2114, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2115, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2116, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2117, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2118, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2119, roleId: 4,isCategory:true},
  {tenantId:1,companyId:1,id: 2120, roleId: 4,isCategory:true},

]);

};
exports.down = function(knex) {
      return knex('sec_userMenu')
        .where('roleId',4)
        .del();
};


