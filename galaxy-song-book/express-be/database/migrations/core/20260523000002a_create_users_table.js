exports.up = function(knex) {
  return knex.schema.createTable('mas_users', function(table) {
    table.uuid('userId').primary().defaultTo(knex.fn.uuid());
    table.string('userName').notNullable();
    table.string('password').notNullable();
    table.string('fullName').notNullable();
    table.string('email').notNullable();
    table.string('phone').notNullable();
    table.string('phone2').notNullable();
    table.boolean('isActive').notNullable().defaultTo(true);
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());
  });
};

exports.down = function(knex) {
  return knex.schema.dropTable('mas_users');
};
