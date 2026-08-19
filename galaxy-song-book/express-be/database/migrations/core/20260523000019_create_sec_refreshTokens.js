/**
 * Creates sec_refreshTokens table for managing refresh tokens.
 */

exports.up = function (knex) {
  return knex.schema.createTable('sec_refreshTokens', function (table) {
    table.increments('index').primary();
    table.uuid('userId').notNullable().references('userId').inTable('mas_users');
    table.string('tokenHash', 255).notNullable().unique().index();
    table.datetime('expiresAt').notNullable().index();
    table.boolean('revoked').notNullable().defaultTo(false).index();
    table.datetime('revokedAt');
    table.string('replacedByHash', 255);
    table.text('userAgent');
    table.string('ip', 64);
    table.uuid('updatedBy');
    table.dateTime('updatedAt').notNullable().defaultTo(knex.fn.now());

    // Optional FK if users table exists with id (not enforced for SQLite portability)
    // table.foreign('userId').references('sec_mas_users.userId');
  });
};

exports.down = function (knex) {
  return knex.schema.dropTableIfExists('sec_refreshTokens');
};
