const path = require('path');
const db = require('../../src/database');

// Build the core schema on the in-memory test DB by running the real core-stream
// migrations. These also seed demo data (tenants, companies, users, memberships),
// which the integration tests query rather than hardcode. The app and these
// helpers share the same knex singleton within a test file, so the app sees this
// schema. The pool is pinned to one connection so :memory: persists across queries.
async function migrateCore() {
  await db.migrate.latest({
    directory: path.resolve(__dirname, '../../database/migrations/core'),
    tableName: 'knex_migrations_core',
  });
}

module.exports = { db, migrateCore };
