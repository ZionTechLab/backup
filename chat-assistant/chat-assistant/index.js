import express from 'express';
import pinoHttp from 'pino-http'; // Import pino-http
import swaggerUi from 'swagger-ui-express';
import YAML from 'yamljs';
import path from 'path';
import { fileURLToPath } from 'url';
import logger from './logger.js'; // Import shared pino logger instance
import { createAssistant } from "./assistant.js";
import { initializeNewChat, continueChatInThread, getMessagesForThread, getAllThreadIds } from "./chat.js";
import { getDBConnection, initializeDatabase } from './database.js';
import cors from 'cors';

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

const app = express();
const port = process.env.PORT || 3000;

// HTTP Request Logging - using the same logger instance
const httpLogger = pinoHttp({
  logger: logger, // Use the existing logger instance
  // Optional: Define custom success/error messages or serializers
  // serializers: { ... }
});
app.use(httpLogger);


// Load Swagger/OpenAPI document
const swaggerDocument = YAML.load(path.join(__dirname, 'openapi.yaml'));
app.use(cors({
  origin: [
    'http://localhost:3001',
    'https://app-openai-chat-assistance-fe-fchvd4f5b4cah5ea.southeastasia-01.azurewebsites.net'
  ]
}));
app.use(express.json());

// Serve Swagger UI
app.use('/api-docs', swaggerUi.serve, swaggerUi.setup(swaggerDocument));

let assistantId;

// Basic route for testing
app.get('/', (req, res) => {
  res.send('Chatbot API is running!');
});

// API Endpoint to initialize a new chat
app.post('/chat/init', async (req, res, next) => {
  try {
    if (!assistantId) {
      logger.warn('Assistant not initialized attempt to /chat/init');
      return res.status(503).json({ error: "Assistant not initialized yet. Please try again shortly." });
    }
    logger.info('Request received for /chat/init');
    const threadId = await initializeNewChat();
    res.json({ threadId });
  } catch (error) {
    logger.error(error, "Error initializing chat");
    next(error);
  }
});

// API Endpoint to send a message to an existing chat
app.post('/chat/:threadId/message', async (req, res, next) => {
  try {
    const { threadId } = req.params;
    logger.info({ threadId }, 'Request received for /chat/:threadId/message');
    if (!assistantId) {
      logger.warn({ threadId }, 'Assistant not initialized attempt to /chat/:threadId/message');
      return res.status(503).json({ error: "Assistant not initialized yet. Please try again shortly." });
    }
    const { message } = req.body;

    if (!message) {
      logger.warn({ threadId }, 'Missing message in request body for /chat/:threadId/message');
      return res.status(400).json({ error: "Message is required in the request body." });
    }

    const response = await continueChatInThread(assistantId, threadId, message);
    res.json({ response });
  } catch (error) {
    logger.error(error, `Error in chat thread ${req.params.threadId}`);
    next(error);
  }
});

// API Endpoint to get message history for a thread
app.get('/chat/:threadId/messages', async (req, res, next) => {
  try {
    const { threadId } = req.params;
    logger.info({ threadId }, 'Request received for /chat/:threadId/messages');
    // Assistant ID check might not be strictly necessary for fetching messages if DB is source of truth
    // but kept for consistency or if future logic requires assistant context.
    if (!assistantId && false) { // Disabled assistantId check for now for this read-only op
      logger.warn({ threadId }, 'Assistant context not initialized attempt to /chat/:threadId/messages');
      return res.status(503).json({ error: "Assistant context not initialized yet. Please try again shortly." });
    }
    const messages = await getMessagesForThread(threadId);
    res.json({ messages });
  } catch (error) {
    logger.error(error, `Error fetching messages for thread ${req.params.threadId}`);
    next(error);
  }
});

// API Endpoint to get all thread IDs from DB
app.get('/chat/threads', async (req, res, next) => {
  try {
    logger.info('Request received for /chat/threads');
    const threadIds = await getAllThreadIds();
    res.json({ threadIds });
  } catch (error) {
    logger.error(error, "Error fetching all thread IDs");
    next(error);
  }
});

// Generic error handling middleware
app.use((err, req, res, next) => { // eslint-disable-line no-unused-vars
  logger.error(err, "Unhandled error caught by generic error handler");

  if (err.message && (
      err.message.includes("not found in local database") ||
      err.message.includes("not found or not initialized"))
     ) {
    return res.status(404).json({
      error: "Chat session not found.",
      details: err.message
    });
  }

  if (err.status) {
    return res.status(err.status).json({ error: err.message, details: err.details || 'No additional details.' });
  }

  res.status(500).json({
    error: "Internal Server Error",
    details: "An unexpected error occurred. Please try again later."
  });
});


// Function to initialize the assistant and start the server
const initializeAndStartServer = async () => {
  try {
    // Initialize database
    const db = getDBConnection();
    await initializeDatabase(db);
    db.close((err) => {
      if (err) {
        logger.error(err, "Error closing initial DB connection");
      } else {
        logger.info("Initial DB connection closed after schema setup.");
      }
    });
    logger.info("Database initialized.");

    const assistant = await createAssistant();
    assistantId = assistant.id;
    logger.info({ assistantId }, `Assistant created.`);

    app.listen(port, () => {
      logger.info({ port }, `Server listening.`);
      logger.info("Chat API endpoints are live:\n" +
                  `  POST /chat/init\n` +
                  `  POST /chat/:threadId/message\n` +
                  `  GET  /chat/:threadId/messages\n` +
                  `  GET  /chat/threads`);
    });

  } catch (err) {
    logger.fatal(err, "Error during server initialization"); // Use fatal for critical startup errors
    process.exit(1); // Exit if assistant creation or DB init fails
  }
};

initializeAndStartServer();
