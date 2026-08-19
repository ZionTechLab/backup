const express = require("express");
const router = require("./routes/router");

const app = express();

app.use(express.json()); // To parse request body data
app.use("/api", router);

const port = process.env.PORT || 3000; // Use environment variable or default port

app.listen(port, () => {
  console.log(`Server listening on port ${port}`);
});
