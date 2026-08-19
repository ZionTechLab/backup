exports.up = function(knex) {
  return knex('mas_users').insert([
    { userName: 'hrm', password: '$argon2id$v=19$m=19456,t=2,p=1$e1+n7Oc2LXuqyFy5kA5ftw$fIggCdOHRUyLJpVhD1Ja9peOp3w8eLsBJpZq3xy59HY', fullName: 'HRM User', email: 'admin@example.com', phone: '1234567890', phone2: '0987654321', isActive: true },
  ]);
};

exports.down = function(knex) {
  return knex('mas_users').where('userName', 'hrm').del();
};
