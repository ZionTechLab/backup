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

To start the Express API server:

```bash
npm start
```

The server will typically start on `http://localhost:3000` (or the port specified by the `PORT` environment variable). You will see console logs indicating the assistant ID and that the server is listening.

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

## Project Structure

-   `index.js`: Main file for the Express server, sets up routes and starts the assistant.
-   `assistant.js`: Handles creation and configuration of the Azure OpenAI assistant.
-   `chat.js`: Manages chat threads, including creation, message handling, and interaction with the assistant's run lifecycle.
-   `.env` (you create this): Stores sensitive credentials.
-   `package.json`: Project dependencies and scripts.
-   `README.md`: This file.

## How it Works

1.  When the server starts, it first initializes an AI assistant using the configuration in `assistant.js`.
2.  Clients can then call `POST /chat/init` to create a new, unique chat thread. The ID of this thread is returned.
3.  To send a message, clients call `POST /chat/:threadId/message`, providing the `threadId` from the previous step and their message.
4.  The server adds the user's message to the specified thread, runs the assistant on that thread, and polls for the completion of the run.
5.  Once the assistant's processing is complete, its latest response from the thread is returned to the client.
6.  Multiple chat threads can exist concurrently, managed by an in-memory store in `chat.js`.

## Future Considerations (Optional)

-   **Persistent Thread Storage:** Currently, chat threads are stored in memory and will be lost if the server restarts. For production, consider using a database (e.g., Redis, PostgreSQL) to store thread IDs and potentially message history.
-   **Authentication/Authorization:** Secure the API endpoints if they are to be exposed publicly.
-   **More Sophisticated Logging:** Implement more structured logging for production monitoring.
-   **Scalability:** For high-load scenarios, consider containerization and load balancing.
-   **Configuration Management:** Move more hardcoded values (like API versions or assistant parameters) to environment variables or configuration files.
