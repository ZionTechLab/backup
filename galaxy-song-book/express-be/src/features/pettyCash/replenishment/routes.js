const express = require('express');
const router = express.Router();
const ctrl = require('./controller');
const { requirePermission } = require('../../../middleware/requirePermission');

router.get('/get-ui', ctrl.getUi);
router.get('/get-all', ctrl.getAll);
router.get('/get', ctrl.get);
router.post('/update', requirePermission('pc-replenishment-save'), ctrl.update);
router.post('/verify', requirePermission('pc-replenishment-save'), ctrl.verify);
router.post('/approve', requirePermission('pc-replenishment-save'), ctrl.approve);
router.post('/post', requirePermission('pc-replenishment-post'), ctrl.post);
router.post('/cancel', requirePermission('pc-replenishment-cancel'), ctrl.cancel);

module.exports = router;
