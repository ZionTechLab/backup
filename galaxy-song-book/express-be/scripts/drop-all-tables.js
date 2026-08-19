/**
 * Drop ALL tables in galaxy_DB.
 * Usage:  node scripts/drop-all-tables.js
 *
 * Reads DB credentials from .env or app.yaml via dotenv.
 * Safe — prompts for confirmation before dropping.
 */
require('dotenv').config();
const mysql = require('mysql2/promise');

const DB_NAME = process.env.DB_NAME || 'galaxy_DB';

async function run() {
  const connection = await mysql.createConnection({
    host: process.env.DB_HOST || '127.0.0.1',
    port: parseInt(process.env.DB_PORT || '3306', 10),
    user: process.env.DB_USER || 'root',
    password: process.env.DB_PASSWORD || '',
    database: DB_NAME,
    multipleStatements: true,
  });

  try {
    // Disable FK checks so we can drop in any order
    await connection.query('SET FOREIGN_KEY_CHECKS = 0');

    const [rows] = await connection.query(
      `SELECT TABLE_NAME FROM information_schema.TABLES
       WHERE TABLE_SCHEMA = ? AND TABLE_TYPE = 'BASE TABLE'`,
      [DB_NAME]
    );

    if (rows.length === 0) {
      console.log(`ℹ No tables found in ${DB_NAME}. Nothing to drop.`);
      return;
    }

    console.log(`⚠ About to drop ${rows.length} table(s) in "${DB_NAME}":`);
    rows.forEach(r => console.log(`  - ${r.TABLE_NAME}`));

    // Confirm via env var or ask interactively
    const autoConfirm = process.env.FORCE_DROP === 'true';
    if (!autoConfirm) {
      const readline = require('readline').createInterface({
        input: process.stdin,
        output: process.stdout,
      });
      const answer = await new Promise(resolve => {
        readline.question('\nType "yes" to confirm: ', ans => {
          readline.close();
          resolve(ans.trim());
        });
      });
      if (answer !== 'yes') {
        console.log('Cancelled.');
        return;
      }
    }

    const tables = rows.map(r => `\`${r.TABLE_NAME}\``).join(', ');
    await connection.query(`DROP TABLE IF EXISTS ${tables}`);
    await connection.query('SET FOREIGN_KEY_CHECKS = 1');

    console.log(`✓ Dropped all ${rows.length} table(s) in ${DB_NAME}.`);
  } finally {
    await connection.end();
  }
}

run().catch(err => {
  console.error('✗', err.message);
  process.exit(1);
});
