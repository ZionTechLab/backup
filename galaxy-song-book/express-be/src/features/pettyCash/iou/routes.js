const express = require('express');
const router = express.Router();
const ctrl = require('./controller');
const { requirePermission } = require('../../../middleware/requirePermission');

router.get('/get-ui', ctrl.getUi);
router.get('/get-all', ctrl.getAll);
router.get('/get-approved-requests', ctrl.getApprovedRequests);
router.get('/get', ctrl.get);
router.post('/update', requirePermission('pc-iou-save'), ctrl.update);
router.post('/certify', requirePermission('pc-iou-certify'), ctrl.certify);
router.post('/approve', requirePermission('pc-iou-approve'), ctrl.approve);
router.post('/act', requirePermission('pc-iou-approve', 'pc-iou-certify'), ctrl.act);
router.post('/pay', requirePermission('pc-iou-pay'), ctrl.pay);
router.post('/cancel', requirePermission('pc-iou-cancel'), ctrl.cancel);
router.post('/add-audit', ctrl.addAudit);

module.exports = router;
