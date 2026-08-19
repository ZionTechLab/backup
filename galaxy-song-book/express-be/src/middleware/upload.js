const multer = require('multer');
const path = require('path');
const storageService = require('../services/storage');

// Single shared upload config. All features use this instead of declaring their
// own multer instance. Size limit from MAX_UPLOAD_MB (default 10).
//
// Where the bytes end up depends on STORAGE_DRIVER:
//   local -> multer writes straight to uploads/ (unchanged behaviour)
//   oci   -> multer buffers in memory and the storage service uploads to
//            Object Storage, so nothing is written to local disk.
const maxUploadMb = parseInt(process.env.MAX_UPLOAD_MB || '10', 10);

const storage = storageService.useMemoryStorage
  ? multer.memoryStorage()
  : multer.diskStorage({
    destination: (req, file, cb) => cb(null, 'uploads/'),
    filename: (req, file, cb) => cb(null, `${Date.now()}-${Math.round(Math.random() * 1e6)}${path.extname(file.originalname)}`),
  });

const upload = multer({ storage, limits: { fileSize: maxUploadMb * 1024 * 1024 } });

// Wraps a multer middleware so upload errors return clean JSON.
function withMulterErrors(mw) {
  return (req, res, next) => mw(req, res, (err) => {
    if (!err) return next();
    if (err instanceof multer.MulterError) {
      if (err.code === 'LIMIT_FILE_SIZE') return res.status(413).json({ error: 'File too large', limitMB: maxUploadMb });
      return res.status(400).json({ error: err.message, code: err.code });
    }
    return res.status(400).json({ error: err.message || 'Upload error' });
  });
}

module.exports = { upload, withMulterErrors, maxUploadMb };
