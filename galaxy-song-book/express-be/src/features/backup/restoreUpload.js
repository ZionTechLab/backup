const multer = require('multer');
const path = require('path');
const fs = require('fs');

// Deliberately NOT under uploads/ — that directory is served publicly by
// the static /uploads route, and a backup zip contains raw tenant data.
const TMP_DIR = path.join(__dirname, '..', '..', '..', 'database', 'backup-restore-tmp');
if (!fs.existsSync(TMP_DIR)) fs.mkdirSync(TMP_DIR, { recursive: true });

const maxRestoreMb = parseInt(process.env.MAX_BACKUP_RESTORE_MB || '200', 10);

const storage = multer.diskStorage({
  destination: (req, file, cb) => cb(null, TMP_DIR),
  filename: (req, file, cb) => cb(null, `${Date.now()}-${Math.round(Math.random() * 1e9)}.zip`),
});

const uploadRestore = multer({
  storage,
  limits: { fileSize: maxRestoreMb * 1024 * 1024 },
  fileFilter: (req, file, cb) => {
    if (!file.originalname.toLowerCase().endsWith('.zip')) {
      return cb(new Error('Only .zip backup files are accepted'));
    }
    cb(null, true);
  },
});

// Preview tokens are just the uploaded filename (already random + unguessable).
// Anything older than this is swept on the next preview call.
const MAX_AGE_MS = 60 * 60 * 1000; // 1 hour

function sweepStale() {
  let entries;
  try { entries = fs.readdirSync(TMP_DIR); } catch { return; }
  const now = Date.now();
  for (const name of entries) {
    const full = path.join(TMP_DIR, name);
    try {
      const stat = fs.statSync(full);
      if (now - stat.mtimeMs > MAX_AGE_MS) fs.unlinkSync(full);
    } catch { /* best-effort */ }
  }
}

function tokenToPath(token) {
  // token is the bare filename multer generated — reject anything that
  // could escape TMP_DIR (path separators, traversal).
  if (!token || /[\\/]/.test(token) || token.includes('..')) return null;
  return path.join(TMP_DIR, token);
}

module.exports = { uploadRestore, TMP_DIR, sweepStale, tokenToPath };
