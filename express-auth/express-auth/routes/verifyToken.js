const jwt = require("jsonwebtoken");

const verifyToken = (req, res, next) => {
  let token = req.headers["authorization"];

  if (!token) {
    return res.status(401).send({ message: "Unauthorized: No token provided" });
  }
  token = token.replace(/Bearer /, "");

  jwt.verify(token, process.env.JWT_SECRET, (err, decoded) => {
    if (err) {
      return res.status(403).send({ message: "Unauthorized: Invalid token" });
    }

    req.userId = decoded.username; // Attach user ID to request object
    next();
  });
};

module.exports = verifyToken;
