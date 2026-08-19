const express = require('express');
const router = express.Router();
const controller = require('./controller');
const { requirePermission } = require('../../middleware/requirePermission');

// Approval level config (admin).
router.get('/config/options', requirePermission('wf-config-view'), (req, res, next) => controller.getOptions(req, res, next));
router.get('/config/get-all', requirePermission('wf-config-view'), (req, res, next) => controller.getAll(req, res, next));
router.get('/config/get', requirePermission('wf-config-view'), (req, res, next) => controller.get(req, res, next));
router.post('/config/save', requirePermission('wf-config-save'), (req, res, next) => controller.save(req, res, next));
router.post('/config/delete', requirePermission('wf-config-delete'), (req, res, next) => controller.delete(req, res, next));

// My Approvals inbox and a document's flow.
router.get('/inbox', requirePermission('approvals-view'), (req, res, next) => controller.getInbox(req, res, next));
router.get('/doc', requirePermission('approvals-view'), (req, res, next) => controller.getDoc(req, res, next));

module.exports = router;
