#!/usr/bin/env node
/**
 * Copies everything in express-be/uploads into the OCI bucket, keeping the
 * exact same filenames. DB rows that reference those names keep working after
 * you switch STORAGE_DRIVER to "oci".
 *
 *   node scripts/migrate-uploads-to-oci.js --dry-run   # list what would move
 *   node scripts/migrate-uploads-to-oci.js             # do it
 *
 * Local files are never deleted — this only copies. Objects already present in
 * the bucket are skipped, so re-running is safe.
 */
require('dotenv').config();

const fs = require('fs');
const path = require('path');

// Always target OCI here, whatever .env currently says.
process.env.STORAGE_DRIVER = 'oci';
const storage = require('../src/services/storage');

const dryRun = process.argv.includes('--dry-run');
const uploadsDir = path.resolve(__dirname, '..', 'uploads');

// Minimal extension -> content-type map so images serve with the right header.
const TYPES = {
  '.jpg': 'image/jpeg', '.jpeg': 'image/jpeg', '.png': 'image/png',
  '.gif': 'image/gif', '.webp': 'image/webp', '.svg': 'image/svg+xml',
  '.pdf': 'application/pdf', '.txt': 'text/plain', '.md': 'text/markdown',
  '.csv': 'text/csv', '.json': 'application/json', '.zip': 'application/zip',
};

const human = (n) => (n < 1024 ? `${n} B`
  : n < 1024 ** 2 ? `${(n / 1024).toFixed(1)} KB`
  : `${(n / 1024 ** 2).toFixed(1)} MB`);

(async () => {
  if (!fs.existsSync(uploadsDir)) {
    console.log(`Nothing to do — ${uploadsDir} does not exist.`);
    return;
  }

  const files = fs.readdirSync(uploadsDir)
    .filter((f) => fs.statSync(path.join(uploadsDir, f)).isFile());

  if (!files.length) {
    console.log('Nothing to do — uploads/ is empty.');
    return;
  }

  console.log(`\n${dryRun ? 'DRY RUN — ' : ''}migrating ${files.length} file(s) -> bucket ${process.env.OCI_BUCKET_NAME}\n`);

  let copied = 0; let skipped = 0; let failed = 0; let bytes = 0;

  for (const name of files) {
    const full = path.join(uploadsDir, name);
    const size = fs.statSync(full).size;
    const label = `${name} (${human(size)})`;

    try {
      if (await storage.exists(name)) {
        console.log(`  skip    ${label} — already in bucket`);
        skipped++;
        continue;
      }

      if (dryRun) {
        console.log(`  would   ${label}`);
        copied++; bytes += size;
        continue;
      }

      await storage.save({
        buffer: fs.readFileSync(full),
        filename: name,
        originalname: name,
        mimetype: TYPES[path.extname(name).toLowerCase()] || 'application/octet-stream',
      });

      console.log(`  copied  ${label}`);
      copied++; bytes += size;
    } catch (err) {
      console.log(`  FAILED  ${label} — ${err.message}`);
      failed++;
    }
  }

  console.log(`\n  ${dryRun ? 'would copy' : 'copied'}: ${copied}   skipped: ${skipped}   failed: ${failed}   total: ${human(bytes)}`);
  if (!dryRun && copied && !failed) {
    console.log('\n  Done. Local files were left in place — delete them once you have confirmed');
    console.log('  the app serves images correctly with STORAGE_DRIVER=oci.\n');
  }
  if (failed) process.exit(1);
})().catch((err) => {
  console.error('\nMigration failed:', err.message);
  if (/SDK not installed/i.test(err.message)) console.error('Run: npm install');
  if (/credentials/i.test(err.message)) console.error('Run: oci setup config');
  console.error('');
  process.exit(1);
});
