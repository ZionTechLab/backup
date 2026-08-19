const express = require('express');
const router = express.Router();
const debtorController = require('./controller');

router.get('/get-ui', debtorController.getUi);
router.post('/getReport', debtorController.getReport);

module.exports = router;
