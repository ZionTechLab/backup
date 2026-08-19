const express = require('express');
const router = express.Router();
const controller = require('./controller');
const { requirePermission } = require('../../../middleware/requirePermission');

router.get('/get-ui', (req, res, next) => controller.getUi(req, res, next));
router.get('/get-all', (req, res, next) => controller.getAll(req, res, next));
router.get('/get', (req, res, next) => controller.get(req, res, next));
router.post('/update', requirePermission('pc-cash-book-save'), (req, res, next) => controller.update(req, res, next));
router.post('/delete', requirePermission('pc-cash-book-delete'), (req, res, next) => controller.delete(req, res, next));
router.post('/establish-float', requirePermission('pc-cash-book-save'), (req, res, next) => controller.establishFloat(req, res, next));
router.post('/reverse-float', requirePermission('pc-cash-book-save'), (req, res, next) => controller.reverseFloat(req, res, next));

module.exports = router;
