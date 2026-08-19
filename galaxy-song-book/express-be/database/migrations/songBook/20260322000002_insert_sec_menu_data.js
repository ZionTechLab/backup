exports.up = function(knex) {
  return knex('sec_menu').insert([
    { tenantId:1,companyId:1,id: 2100, parentId: 0, route: '/song-book/all', displayName: 'Song Book', icon: 'bi bi-speedometer2',order:10,isActive:true},

]);

};
exports.down = function(knex) {
      // return knex('sec_menu')
      //   .del();
          return knex('sec_menu').whereIn('id', ['2100']).del();
};


