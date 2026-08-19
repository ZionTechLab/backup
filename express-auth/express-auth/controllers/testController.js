/**
 * A simple test controller method for a GET request.
 * @param {object} req - The Express request object.
 * @param {object} res - The Express response object.
 */
const test = (req, res) => {
  try {
    // This method now returns a simple JSON response for testing purposes.
    res.status(200).json({ message: "GET request to /api/test was successful!" });
  } catch (error) {
    console.error("Error in test controller:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

module.exports = { test };
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