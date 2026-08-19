import assistantsClient from "./assistant.js";
import { getDBConnection, dbRun, dbGet, dbAll } from './database.js';
import logger from './logger.js'; // Import pino logger

// In-memory store for active threads is now removed. Database is the source of truth.

/**
 * Initializes a new chat thread with OpenAI and saves it to the database.
 * @returns {Promise<string>} The OpenAI Thread ID of the newly created thread.
 */
export async function initializeNewChat() {
  const db = getDBConnection();
  try {
    // 1. Create thread with OpenAI
    const openaiThread = await assistantsClient.beta.threads.create();
    const openaiThreadId = openaiThread.id;
    logger.info({ openaiThreadId }, `New OpenAI thread created.`);

    // 2. Store the OpenAI thread ID in the local 'threads' table
    logger.debug({ openaiThreadId }, `Attempting to save thread ID to DB.`);
    await dbRun(db, 'INSERT INTO threads (id) VALUES (?)', [openaiThreadId]);
    logger.info({ openaiThreadId }, `Thread ID saved to local database.`);

    return openaiThreadId;
  } catch (error) {
    logger.error({ err: error, openaiThreadId: openaiThread?.id }, "Error initializing new chat");
    throw error; // Re-throw to be handled by API endpoint
  } finally {
    db.close((err) => {
      if (err) logger.error(err, "Error closing DB connection in initializeNewChat");
    });
  }
}

/**
 * Continues a chat in an existing thread, saves messages to DB.
 * @param {string} assistantOpenAIId - The ID of the OpenAI assistant.
 * @param {string} threadOpenAIId - The OpenAI Thread ID to continue the chat in.
 * @param {string} userMessageContent - The user's message content.
 * @returns {Promise<string>} The assistant's latest response text.
 */
export async function continueChatInThread(assistantOpenAIId, threadOpenAIId, userMessageContent) {
  const db = getDBConnection();
  try {
    logger.debug({ threadOpenAIId }, `Continuing chat in thread.`);
    // Verify thread exists in local DB
    const threadExists = await dbGet(db, 'SELECT id FROM threads WHERE id = ?', [threadOpenAIId]);
    logger.debug({ threadOpenAIId, threadExists }, `Result of dbGet for thread ID.`);
    if (!threadExists) {
      throw new Error(`Thread with ID ${threadOpenAIId} not found in local database.`);
    }

    // 1. Add user message to OpenAI thread
    const userOpenAIMessage = await assistantsClient.beta.threads.messages.create(threadOpenAIId, {
      role: "user",
      content: userMessageContent,
    });
    logger.info({ threadId: threadOpenAIId, messageId: userOpenAIMessage.id }, `User message added to OpenAI thread.`);

    // Save user's OpenAI message to local DB
    await dbRun(db,
      'INSERT INTO messages (id, thread_id, role, content, created_at_ts) VALUES (?, ?, ?, ?, ?)',
      [userOpenAIMessage.id, threadOpenAIId, userOpenAIMessage.role, userMessageContent, userOpenAIMessage.created_at]
    );
    logger.info({ messageId: userOpenAIMessage.id, threadId: threadOpenAIId }, `User message saved to DB.`);

    // 2. Run the assistant on the OpenAI thread
    const run = await assistantsClient.beta.threads.runs.create(threadOpenAIId, {
      assistant_id: assistantOpenAIId,
    });
    logger.info({ runId: run.id, threadId: threadOpenAIId, assistantId: assistantOpenAIId }, `Run created.`);

    // 3. Poll until the run completes
    let status = run.status;
    let polledRun = run;
    while (status === "queued" || status === "in_progress") {
      await new Promise((r) => setTimeout(r, 1000));
      polledRun = await assistantsClient.beta.threads.runs.retrieve(threadOpenAIId, run.id);
      status = polledRun.status;
      logger.debug({ runId: run.id, status }, `Run status polled.`);
    }

    if (status === "completed") {
      logger.info({ runId: run.id, status }, "Run completed.");
      const openaiMessages = await assistantsClient.beta.threads.messages.list(threadOpenAIId, { order: 'desc', limit: 10 });

      let latestAssistantResponseText = "No new text response from assistant.";
      const assistantMessagesFromRun = openaiMessages.data.filter(
        (m) => m.role === "assistant" && m.run_id === run.id
      );

      for (const assistantMsg of assistantMessagesFromRun.sort((a,b) => a.created_at - b.created_at)) {
        let assistantContentText = "";
        if (assistantMsg.content && assistantMsg.content[0]?.type === 'text') {
          assistantContentText = assistantMsg.content[0].text.value;
          latestAssistantResponseText = assistantContentText;
        } else {
          assistantContentText = "[Non-text content received]";
        }

        const existingMsg = await dbGet(db, 'SELECT id FROM messages WHERE id = ?', [assistantMsg.id]);
        if (!existingMsg) {
          await dbRun(db,
            'INSERT INTO messages (id, thread_id, role, content, created_at_ts, run_id, assistant_id) VALUES (?, ?, ?, ?, ?, ?, ?)',
            [assistantMsg.id, threadOpenAIId, assistantMsg.role, assistantContentText, assistantMsg.created_at, assistantMsg.run_id, assistantMsg.assistant_id]
          );
          logger.info({ messageId: assistantMsg.id, runId: run.id, threadId: threadOpenAIId }, `Assistant message saved to DB.`);
        }
      }
      return latestAssistantResponseText;
    } else {
      logger.error({ runId: run.id, threadId: threadOpenAIId, status, errorDetails: polledRun.last_error || polledRun.incomplete_details }, `Run failed.`);
      throw new Error(`Run failed with status: ${status}. Details: ${JSON.stringify(polledRun.last_error || polledRun.incomplete_details || 'No additional error details.')}`);
    }
  } catch (error) {
    logger.error({ err: error, threadId: threadOpenAIId }, "Error continuing chat in thread");
    throw error; // Re-throw
  } finally {
    db.close((err) => {
      if (err) logger.error(err, "Error closing DB connection in continueChatInThread");
    });
  }
}

