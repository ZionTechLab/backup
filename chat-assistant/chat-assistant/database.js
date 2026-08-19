import sqlite3 from 'sqlite3';
import path from 'path';
import { fileURLToPath } from 'url';

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

const DB_FILEPATH = path.join(__dirname, 'chat.db');

/**
 * Establishes a connection to the SQLite database.
 * @returns {sqlite3.Database} The database connection object.
 */
import logger from './logger.js'; // Import pino logger

export function getDBConnection() {
  return new sqlite3.Database(DB_FILEPATH, (err) => {
    if (err) {
      logger.error(err, 'Error opening database');
    } else {
      // logger.trace('Connected to the SQLite database.'); // Use trace for very verbose logs
    }
  });
}

/**
 * Initializes the database schema by creating tables if they don't already exist.
 * @param {sqlite3.Database} db - The database connection object.
 * @returns {Promise<void>} A promise that resolves when schema initialization is complete or rejects on error.
 */
export async function initializeDatabase(db) {
  return new Promise((resolve, reject) => {
    db.serialize(() => {
      // Enable foreign key support
      db.run("PRAGMA foreign_keys = ON;", (err) => {
        if (err) {
          logger.error(err, "Error enabling foreign keys");
          return reject(err);
        }
      });

      // Create threads table
      db.run(`
        CREATE TABLE IF NOT EXISTS threads (
          id TEXT PRIMARY KEY,
          created_at DATETIME DEFAULT CURRENT_TIMESTAMP
        )
      `, (err) => {
        if (err) {
          logger.error(err, "Error creating threads table");
          return reject(err);
        }
        logger.info("Threads table checked/created.");
      });

      // Create messages table
      db.run(`
        CREATE TABLE IF NOT EXISTS messages (
          id TEXT PRIMARY KEY,
          thread_id TEXT NOT NULL,
          role TEXT NOT NULL CHECK(role IN ('user', 'assistant')),
          content TEXT NOT NULL,
          created_at_ts INTEGER NOT NULL,
          run_id TEXT,
          assistant_id TEXT,
          FOREIGN KEY (thread_id) REFERENCES threads(id) ON DELETE CASCADE
        )
      `, (err) => {
        if (err) {
          logger.error(err, "Error creating messages table");
          return reject(err);
        }
        logger.info("Messages table checked/created.");
        resolve();
      });
    });
  });
}

/**
 * A helper function to run a single SQL query with parameters as a Promise.
 * @param {sqlite3.Database} db The database connection.
 * @param {string} sql The SQL query to run.
 * @param {Array<any>} params The parameters to bind to the query.
 * @returns {Promise<{lastID?: number, changes?: number}>} Resolves with an object containing lastID and changes.
 */
export function dbRun(db, sql, params = []) {
  return new Promise((resolve, reject) => {
    db.run(sql, params, function(err) { // Use function() to access this.lastID/this.changes
      if (err) {
        logger.error({ sql, params, err }, 'Error running dbRun sql');
        reject(err);
      } else {
        resolve({ lastID: this.lastID, changes: this.changes });
      }
    });
  });
}

/**
 * A helper function to get a single row from a SQL query with parameters as a Promise.
 * @param {sqlite3.Database} db The database connection.
 * @param {string} sql The SQL query to run.
 * @param {Array<any>} params The parameters to bind to the query.
 * @returns {Promise<object|undefined>} Resolves with the row object or undefined if not found.
 */
export function dbGet(db, sql, params = []) {
  return new Promise((resolve, reject) => {
    db.get(sql, params, (err, row) => {
      if (err) {
        logger.error({ sql, params, err }, 'Error running dbGet sql');
        reject(err);
      } else {
        resolve(row);
      }
    });
  });
}

/**
 * A helper function to get all rows from a SQL query with parameters as a Promise.
 * @param {sqlite3.Database} db The database connection.
 * @param {string} sql The SQL query to run.
 * @param {Array<any>} params The parameters to bind to the query.
 * @returns {Promise<Array<object>>} Resolves with an array of row objects.
 */
export function dbAll(db, sql, params = []) {
  return new Promise((resolve, reject) => {
    db.all(sql, params, (err, rows) => {
      if (err) {
        logger.error({ sql, params, err }, 'Error running dbAll sql');
        reject(err);
      } else {
        resolve(rows);
      }
    });
  });
}
