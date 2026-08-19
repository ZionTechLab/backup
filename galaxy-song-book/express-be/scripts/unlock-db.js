// Unlock SQLite database — clears WAL, runs checkpoint, optimizes.
const path = require("path");
const knex = require("knex");

const dbPath = process.argv[2] || path.resolve(__dirname, "../database/service_plus.db");

(async () => {
  const db = knex({
    client: "sqlite3",
    connection: { filename: dbPath },
    useNullAsDefault: true,
  });

  try {
    // Check current journal mode
    const [{ journal_mode: mode }] = await db.raw("PRAGMA journal_mode");
    console.log(`journal_mode: ${mode}`);

    if (mode === "wal") {
      // WAL → TRUNCATE forces checkpoint and switches to DELETE, cleaning .wal/.shm
      const [{ busy, log, checkpointed }] = await db.raw("PRAGMA wal_checkpoint(TRUNCATE)");
      console.log(`checkpoint: busy=${busy} log=${log} checkpointed=${checkpointed}`);
    } else {
      // Non-WAL — just run checkpoint
      const [{ busy, log, checkpointed }] = await db.raw("PRAGMA wal_checkpoint(PASSIVE)");
      console.log(`checkpoint: busy=${busy} log=${log} checkpointed=${checkpointed}`);
    }

    // Release unused space
    await db.raw("PRAGMA optimize");
    console.log("optimize: done");

    console.log(`\n${dbPath} — unlocked.`);
  } catch (err) {
    console.error("Error:", err.message);
    process.exit(1);
  } finally {
    await db.destroy();
  }
})();
