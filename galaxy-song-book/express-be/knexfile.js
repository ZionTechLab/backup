const path = require("path");
require("dotenv").config();

const dbClient = process.env.DB_CLIENT || "sqlite3";

const baseConfig = {
  migrations: {
    directory: "./database/migrations",
  },
  seeds: {
    directory: "./database/seeds",
  },
};

const configs = {
  sqlite3: {
    client: "sqlite3",
    connection: {
      filename: path.resolve(
        __dirname,
        process.env.DB_FILENAME || "./database/service_plus.db"
      ),
    },
    useNullAsDefault: true,
    ...baseConfig,
  },
  mysql: {
    client: "mysql2",
    connection: {
      host: process.env.DB_HOST,
      port: process.env.DB_PORT,
      database: process.env.DB_NAME,
      user: process.env.DB_USER,
      password: process.env.DB_PASSWORD,
    },
    ...baseConfig,
  },
  pg: {
    client: "pg",
    connection: {
      host: process.env.DB_HOST,
      port: process.env.DB_PORT,
      database: process.env.DB_NAME,
      user: process.env.DB_USER,
      password: process.env.DB_PASSWORD,
    },
    pool: {
      min: 2,
      max: 10,
    },
    ...baseConfig,
  },
};

// Additional environments for separate migration sets (core & service) sharing same connection
const baseDbConfig = configs[dbClient];
const multiEnv = {
  dev_core: {
    ...baseDbConfig,
    migrations: {
      directory: "./database/migrations/core",
      tableName: "knex_migrations_core",
    },
    seeds: {
      directory: "./database/seeds/core",
    },
  },
  dev_service: {
    ...baseDbConfig,
    migrations: {
      directory: "./database/migrations/service",
      tableName: "knex_migrations_service",
    },
    seeds: {
      directory: "./database/seeds/service",
    },
  },
  dev_jolly_snap: {
    ...baseDbConfig,
    migrations: {
      directory: "./database/migrations/jolly-snap",
      tableName: "knex_migrations_jolly_snap",
    },
    seeds: {
      directory: "./database/seeds/jolly-snap",
    },
  },
  dev_song_book: {
    ...baseDbConfig,
    migrations: {
      directory: "./database/migrations/songBook",
      tableName: "knex_migrations_song_book",
    },
    seeds: {
      directory: "./database/seeds/songBook",
    },
  },
  dev_hrm: {
    ...baseDbConfig,
    migrations: {
      directory: "./database/migrations/hrm",
      tableName: "knex_migrations_hrm",
    },
    seeds: {
      directory: "./database/seeds/hrm",
    },
  },
  dev_gl: {
    ...baseDbConfig,
    migrations: {
      directory: "./database/migrations/gl",
      tableName: "knex_migrations_gl",
    },
    seeds: {
      directory: "./database/seeds/gl",
    },
  },
  dev_petycash: {
    ...baseDbConfig,
    migrations: {
      directory: "./database/migrations/petycash",
      tableName: "knex_migrations_petycash",
    },
    seeds: {
      directory: "./database/seeds/petycash",
    },
  },
};

// In-memory SQLite for the Jest test suite. A single pinned connection keeps the
// schema alive across queries (each new sqlite :memory: connection is a fresh DB).
const test = {
  client: "sqlite3",
  connection: { filename: ":memory:" },
  useNullAsDefault: true,
  pool: { min: 1, max: 1 },
  ...baseConfig,
};

module.exports = {
  development: configs[dbClient],
  staging: configs[dbClient],
  production: configs[dbClient],
  test,
  // custom named envs for running separate migration sets
  ...multiEnv,
};
