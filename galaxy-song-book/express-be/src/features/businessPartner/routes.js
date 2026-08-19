const express = require('express');
const router = express.Router();
const Controller = require('./controller');

// File uploads use the central endpoint /api/files/upload.

router.get('/get-all', Controller.getAll);
router.get('/get', Controller.get);
router.post('/update', Controller.update);
router.post('/delete', Controller.delete);

module.exports = router;
