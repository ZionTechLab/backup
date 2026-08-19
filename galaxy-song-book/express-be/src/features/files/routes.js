const express = require('express');
const router = express.Router();
const { upload, withMulterErrors } = require('../../middleware/upload');
const storage = require('../../services/storage');

// Central file upload. Any feature posts here and stores the returned filename.
// Read back via GET /api/upload?name=<filename> or /api/uploads/<filename>.
//
// The response shape is unchanged whichever STORAGE_DRIVER is active, so
// callers never need to know whether the bytes sit on disk or in OCI.

// Single file under field "file" -> { filename }
router.post('/upload', withMulterErrors(upload.single('file')), async (req, res, next) => {
  if (!req.file) return res.status(400).json({ error: 'No file uploaded' });
  try {
    const filename = await storage.save(req.file);
    res.json({ filename });
  } catch (err) {
    next(err);
  }
});

// Many files under field "files" -> { filenames: [...] }
router.post('/upload-many', withMulterErrors(upload.array('files')), async (req, res, next) => {
  try {
    const filenames = await Promise.all((req.files || []).map((f) => storage.save(f)));
    res.json({ filenames });
  } catch (err) {
    next(err);
  }
});

// Delete an object -> { deleted: true }
router.delete('/:name', async (req, res, next) => {
  try {
    await storage.remove(req.params.name);
    res.json({ deleted: true });
  } catch (err) {
    if (err.status === 400) return res.status(400).json({ error: err.message });
    next(err);
  }
});

module.exports = router;
