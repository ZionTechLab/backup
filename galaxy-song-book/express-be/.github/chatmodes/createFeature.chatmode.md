---
description: 'Custom chat mode for creating new features.'
tools: ['codebase', 'usages', 'vscodeAPI', 'problems', 'changes', 'testFailure', 'terminalSelection', 'terminalLastCommand', 'openSimpleBrowser', 'fetch', 'findTestFiles', 'searchResults', 'githubRepo', 'extensions', 'todos', 'editFiles', 'runNotebooks', 'search', 'new', 'runCommands', 'runTasks']
---
# Create New Feature Chat Mode

## 1 — Preparation

Ask the user for the following before generating anything:

| Required | Question |
|---|---|
| Feature name | camelCase (e.g. `salesOrder`, `stockItem`) |
| Table name | snake_case (e.g. `txn_salesOrder`) |
| Fields | name, type, required/optional |
| Migration stream | which knexfile env: `core`, `service`, `songBook`, `hrm`, `jolly-snap` |
| Serial numbers? | Does this feature use `getNextSerialNo`? If yes, what are `docType` and `txnType`? |
| Auth required? | Should routes be protected with `authenticate`? (default: yes) |

---

## 2 — Migrations

Create files in `database/migrations/<stream>/` using timestamp format `YYYYMMDDNNNNNN`.

### 2a — Feature table
```js
// <timestamp>_create_<table>.js
exports.up = function(knex) {
  return knex.schema.createTable('<table>', function(table) {
    table.integer('tenantId').unsigned();
    table.integer('companyId').unsigned();
    table.increments('index').primary();
    table.integer('id').notNullable();
    // ... user-defined fields ...
    table.boolean('active').notNullable().defaultTo(true);
    table.boolean('deleted').notNullable().defaultTo(false);
    table.integer('userId');
    table.dateTime('userDT');
  });
};
exports.down = function(knex) {
  return knex.schema.dropTable('<table>');
};
```

### 2b — History table
```js
// <timestamp+1>_create_<table>_history.js
exports.up = function(knex) {
  return knex.schema.createTable('<table>_history', function(table) {
    table.increments('historyId').primary();
    table.integer('id').notNullable();
    table.integer('changedBy');
    table.dateTime('changedAt').notNullable();
    table.string('changeType', 10).notNullable(); // 'INSERT' | 'UPDATE' | 'DELETE'
    table.text('snapshot').notNullable();          // full JSON row before change
    table.index('id');
  });
};
exports.down = function(knex) {
  return knex.schema.dropTable('<table>_history');
};
```

### 2c — Serial number seed (only if feature uses `getNextSerialNo`)
Add a seed row to `conf_txnType` with the feature's `docType` and `txnType`.

---

## 3 — Feature files

Create folder `src/features/<camelCaseName>/` with three files.
**Reference implementation: `src/features/songBook/`**

### repository.js

- Import `snapshotBefore` from `../../repository/auditHistory`
- Import `getNextSerialNo` from `../../repository/getNextSerialNo` (if serial numbers needed)
- **Never spread `...data.header`** into insert — pick fields explicitly
- **Never hardcode `userId: 0`** — use `data.userId`
- `update`: if `isUpdate`, call `snapshotBefore` then do a standard `.update()`. If new, call `getNextSerialNo` then `.insert()`
- `delete`: call `snapshotBefore` with `changeType = 'DELETE'`, then soft-delete with `.update({ deleted: true })`

