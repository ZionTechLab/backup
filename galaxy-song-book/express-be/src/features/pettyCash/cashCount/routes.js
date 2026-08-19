const express = require('express');
const router = express.Router();
const ctrl = require('./controller');
const { requirePermission } = require('../../../middleware/requirePermission');

router.get('/get-ui', ctrl.getUi);
router.get('/get-all', ctrl.getAll);
router.get('/get', ctrl.get);
router.post('/update', requirePermission('pc-cash-count-save'), ctrl.update);
router.post('/sign', requirePermission('pc-cash-count-save'), ctrl.sign);
router.post('/countersign', requirePermission('pc-cash-count-countersign'), ctrl.countersign);
router.post('/audit', ctrl.audit);
router.post('/cancel', requirePermission('pc-cash-count-cancel'), ctrl.cancel);

module.exports = router;
