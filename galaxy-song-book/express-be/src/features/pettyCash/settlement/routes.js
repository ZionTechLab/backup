const express = require('express');
const router = express.Router();
const ctrl = require('./controller');
const { requirePermission } = require('../../../middleware/requirePermission');

router.get('/get-ui', ctrl.getUi);
router.get('/get-all', ctrl.getAll);
router.get('/get', ctrl.get);
router.post('/update', requirePermission('pc-settlement-save'), ctrl.update);
router.post('/act', requirePermission('pc-settlement-approve'), ctrl.act);
router.post('/clear', requirePermission('pc-settlement-clear'), ctrl.clear);
router.post('/cancel', requirePermission('pc-settlement-cancel'), ctrl.cancel);

module.exports = router;
