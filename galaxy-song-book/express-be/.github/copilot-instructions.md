# Copilot Instructions for Service Plus Backend

## What this service is
- Express.js HTTP API with Knex.js for DB access; default dev DB is SQLite (`database/service_plus.db`).
- Entry: `src/app.js` sets middleware, Swagger, static `/uploads`, and mounts all feature routers under `/api` via `src/routes/index.js`.
- DB bootstrap: `src/database.js` selects env from `knexfile.js` (`development|staging|production`).

## Project layout (paths to know)
- `src/routes/index.js` – central router; mounts feature routers with `authenticate` middleware under `/api`: `auth`, `user`, `businessPartner`, `debtor`, `activityLog`, `vehicleConfirmation`, `category`, `reports`, `item`, `job`, `hrm`. Public routes (no auth): `jolly-snap`, `song-book`.
- Feature modules live in `src/features/<camelCaseName>/` with four files: `routes.js` → `controller.js` → `repository.js`, plus `validation.js` holding the yup schemas.
- GL / finance features are grouped one level deeper under `src/features/gl/<camelCaseName>/`: `accountType`, `chartOfAccounts`, `ledger`, `financialMonth`. Their relative imports use `../../../` (three levels) to reach `src/middleware`, `src/database`, `src/repository`. They still mount under `/api/gl/...`.
- Cross-cutting helpers:
  - `src/middleware/` — `asyncHandler`, `errorHandler`/`AppError`, `auth` (JWT), `logger`
  - `src/repository/getNextSerialNo.js` — allocates serial IDs within a transaction
  - `src/repository/validators.js` — `ensureUnique()` for application-level uniqueness checks
  - `src/repository/auditHistory.js` — `snapshotBefore()` for writing pre-change snapshots to `_history` tables
- Swagger served at `/api/docs` from `src/swagger.js`.
- Migrations: `database/migrations/<stream>/`; Seeds: `database/seeds/<stream>/`.

## Folder naming convention
Feature folders under `src/features/` use **camelCase**: `businessPartner`, `activityLog`, `songBook`, `hrm`. Never PascalCase, kebab-case, or snake_case (exception: `jolly-snap` which predates the convention). GL features nest under the `gl/` group folder (e.g. `gl/chartOfAccounts`); the inner folder still follows camelCase.

## Core patterns

### Route / controller
- Wrap every controller export with `asyncHandler`; throw `new AppError(message, status)` for expected errors.
- Pass `req.user.sub` as `userId` into every repo call — never hardcode `userId: 0`.

```js
// controller.js
exports.update = asyncHandler(async (req, res) => {
  const record = await repo.update({ ...req.body, userId: req.user.sub });
  res.status(201).json(record);
});
```

### Input validation
- Keep yup schemas in a separate `validation.js` per feature. Do **not** inline them in the controller.
- A schema file imports only `yup` (and the validation helpers). It must not import the repository or `database`. This keeps schema unit tests free of any DB connection.
- Export every schema by name so tests can import it directly.
- Validate request bodies with `yup` before touching the repository. Use the shared `VALIDATE_OPTS` (`abortEarly: false`, `stripUnknown: true`) from `src/middleware/validation`. For optional numeric fields use `optionalNumber()` from the same module.

```js
// validation.js
const yup = require('yup');
const { optionalNumber } = require('../../middleware/validation');

const updateSchema = yup.object({
  id: optionalNumber(),
  title: yup.string().required(),
});

const deleteSchema = yup.object({ id: yup.number().required() });

module.exports = { updateSchema, deleteSchema };
```

```js
// controller.js
const { updateSchema, deleteSchema } = require('./validation');
const { VALIDATE_OPTS } = require('../../middleware/validation');

exports.update = asyncHandler(async (req, res) => {
  const data = await updateSchema.validate(req.body, VALIDATE_OPTS);
  const record = await repo.update({ ...data, userId: req.user.sub });
  res.status(201).json(record);
});
```

### Data access (repository)
- Mix `db.raw(sql, params)` and Knex builder; stay consistent with the existing style in the feature.
- **Never spread `...data.header` (or any user-supplied object) directly into `.insert()` or `.update()`** — always pick fields explicitly to prevent mass assignment.
- All queries on soft-deletable tables must filter `deleted = false`.

### Update / delete pattern — audit history
Do **not** use the old soft-update (mark deleted + re-insert) for updates. Use a standard UPDATE and write a history snapshot:

