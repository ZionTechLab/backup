const express = require('express');
const router = express.Router();
const ctrl = require('./controller');
const { requirePermission } = require('../../middleware/requirePermission');

router.get('/get-all', requirePermission('menu-manage'), ctrl.getAll);
router.post('/save', requirePermission('menu-manage'), ctrl.save);
router.post('/arrange', requirePermission('menu-manage'), ctrl.arrange);
router.post('/grants', requirePermission('menu-manage'), ctrl.setGrants);

module.exports = router;
