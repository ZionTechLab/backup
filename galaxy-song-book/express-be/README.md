# Service Plus Backend

Express API backend service with Knex.js database integration.

## Getting Started

### Prerequisites
- Node.js (v14 or higher)
- npm

### Installation

1. Install dependencies:
```bash
npm install
```

2. Create environment file:
```bash
cp .env.example .env
```

3. Run database migrations (default combined set):
```bash
npm run migrate
```

If you want to manage two independent migration streams (core vs service), use the new scripts:
```bash
# Apply only core migrations
npm run migrate:core

# Apply only service migrations
npm run migrate:service

# Rollback last batch for core / service
npm run migrate:rollback:core
npm run migrate:rollback:service

# Create a new migration file inside the respective folder
npm run migrate:make:core add_table_x
npm run migrate:make:service add_table_y
```

Folders:
```
database/migrations/core     -> core schema objects
database/migrations/service  -> service-specific objects
database/seeds/core          -> core seed data
database/seeds/service       -> service seed data
```

Each set keeps its own history table (`knex_migrations_core`, `knex_migrations_service`). They share the same database connection. Name your migration files with standard timestamps to preserve ordering within each set.

4. Start the development server:
```bash
npm run dev
```

The API will be available at `http://localhost:3000`

### API Endpoints

- `GET /api` - Welcome message
- `GET /api/health` - Health check endpoint

### Scripts

- `npm start` - Start production server
- `npm run dev` - Start development server with nodemon

- `npm run migrate` - Run all standard migrations (legacy root directory)
- `npm run migrate:core` - Run only core migration set
- `npm run migrate:service` - Run only service migration set
- `npm run migrate:rollback:core` - Rollback last core batch
- `npm run migrate:rollback:service` - Rollback last service batch
- `npm run migrate:make:core <name>` - Create new core migration
- `npm run migrate:make:service <name>` - Create new service migration
- `npm run seed` - Run (legacy) default seeds directory
- `npm run seed:core` - Run only core seeds
- `npm run seed:service` - Run only service seeds
- `npm run migrate:rollback` - Rollback last migration
- `npm run migrate:make <name>` - Create new migration
- `npm run seed` - Run database seeds


 `npm run migrate:songBook` - Run only songBook migration set

### Environment Variables

Create a `.env` file in the root directory:

```
PORT=3000
NODE_ENV=development
DB_HOST=localhost
DB_PORT=5432
DB_NAME=service_plus
DB_USER=your_username
DB_PASSWORD=your_password
```

### Database

This project uses Knex.js for database management. The default configuration uses SQLite for development.

To create a new migration:
```bash
npm run migrate:make create_users_table
```

To run migrations:
```bash
npm run migrate
```
to connect my sql
ssh -L 3307:localhost:3306 root@5.189.136.234

<!-- write a script to transfer files without node molues to ftp location  -->

## Upload files to FTP without Node modules

A small Windows batch script is provided to upload files to a plain FTP server without any Node.js modules or external dependencies.

Script: `scripts/ftp_upload.cmd`

Usage:

```
ftp_upload.cmd <host> <username> <password> <local_path> [remote_path]
```

Examples:

```
REM Upload a single file
scripts\ftp_upload.cmd ftp.example.com myuser mypass "C:\path\to\file.txt" /uploads

REM Upload a directory recursively
scripts\ftp_upload.cmd ftp.example.com myuser mypass "C:\path\to\folder" /uploads/folder
```

Notes:
- This uses the built-in Windows `ftp.exe` client (active mode) and plain FTP. It does not support SFTP or FTPS.
- Passwords passed on the command line can be visible to other system users. Consider using more secure transfer methods if required.
