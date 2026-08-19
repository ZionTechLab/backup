# Galaxy Song Book

Standalone app for registering and tracking songs. React frontend, Express.js backend.

## Projects

| App | Path | Tech |
|---|---|---|
| Backend | [express-be/](express-be/) | Express.js, Knex, SQLite |
| Frontend | [my-app/](my-app/) | React 19, Redux Toolkit, Bootstrap 5 |

## Setup

Flat repo, no submodules. Clone and install.

```bash
git clone <repo-url> galaxy-song-book
cd galaxy-song-book
npm install
```

`npm install` at the root triggers `postinstall`, which installs both `express-be` and `my-app` dependencies.

Copy `express-be/.env.example` to `express-be/.env` (or create one) pointing at a local SQLite file, then run migrations:

```bash
cd express-be
npm run migrate:all
```

## Running

### Both apps at once

```bash
npm run dev
```

Backend on port 3000, frontend on port 3001.

### Or individually

```bash
# Backend only
cd express-be && npm run dev

# Frontend only
cd my-app && npm start
```

### Windows batch file

Double-click `start-dev.bat` to launch both apps in separate terminal windows.
