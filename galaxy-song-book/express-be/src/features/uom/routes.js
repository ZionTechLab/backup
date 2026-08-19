const express = require('express');
const router = express.Router();
const controller = require('./controller');

router.get('/get-all', (req, res, next) => controller.getAll(req, res, next));
router.get('/get', (req, res, next) => controller.get(req, res, next));
router.post('/update', (req, res, next) => controller.update(req, res, next));
router.post('/delete', (req, res, next) => controller.delete(req, res, next));

module.exports = router;
