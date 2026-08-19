const express = require('express');
const router = express.Router();
const controller = require('./controller');
const { requirePermission } = require('../../middleware/requirePermission');

router.get('/get-companies', requirePermission('org-unit-view'), (req, res, next) => controller.getCompanies(req, res, next));
router.get('/get-all', requirePermission('org-unit-view'), (req, res, next) => controller.getAll(req, res, next));
router.get('/get-parents', requirePermission('org-unit-view'), (req, res, next) => controller.getParents(req, res, next));
router.get('/get', requirePermission('org-unit-view'), (req, res, next) => controller.get(req, res, next));
router.post('/save', requirePermission('org-unit-save'), (req, res, next) => controller.save(req, res, next));
router.post('/delete', requirePermission('org-unit-delete'), (req, res, next) => controller.del(req, res, next));

module.exports = router;
