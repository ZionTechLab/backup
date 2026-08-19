# Express Auth API

This is a simple authentication API built with Node.js, Express, and Knex.js for database interaction. It provides endpoints for user registration and login using JWT for authentication.

## Prerequisites

- [Node.js](https://nodejs.org/) (v14 or higher recommended)
- A running database instance (e.g., MySQL, MSSQL)

## Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing purposes.

### 1. Install Dependencies

Install the required npm packages by running:

```bash
npm install
```

### 2. Configure Environment Variables

Create a `.env` file in the root directory of the project. This file will hold your sensitive configuration.

Here are the key variables you'll need to set:

```env
# Server Port
PORT=3000

# JWT Secret Key for signing tokens
JWT_SECRET=your_jwt_secret_key

# Knex Database Configuration
# See https://knexjs.org/guide/config.html for more options
# Example for MySQL
DB_CLIENT=mysql2
DB_HOST=127.0.0.1
DB_USER=your_db_user
DB_PASSWORD=your_db_password
DB_DATABASE=your_db_name
```

### 3. Running the Application

To start the application in development mode with `nodemon`, which will automatically restart the server on file changes, run:

```bash
npm start
```

The server should now be running on `http://localhost:3000` (or the port you specified in your `.env` file).