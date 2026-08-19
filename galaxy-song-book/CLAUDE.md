# Galaxy Song Book — Monorepo

Two apps in this repo. Backend first, frontend second.

| App | Path | Role |
|---|---|---|
| **express-be** | [express-be/](express-be/) | Express.js API (Knex + SQLite) |
| **my-app** | [my-app/](my-app/) | React 19 SPA (Redux Toolkit + Bootstrap 5) |

Focused scope: Song Book feature plus admin/support screens. Other backend
feature folders and migrations from the original monorepo remain in place but
are not exposed in the menu.

## Project-specific instructions

Each app has its own CLAUDE.md with detailed patterns and conventions. Always read the relevant one before working in that directory.

- Backend rules: [express-be/CLAUDE.md](express-be/CLAUDE.md)
- Frontend rules: [my-app/CLAUDE.md](my-app/CLAUDE.md)

## Cross-cutting rules

Work on one app at a time. Do not mix concerns.

Auth flows across both apps. JWT in backend, auth slice + in-memory token in frontend. Access token never hits localStorage. Refresh token does.

Shared UI components live in [my-app/src/components/](my-app/src/components/). Import directly: `import { DataTable } from '../components/DataTable'`.

## Running the stack

Start the backend first. Frontend proxies API calls to it.

```bash
# Backend
cd express-be && npm install && npm run dev

# Frontend (separate terminal)
cd my-app && npm install && npm start
```

Backend API at `http://localhost:3000`. Frontend at `http://localhost:3001` (or next available port).

## Core Rules

Short sentences only (8-10 words max).

No filler, no preamble, no pleasantries.

Tool first. Result first. No explain unless asked.

Code stays normal. English gets compressed.

---

## Formatting

Output sounds human. Never AI-generated.

Never use em-dashes or replacement hyphens.

Avoid parenthetical clauses entirely.

Hyphens map to standard grammar only.