/**
 * Retrieves all messages for a given thread from the local database.
 * @param {string} threadId - The OpenAI Thread ID.
 * @returns {Promise<Array<object>>} A list of messages, formatted for client consumption.
 */
export async function getMessagesForThread(threadId) {
  const db = getDBConnection();
  try {
    logger.debug({ threadId }, `Fetching messages from DB.`);
    const messagesFromDB = await dbAll(
      db,
      'SELECT id, role, content, created_at_ts FROM messages WHERE thread_id = ? ORDER BY created_at_ts ASC',
      [threadId]
    );

    const formattedMessages = messagesFromDB.map(msg => ({
      id: msg.id,
      role: msg.role,
      content: msg.content,
      created_at: msg.created_at_ts,
    }));

    logger.info({ threadId, count: formattedMessages.length }, `Retrieved messages from DB.`);
    return formattedMessages;
  } catch (error) {
    logger.error({ err: error, threadId }, `Error fetching messages from DB.`);
    throw error;
  } finally {
    db.close((err) => {
      if (err) logger.error(err, "Error closing DB connection in getMessagesForThread");
    });
  }
}

/**
 * Retrieves a list of all thread IDs from the local database.
 * @returns {Promise<Array<string>>} An array of all thread IDs.
 */
export async function getAllThreadIds() {
  const db = getDBConnection();
  try {
    logger.debug("Fetching all thread IDs from database.");
    const threads = await dbAll(db, 'SELECT id FROM threads');
    const threadIds = threads.map(t => t.id);
    logger.info({ count: threadIds.length }, `Found threads in database.`);
    return threadIds;
  } catch (error) {
    logger.error(error, "Error fetching all thread IDs from DB");
    throw error;
  } finally {
    db.close((err) => {
      if (err) logger.error(err, "Error closing DB connection in getAllThreadIds");
    });
  }
}

// This function is no longer suitable for an API-based approach
// as it creates a new thread for every call.
// export async function chatWithAssistant(assistant_id, message) {
//   // 1. Create thread
//   const thread = await assistantsClient.beta.threads.create();

//   // 2. Add user message
//   await assistantsClient.beta.threads.messages.create(thread.id, {
//     role: "user",
//     content: message,
//   });

//   // 3. Run assistant
//   const run = await assistantsClient.beta.threads.runs.create(thread.id, {
//     assistant_id,
//   });

//   // 4. Poll until complete
//   let status = run.status;
//   while (status === "queued" || status === "in_progress") {
//     await new Promise((r) => setTimeout(r, 1000));
//     const poll = await assistantsClient.beta.threads.runs.retrieve(thread.id, run.id);
//     status = poll.status;
//   }

//   if (status === "completed") {
//     const messages = await assistantsClient.beta.threads.messages.list(thread.id);
//     const last = messages.data[0].content[0]?.text?.value;
//     return last;
//   } else {
//     throw new Error(`Run failed: ${status}`);
//   }
// }
