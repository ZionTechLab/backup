import assistantsClient from "./assistant.js";

// In-memory store for active threads
const activeThreads = {};

/**
 * Initializes a new chat thread.
 * @returns {Promise<string>} The ID of the newly created thread.
 */
export async function initializeNewChat() {
  const thread = await assistantsClient.beta.threads.create();
  activeThreads[thread.id] = thread; // Store the thread object
  console.log(`New thread created with ID: ${thread.id}`);
  return thread.id;
}

/**
 * Continues a chat in an existing thread.
 * @param {string} assistant_id - The ID of the assistant.
 * @param {string} threadId - The ID of the thread to continue the chat in.
 * @param {string} message - The user's message.
 * @returns {Promise<string>} The assistant's response.
 * @throws {Error} If the thread is not found or the run fails.
 */
export async function continueChatInThread(assistant_id, threadId, message) {
  if (!activeThreads[threadId]) {
    throw new Error(`Thread with ID ${threadId} not found or not initialized.`);
  }

  // Add user message to the existing thread
  await assistantsClient.beta.threads.messages.create(threadId, {
    role: "user",
    content: message,
  });
  console.log(`Message added to thread ${threadId}`);

  // Run the assistant on the thread
  const run = await assistantsClient.beta.threads.runs.create(threadId, {
    assistant_id,
  });
  console.log(`Run created with ID ${run.id} for thread ${threadId}`);

  // Poll until the run completes
  let status = run.status;
  while (status === "queued" || status === "in_progress") {
    await new Promise((r) => setTimeout(r, 1000)); // Wait for 1 second before polling
    const poll = await assistantsClient.beta.threads.runs.retrieve(threadId, run.id);
    status = poll.status;
    console.log(`Run status for ${run.id}: ${status}`);
  }

  if (status === "completed") {
    const messages = await assistantsClient.beta.threads.messages.list(threadId);
    // The latest message is usually the first in the 'data' array when listed in default order (descending).
    // We look for the latest assistant message.
    const assistantMessages = messages.data.filter(m => m.role === 'assistant');
    if (assistantMessages.length > 0 && assistantMessages[0].content[0]?.type === 'text') {
      console.log(`Assistant response received for thread ${threadId}`);
      return assistantMessages[0].content[0].text.value;
    }
    return "No text response from assistant.";
  } else {
    console.error(`Run failed for thread ${threadId} with status: ${status}`);
    const poll = await assistantsClient.beta.threads.runs.retrieve(threadId, run.id);
    console.error('Run details:', poll);
    throw new Error(`Run failed with status: ${status}. Details: ${JSON.stringify(poll.last_error || poll.incomplete_details || 'No additional error details.')}`);
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
