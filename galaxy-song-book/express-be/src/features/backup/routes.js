const express = require('express');
const router = express.Router();
const ctrl = require('./controller');
const { requirePermission } = require('../../middleware/requirePermission');
const { withMulterErrors } = require('../../middleware/upload');
// Restore uses its own private, non-public-served storage (restoreUpload.js),
// never the shared uploads/ middleware, since a backup zip contains raw
// tenant data and uploads/ is served publicly.
const { uploadRestore } = require('./restoreUpload');

router.get('/modules', requirePermission('backup-export', 'backup-export-full'), ctrl.getModules);
router.post('/export', requirePermission('backup-export', 'backup-export-full'), ctrl.export);

router.post(
  '/restore/preview',
  requirePermission('backup-restore', 'backup-restore-full'),
  withMulterErrors(uploadRestore.single('file')),
  ctrl.previewRestore
);
router.post('/restore/apply', requirePermission('backup-restore', 'backup-restore-full'), ctrl.applyRestore);

module.exports = router;
