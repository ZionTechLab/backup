const knex = require('knex');
const knexConfig = require('../knexfile');

// SQLite in production (App Engine) lives in /tmp, which is wiped on every
// instance restart — so the schema has to be rebuilt from migrations on every boot.
const ENVS = ['production', 'dev_core', 'dev_service', 'dev_gl', 'dev_petycash', 'dev_song_book', 'dev_jolly_snap', 'dev_hrm'];

async function runMigrations(appLogger) {
  for (const env of ENVS) {
    const db = knex(knexConfig[env]);
    try {
      const [batch, list] = await db.migrate.latest();
      appLogger.info({ env, batch, migrations: list }, 'migrations applied');
    } finally {
      await db.destroy();
    }
  }
}

module.exports = runMigrations;
