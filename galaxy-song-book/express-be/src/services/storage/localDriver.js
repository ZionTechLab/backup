const fs = require('fs');
const path = require('path');

// Local disk driver. This is the historical behaviour: files live in
// express-be/uploads and are read straight off disk.
const uploadsDir = path.resolve(__dirname, '..', '..', '..', 'uploads');

function ensureDir() {
  if (!fs.existsSync(uploadsDir)) fs.mkdirSync(uploadsDir, { recursive: true });
}

// Rejects anything that could escape the uploads directory.
function safeResolve(name) {
  if (!name || name.includes('..') || name.includes('/') || name.includes('\\')) {
    const err = new Error('Invalid file name');
    err.status = 400;
    throw err;
  }
  const resolved = path.resolve(path.join(uploadsDir, name));
  if (!resolved.startsWith(uploadsDir + path.sep) && resolved !== uploadsDir) {
    const err = new Error('Invalid file path');
    err.status = 400;
    throw err;
  }
  return resolved;
}

/**
 * Persist a buffer. Multer's diskStorage has usually already written the file,
 * in which case `file.filename` is set and there is nothing left to do.
 */
async function save(file) {
  ensureDir();
  if (file.filename && !file.buffer) return file.filename;

  const name = file.filename
    || `${Date.now()}-${Math.round(Math.random() * 1e6)}${path.extname(file.originalname || '')}`;
  await fs.promises.writeFile(safeResolve(name), file.buffer);
  return name;
}

/**
 * Read an object back.
 * Returns { stream, contentType, contentLength } or null when missing.
 */
async function get(name) {
  const resolved = safeResolve(name);
  if (!fs.existsSync(resolved)) return null;
  const stat = await fs.promises.stat(resolved);
  return {
    stream: fs.createReadStream(resolved),
    contentType: undefined, // let Express infer from the filename
    contentLength: stat.size,
    localPath: resolved,
  };
}

async function remove(name) {
  const resolved = safeResolve(name);
  if (fs.existsSync(resolved)) await fs.promises.unlink(resolved);
  return true;
}

async function exists(name) {
  return fs.existsSync(safeResolve(name));
}

module.exports = { save, get, remove, exists, uploadsDir, name: 'local' };
