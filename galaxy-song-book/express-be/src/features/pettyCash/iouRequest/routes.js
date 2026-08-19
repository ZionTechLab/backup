const express = require('express');
const router = express.Router();
const ctrl = require('./controller');
const { requirePermission } = require('../../../middleware/requirePermission');

router.get('/get-ui', ctrl.getUi);
router.get('/get-all', ctrl.getAll);
router.get('/get', ctrl.get);
router.get('/get-approved', ctrl.getApproved);
router.post('/update', requirePermission('iou-request-save'), ctrl.update);
router.post('/act', requirePermission('iou-request-certify', 'iou-request-approve'), ctrl.act);
router.post('/close', requirePermission('iou-request-close'), ctrl.close);
router.post('/cancel', requirePermission('iou-request-delete'), ctrl.cancel);

module.exports = router;
