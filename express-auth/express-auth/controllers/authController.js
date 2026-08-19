const jwt = require("jsonwebtoken");
const bcrypt = require("bcryptjs");
require("dotenv").config();
const { findUserByUsername, saveRefreshToken } = require("../models/userModel");
// Dummy user for testing
const dummyUser = {
  _id: "1",
  username: "test",
  password: '$2a$10$r6yr6EZldZu8uilANL613.PTDCOA7QxLGWo2Z7zzDn0VWVwWCa4ku', // Hashed version of "123456"
};
const register = async (req, res) => {
  try {
    bcrypt.hash("123456", 10).then(console.log); 
    const newUser = req.body;
    console.log(req.body);
    if (newUser.username != "test") {
      res.status(500).json({ message: "Invalied User Name or Password " });
    } else {
      const accessToken = jwt.sign(
        { username: newUser.username }, // Use user ID for better security
        process.env.JWT_SECRET,
        { expiresIn: "15m" }
      );
      console.log(accessToken);

      jwt.verify(accessToken, process.env.JWT_SECRET, (err, decoded) => {
        console.log(decoded);
      });

      // Generate a refresh token with a longer expiration (e.g., 1 hour)
      const refreshToken = jwt.sign(
        { userId: newUser._id }, // Use user ID for better security
        process.env.JWT_SECRET + process.env.REFRESH_TOKEN_SECRET, // Concatenate for added security
        { expiresIn: "1h" }
      );

      // Securely store the refresh token in a database or other secure mechanism
      await storeRefreshToken(refreshToken, newUser._id); // Implement secure storage

      res.json({
        accessToken,
        refreshToken,
        AccessTokenExpiration: new Date(Date.now() + 15 * 60 * 1000),
        refreshTokenExpiration: new Date(Date.now() + 60 * 60 * 1000), // Include expiration details (1 hour from now)
      });
    }
  } catch (error) {
    console.error(error);
    res.status(500).json({ message: "Registration failed" });
  }
};

// Function to securely store the refresh token (implementation details omitted)
const storeRefreshToken = async (token, userId) => {
  // Implement secure storage logic (e.g., database with encryption, separate secrets management service)
};
const gemba = async (req, res) => {
  console.log("tst");
  res.json({
    AccessTokenExpiration: new Date(Date.now() + 15 * 60 * 1000),
    refreshTokenExpiration: new Date(Date.now() + 60 * 60 * 1000), // Include expiration details (1 hour from now)
  });
};

const login = async (req, res) => {
  try {
    const { username, password } = req.body;

    if (!username || !password) {
      return res.status(400).json({ message: "Username and password are required" });
    }

    const user = await findUserByUsername(username);
    if (!user || !(await bcrypt.compare(password, user.password))) {
      return res.status(401).json({ message: "Invalid credentials" });
    }

    const accessTokenValidityMs = parseInt(process.env.ACCESS_TOKEN_VALIDITY) * 60 * 1000;
    const refreshTokenValidityMs = parseInt(process.env.REFRESH_TOKEN_VALIDITY) * 60 * 1000;

    const now = Date.now();
    const accessTokenExpiration = new Date(now + accessTokenValidityMs);
    const refreshTokenExpiration = new Date(now + refreshTokenValidityMs);

    const accessToken = jwt.sign(
      { userId: user.id },
      process.env.JWT_SECRET,
      { expiresIn: `${process.env.ACCESS_TOKEN_VALIDITY}m` }
    );

    const refreshToken = jwt.sign(
      { userId: user.id },
      process.env.JWT_SECRET + process.env.REFRESH_TOKEN_SECRET,
      { expiresIn: `${process.env.REFRESH_TOKEN_VALIDITY}m` }
    );

    await saveRefreshToken(user.id, refreshToken, new Date(now), refreshTokenExpiration);

    res.json({
      accessToken,
      refreshToken,
      accessTokenExpiration,
      refreshTokenExpiration,
    });

  } catch (err) {
    console.error("🔴 Login error:", err);
    res.status(500).json({ message: "Internal server error" });
  }
};


// const login = async (req, res) => {

//   const token = jwt.sign({ username: User.username }, process.env.JWT_SECRET, {
//     expiresIn: "30m",
//   });
//   res.json({ token });
// };

module.exports = { register, login, gemba };