```js
// repository.js
const { snapshotBefore } = require('../../repository/auditHistory');

async update(data) {
  return db.transaction(async (trx) => {
    if (data.isUpdate) {
      await snapshotBefore(trx, '<table>', { id: data.id, deleted: false }, data.userId, 'UPDATE');
      await trx('<table>').where({ id: data.id, deleted: false }).update({
        field1: data.field1,
        // explicit fields only
        userId: data.userId,
        userDT: new Date(),
      });
      return trx('<table>').where({ id: data.id, deleted: false }).first();
    }
    const id = await getNextSerialNo(trx, docType, txnType);
    await trx('<table>').insert({ tenantId: data.tenantId || 1, companyId: data.companyId || 1, id, /* explicit fields */, userId: data.userId, userDT: new Date() });
    return trx('<table>').where({ id, deleted: false }).first();
  });
},

async delete(data) {
  return db.transaction(async (trx) => {
    await snapshotBefore(trx, '<table>', { id: data.id, deleted: false }, data.userId, 'DELETE');
    await trx('<table>').where({ id: data.id, deleted: false }).update({ deleted: true, userId: data.userId, userDT: new Date() });
    return 'success';
  });
},
```

`snapshotBefore(trx, table, where, userId, changeType)` reads the current row and inserts it as JSON into `<table>_history`. It returns the existing row so you can use it in the same transaction if needed.

The `deleted` flag on actual deletions (soft-delete) is still valid — this only replaces the anti-pattern of using soft-delete as an update mechanism.

### ID allocation
Use `getNextSerialNo(trx, docType, txnType)` for new header rows. Always call it inside a transaction.

### Uniqueness
Call `ensureUnique(trx, table, where, exclude, message)` before insert/update for business-key uniqueness (e.g., unique `userName`, `email`). See `src/repository/validators.js`.

### Logging
- `appLogger` (from `loggerMiddleware.appLogger`) writes to both stdout and `logs/app.log` via `pino.multistream`.
- `requestLogger` writes HTTP request logs to `logs/requests.log` only (no console).
- Use `appLogger` directly for application-level events. Do not use `console.*` in feature code.

## Developer workflows
- Install: `npm install`
- Run dev server: `npm run dev` (nodemon). API at `http://localhost:3000`.
- Run prod server: `npm start` or `npm run start:prod`.

### Migrations (run per stream — not `npm run migrate`)
| Stream | Run | Rollback |
|---|---|---|
| core | `npm run migrate:core` | `npm run migrate:rollback:core` |
| service | `npm run migrate:service` | `npm run migrate:rollback:service` |
| songBook | `npm run migrate:songBook` | `npm run migrate:rollback:songBook` |
| hrm | `npm run migrate:hrm` | `npm run migrate:rollback:hrm` |
| jolly-snap | `npm run migrate:jolly-snap` | `npm run migrate:rollback:jolly-snap` |

Migration files go in `database/migrations/<stream>/` with timestamp prefix `YYYYMMDDNNNNNN`.

## Environment variables
Configure in `.env` (see `.env.example`):
- `DB_CLIENT=sqlite3|mysql|pg`; for SQLite also `DB_FILENAME` (default `./database/service_plus.db`).
- For MySQL/Postgres: `DB_HOST`, `DB_PORT`, `DB_NAME`, `DB_USER`, `DB_PASSWORD`.
- `JWT_SECRET` — **required in production**; app throws on startup if missing.
- `JWT_EXPIRES_IN` — access token TTL (default `1h`).
- `REFRESH_TOKEN_DAYS` — refresh token TTL in days (default `7`).
- `SSL_KEY_PATH`, `SSL_CERT_PATH` — required for HTTPS in production.

## Adding a new feature
See `.github/chatmodes/createFeature.chatmode.md` for the full step-by-step guide. Summary:

1. **Migrations** — create the feature table and its `_history` table in the correct stream directory. Add a `conf_txnType` seed row if the feature uses serial numbers.
2. **Files** — create `src/features/<camelCaseName>/{routes.js,controller.js,repository.js,validation.js}`. Use `src/features/tenant/` as the reference for the validation split.
3. **Validation** — put the `update` and `delete` yup schemas in `validation.js` and import them in the controller. The file must import only `yup` and the validation helpers, never the repository or `database`.
4. **Register** — in `src/routes/index.js`, import with a camelCase variable and mount with `authenticate`:

```js
const thingRoutes = require('../features/thing/routes');
app.use('/api/thing', authenticate, thingRoutes);
```

## Reference implementations
| What | Where |
|---|---|
| Standard CRUD with audit history | `src/features/songBook/` |
| Separate validation file (schema split) | `src/features/tenant/validation.js` |
| Password hashing + uniqueness checks | `src/features/user/repository.js` |
| Auth flow (login / refresh / logout) | `src/features/auth/` |
| File uploads | `src/features/vehicleConfirmation/` |
| Reports (dynamic SQL switch) | `src/features/reports/` |
| `snapshotBefore` utility | `src/repository/auditHistory.js` |
| Serial number allocation | `src/repository/getNextSerialNo.js` |
