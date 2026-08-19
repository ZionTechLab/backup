import express from 'express';
import morgan from 'morgan'; // Import morgan
import swaggerUi from 'swagger-ui-express'; // Import swagger-ui-express
import YAML from 'yamljs'; // Import yamljs
import path from 'path'; // Import path for resolving file paths
import { fileURLToPath } from 'url'; // To handle __dirname in ES modules
import { createAssistant } from "./assistant.js";
import { initializeNewChat, continueChatInThread } from "./chat.js";

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

const app = express();
const port = process.env.PORT || 3000;

// Load Swagger/OpenAPI document
const swaggerDocument = YAML.load(path.join(__dirname, 'openapi.yaml'));

app.use(express.json()); // Middleware to parse JSON bodies
app.use(morgan('dev')); // Middleware for HTTP request logging

// Serve Swagger UI
app.use('/api-docs', swaggerUi.serve, swaggerUi.setup(swaggerDocument));

let assistantId;

// Basic route for testing
app.get('/', (req, res) => {
  res.send('Chatbot API is running!');
});

// API Endpoint to initialize a new chat
app.post('/chat/init', async (req, res) => {
  try {
    if (!assistantId) {
      return res.status(503).json({ error: "Assistant not initialized yet. Please try again shortly." });
    }
    const threadId = await initializeNewChat();
    res.json({ threadId });
  } catch (error) {
    console.error("Error initializing chat:", error);
    // Forward to the error handling middleware
    next(error);
  }
});

// API Endpoint to send a message to an existing chat
app.post('/chat/:threadId/message', async (req, res) => {
  try {
    if (!assistantId) {
      return res.status(503).json({ error: "Assistant not initialized yet. Please try again shortly." });
    }
    const { threadId } = req.params;
    const { message } = req.body;

    if (!message) {
      return res.status(400).json({ error: "Message is required in the request body." });
    }

    const response = await continueChatInThread(assistantId, threadId, message);
    res.json({ response });
  } catch (error) {
    console.error(`Error in chat thread ${req.params.threadId}:`, error);
    // Forward to the error handling middleware
    next(error);
  }
});

// Generic error handling middleware
app.use((err, req, res, next) => {
  console.error("Unhandled error:", err);

  // Specific error handling based on error properties or messages
  if (err.message && err.message.includes("not found or not initialized")) {
    return res.status(404).json({
      error: "Chat session not found or not initialized.",
      details: "Please ensure you have initialized a chat session using POST /chat/init and are using the correct threadId."
    });
  }

  if (err.status) {
    return res.status(err.status).json({ error: err.message, details: err.details });
  }

  res.status(500).json({
    error: "Internal Server Error",
    details: "An unexpected error occurred. Please try again later."
  });
});


// Function to initialize the assistant and start the server
const initializeAndStartServer = async () => {
  try {
    const assistant = await createAssistant();
    assistantId = assistant.id;
    console.log(`Assistant created with ID: ${assistantId}`);

    app.listen(port, () => {
      console.log(`Server listening on port ${port}`);
      console.log("Chat API endpoints are live:");
      console.log(`  POST /chat/init`);
      console.log(`  POST /chat/:threadId/message`);
    });

  } catch (err) {
    console.error("❌ Error during server initialization:", err.message);
    process.exit(1); // Exit if assistant creation fails
  }
};

initializeAndStartServer();
