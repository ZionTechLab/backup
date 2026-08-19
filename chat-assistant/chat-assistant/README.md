# AI Chatbot Express API

This project implements an AI Chatbot using Azure OpenAI and exposes its functionality via an Express.js API. It allows for initializing multiple chat sessions and continuing conversations within those sessions.

## Prerequisites

- Node.js (version specified in `package.json` or latest LTS)
- An Azure OpenAI account with a deployed model (e.g., gpt-35-turbo).
- A Vector Store ID for file search capabilities if used by the assistant.

## Setup

1.  **Clone the repository:**
    ```bash
    git clone <repository-url>
    cd <repository-directory>
    ```

2.  **Install dependencies:**
    ```bash
    npm install
    ```

3.  **Configure environment variables:**
    Create a `.env` file in the root of the project and add the following variables:
    ```env
    AZURE_OPENAI_KEY="your_azure_openai_key"
    AZURE_OPENAI_ENDPOINT="your_azure_openai_endpoint"
    # AZURE_OPENAI_API_VERSION="2024-05-01-preview" (Already set in assistant.js, but good to note)
    # VECTOR_STORE_ID="your_vector_store_id" (Already set in assistant.js, but good to note if you change it)
    ```
    Replace the placeholder values with your actual Azure OpenAI credentials and endpoint. The `assistant.js` file has the `apiVersion` and `vector_store_ids` hardcoded, but you might need to update them based on your assistant's configuration.

## Running the Server

### Production Mode

To start the Express API server in production mode (or for standard execution):

```bash
npm start
```

The server will typically start on `http://localhost:3000` (or the port specified by the `PORT` environment variable). You will see console logs indicating the assistant ID and that the server is listening.

### Development Mode (with Auto-Restart)

For development, it's recommended to run the server using `nodemon`, which will automatically restart the application when file changes are detected in the directory.

To start the server in development mode:

```bash
npm run dev
```
This uses `nodemon` to monitor `index.js` and related files. `NODE_ENV` is set to `development` in this script to enable pretty-printed console logs.

## Logging

This project uses `pino` for structured logging.
-   **Development:** When `NODE_ENV` is set to `development` (e.g., via the `npm run dev` script), logs are automatically pretty-printed to the console using `pino-pretty` for readability.
-   **Production:** In other environments (or if `NODE_ENV` is not `development`), logs will be output as newline-delimited JSON objects, suitable for consumption by log management systems.
-   **HTTP Requests:** All incoming HTTP requests and their responses are automatically logged with details like request ID, method, URL, status code, and response time, thanks to `pino-http`.
-   **Log Level:** The log level can be controlled via the `LOG_LEVEL` environment variable (e.g., `LOG_LEVEL=debug` to see more detailed logs). Defaults to `info`.

Example of piping production JSON logs to `pino-pretty` for ad-hoc readability:
```bash
NODE_ENV=production node index.js | pino-pretty
```

## API Endpoints

The API provides the following endpoints to interact with the chatbot:

### Accessing API Documentation (Swagger UI)

Interactive API documentation is available via Swagger UI. Once the server is running, you can access it by navigating to:

[`http://localhost:3000/api-docs`](http://localhost:3000/api-docs)

The Swagger UI allows you to:
- View all available API endpoints.
- See detailed information about request parameters, request bodies, and response schemas.
- Directly test the API endpoints from your browser.

### 1. Initialize Chat

-   **Endpoint:** `POST /chat/init`
-   **Description:** Initializes a new chat session with the AI assistant.
-   **Request Body:** None
-   **Response:**
    -   `200 OK`:
        ```json
        {
          "threadId": "thread_xxxxxxxxxxxxxxxxxxxx"
        }
        ```
        (Where `thread_xxxxxxxxxxxxxxxxxxxx` is the unique ID for the new chat session)
    -   `500 Internal Server Error`: If there's an issue creating the chat thread.
    -   `503 Service Unavailable`: If the AI assistant is not yet initialized (e.g., during server startup).

### 2. Send Message to Chat

-   **Endpoint:** `POST /chat/:threadId/message`
-   **Description:** Sends a message to an existing chat session and gets the assistant's response.
-   **URL Parameters:**
    -   `threadId` (string, required): The ID of the chat session, obtained from the `/chat/init` endpoint.
-   **Request Body:**
    ```json
    {
      "message": "Your message to the chatbot here"
    }
    ```
-   **Response:**
    -   `200 OK`:
        ```json
        {
          "response": "The assistant's reply to your message."
        }
        ```
    -   `400 Bad Request`: If the `message` field is missing in the request body.
    -   `404 Not Found`: If the specified `threadId` does not correspond to an active chat session.
    -   `500 Internal Server Error`: If there's an issue processing the message or communicating with the AI.
    -   `503 Service Unavailable`: If the AI assistant is not yet initialized.

### 3. Get Message History for a Chat Session

-   **Endpoint:** `GET /chat/:threadId/messages`
-   **Description:** Retrieves the list of messages for a specific chat session, sorted in chronological order (oldest first).
-   **URL Parameters:**
    -   `threadId` (string, required): The ID of the chat session (thread).
-   **Response:**
    -   `200 OK`:
        ```json
        {
          "messages": [
            {
              "id": "msg_xxxxxxxxxxxxxx",
              "role": "user",
              "content": "Hello",
              "created_at": 1678886400
            },
            {
              "id": "msg_yyyyyyyyyyyyyy",
              "role": "assistant",
              "content": "Hi there! How can I help you?",
              "created_at": 1678886405
            }
            // ... more messages
          ]
        }
        ```
    -   `404 Not Found`: If the `threadId` does not correspond to an active or known chat session, or if the thread is empty.
    -   `500 Internal Server Error`: If there's an issue retrieving the messages.
    -   `503 Service Unavailable`: If the AI assistant context is not initialized (less likely for this read operation but included for consistency).

### 4. List Active Chat Session IDs

-   **Endpoint:** `GET /chat/threads/active`
-   **Description:** Retrieves a list of all chat session (thread) IDs that are currently active and stored in the server's memory.
-   **URL Parameters:** None
-   **Response:**
    -   `200 OK`:
        ```json
        {
          "activeThreadIds": [
            "thread_abc123xyz",
            "thread_def456uvw",
            // ... more active thread IDs
          ]
        }
        ```
    -   `500 Internal Server Error`: If there's an unexpected issue retrieving the list (though unlikely for this operation).

### 4. List All Persisted Chat Session IDs (Updated)

-   **Endpoint:** `GET /chat/threads`
-   **Description:** Retrieves a list of all chat session (thread) IDs that have been persisted in the database.
-   **URL Parameters:** None
-   **Response:**
    -   `200 OK`:
        ```json
        {
          "threadIds": [ // Note: key changed from activeThreadIds
            "thread_abc123xyz",
            "thread_def456uvw"
          ]
        }
        ```
    -   `500 Internal Server Error`: If there's an unexpected issue retrieving the list.


## Project Structure

-   `index.js`: Main file for the Express server, sets up routes, initializes DB, and starts the assistant.
-   `assistant.js`: Handles creation and configuration of the Azure OpenAI assistant.
-   `chat.js`: Manages chat logic, interacting with both OpenAI and the local SQLite database for persistence.
-   `database.js`: Handles SQLite database connection, schema initialization, and provides DB helper functions.
-   `chat.db`: (Generated file) The SQLite database file where chat threads and messages are stored. This file will be created in the project root when the server first starts.
-   `.env` (you create this): Stores sensitive credentials.
-   `package.json`: Project dependencies and scripts.
-   `README.md`: This file.

## How it Works

1.  **Database Initialization:** When the server starts, `database.js` ensures an SQLite database (`chat.db`) exists and creates the `threads` and `messages` tables if they are not already present.
2.  **Assistant Initialization:** The AI assistant is initialized via `assistant.js`.
3.  **Chat Initialization (`POST /chat/init`):**
    *   A new thread is created using the OpenAI API.
    *   The OpenAI thread ID is saved into the local `threads` table in `chat.db`.
    *   The OpenAI thread ID is returned to the client.
4.  **Sending Messages (`POST /chat/:threadId/message`):**
    *   The user's message is sent to the specified OpenAI thread. This message (ID, content, role, timestamp) is saved to the local `messages` table, linked to the thread.
    *   The assistant processes the message.
    *   The assistant's response(s) are retrieved from OpenAI. Each assistant message (ID, content, role, timestamp, run ID, assistant ID) is also saved to the local `messages` table.
    *   The latest assistant text response is returned to the client.
5.  **Retrieving Message History (`GET /chat/:threadId/messages`):**
    *   Messages for the given `threadId` are fetched from the local `messages` table in `chat.db`.
6.  **Listing All Threads (`GET /chat/threads`):**
    *   All thread IDs are fetched from the local `threads` table in `chat.db`.
7.  **Persistence:** Because threads and messages are stored in `chat.db`, conversation history persists across server restarts.

## Future Considerations (Optional)

-   **Persistent Thread Storage:** Currently, chat threads are stored in memory and will be lost if the server restarts. For production, consider using a database (e.g., Redis, PostgreSQL) to store thread IDs and potentially message history.
-   **Authentication/Authorization:** Secure the API endpoints if they are to be exposed publicly.
-   **More Sophisticated Logging:** Implement more structured logging for production monitoring.
-   **Scalability:** For high-load scenarios, consider containerization and load balancing.
-   **Configuration Management:** Move more hardcoded values (like API versions or assistant parameters) to environment variables or configuration files.
