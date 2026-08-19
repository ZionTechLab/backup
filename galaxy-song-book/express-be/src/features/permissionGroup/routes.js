const express = require('express');
const router = express.Router();
const controller = require('./controller');
const { requirePermission } = require('../../middleware/requirePermission');

router.get('/get-all', requirePermission('permission-group-view'), (req, res, next) => controller.getAll(req, res, next));
router.get('/get', requirePermission('permission-group-view-detail', 'permission-group-view'), (req, res, next) => controller.get(req, res, next));
router.post('/save', requirePermission('permission-group-save'), (req, res, next) => controller.save(req, res, next));
router.post('/delete', requirePermission('permission-group-delete'), (req, res, next) => controller.delete(req, res, next));

module.exports = router;
