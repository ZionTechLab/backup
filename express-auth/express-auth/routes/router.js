const express = require("express");
const router = express.Router();

// Import controllers
const testController = require("../controllers/testController");
// You would also import your other controllers here, e.g.:
// const authController = require('../controllers/authController');

// Test route
router.get("/test", testController.test);

// You can add other authentication routes here
// router.post('/register', authController.register);
// router.post('/login', authController.login);

module.exports = router;