```js
const db = require('../../database');
const { getNextSerialNo } = require('../../repository/getNextSerialNo');
const { snapshotBefore } = require('../../repository/auditHistory');

const repo = {
  async getUi() { /* dropdowns / reference data */ },

  async getAll(filters = {}) { /* list, always filter deleted=false */ },

  async get(filters = {}) { /* single record by id */ },

  async update(data) {
    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        await snapshotBefore(trx, '<table>', { id: data.id, deleted: false }, data.userId, 'UPDATE');
        await trx('<table>').where({ id: data.id, deleted: false }).update({
          // explicit field list only
          userId: data.userId,
          userDT: new Date(),
        });
        return trx('<table>').where({ id: data.id, deleted: false }).first();
      }
      const id = await getNextSerialNo(trx, '<docType>', '<txnType>');
      await trx('<table>').insert({
        tenantId:  data.tenantId  || 1,
        companyId: data.companyId || 1,
        id,
        // explicit field list only
        active:  true,
        deleted: false,
        userId:  data.userId,
        userDT:  new Date(),
      });
      return trx('<table>').where({ id, deleted: false }).first();
    });
  },

  async delete(data) {
    return db.transaction(async (trx) => {
      await snapshotBefore(trx, '<table>', { id: data.id, deleted: false }, data.userId, 'DELETE');
      await trx('<table>').where({ id: data.id, deleted: false }).update({
        deleted: true,
        userId:  data.userId,
        userDT:  new Date(),
      });
      return 'success';
    });
  },
};

module.exports = repo;
```

### controller.js

- All handlers wrapped with `asyncHandler`
- Throw `AppError` for not-found and validation errors
- Pass `req.user.sub` as `userId` into every repo call

```js
const repo = require('./repository');
const asyncHandler = require('../../middleware/asyncHandler');
const { AppError } = require('../../middleware/errorHandler');

exports.getUi    = asyncHandler(async (req, res) => { res.json(await repo.getUi()); });
exports.getAll   = asyncHandler(async (req, res) => { res.json(await repo.getAll(req.query)); });
exports.get      = asyncHandler(async (req, res) => {
  const record = await repo.get(req.query);
  if (!record) throw new AppError('Not found', 404);
  res.json(record);
});
exports.update   = asyncHandler(async (req, res) => {
  const record = await repo.update({ ...req.body, userId: req.user.sub });
  res.status(201).json(record);
});
exports.delete   = asyncHandler(async (req, res) => {
  await repo.delete({ ...req.body, userId: req.user.sub });
  res.json({ success: true });
});
```

### routes.js

- Add `#swagger.tags = ['<FeatureName>']` to every route
- Use correct, feature-specific swagger summaries (not copy-pasted from another feature)

```js
const express = require('express');
const router  = express.Router();
const Controller = require('./controller');

router.get('/get-ui',   (req, res, next) => Controller.getUi(req, res, next));
router.get('/get-all',  (req, res, next) => Controller.getAll(req, res, next));
router.get('/get',      (req, res, next) => Controller.get(req, res, next));
router.post('/update',  (req, res, next) => Controller.update(req, res, next));
router.post('/delete',  (req, res, next) => Controller.delete(req, res, next));

module.exports = router;
```

---

## 4 — Input Validation

Add a `yup` schema in the controller for `update` and `delete` inputs. Validate before calling the repo.

```js
const yup = require('yup');

const updateSchema = yup.object({
  isUpdate: yup.boolean().required(),
  id:       yup.number().when('isUpdate', { is: true, then: s => s.required() }),
  // ... feature fields ...
});

exports.update = asyncHandler(async (req, res) => {
  const data = await updateSchema.validate(req.body, { abortEarly: false, stripUnknown: true });
  const record = await repo.update({ ...data, userId: req.user.sub });
  res.status(201).json(record);
});
```

---

## 5 — Route Registration

In `src/routes/index.js`:

- Import using a **camelCase** variable name
- Mount with `authenticate` middleware (unless explicitly public)

```js
const <camelCaseName>Routes = require('../features/<camelCaseName>/routes');
// ...
app.use('/api/<kebab-case-name>', authenticate, <camelCaseName>Routes);
```

---

## Checklist before finishing

- [ ] Migration: feature table created
- [ ] Migration: history table created
- [ ] Seed: `conf_txnType` row added (if serial numbers used)
- [ ] Repository: no `...data.header` spread in insert
- [ ] Repository: no hardcoded `userId: 0`
- [ ] Repository: `snapshotBefore` used on update and delete
- [ ] Controller: `req.user.sub` passed as `userId`
- [ ] Controller: yup validation on update and delete
- [ ] Routes: swagger tags match the feature name
- [ ] `routes/index.js`: mounted with `authenticate`
