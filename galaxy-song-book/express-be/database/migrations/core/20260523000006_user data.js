exports.up = function(knex) {
  return knex('mas_users').insert([
    { userName: 'thilina', password: '$argon2id$v=19$m=19456,t=2,p=1$e1+n7Oc2LXuqyFy5kA5ftw$fIggCdOHRUyLJpVhD1Ja9peOp3w8eLsBJpZq3xy59HY', fullName: 'Admin User',   email: 'admin@example.com', phone: '1234567890', phone2: '0987654321', isActive: true },
    { userName: 'admin',   password: '$argon2id$v=19$m=19456,t=2,p=1$JkziL350zdtGDN/ZL7IGNA$YodIAO4HJaXRozo+FmMZbj4MTiZIcZsCcbI4OsFONCM', fullName: 'Admin User',   email: 'admin@example.com', phone: '1234567890', phone2: '0987654321', isActive: true },
    { userName: 'user',    password: '$argon2id$v=19$m=19456,t=2,p=1$9sDtlX7+1JW0vYeBV93vRw$sN4FKe29RCtOcdlOw+LrA6cjVsGNKIx66EorrvLGyxo', fullName: 'Regular User', email: 'user@example.com',  phone: '1234567890', phone2: '0987654321', isActive: true },
  ]);
};

exports.down = function(knex) {
  return knex('mas_users').del();
};
