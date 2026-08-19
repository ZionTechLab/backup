# Pending Work — express-be

Tracked from full codebase review (2026-05-02). Items below were not fixed in the initial review pass.

---

## Before Next Deploy

### #3 — HTTP server runs alongside HTTPS in production (no redirect)
**File:** `src/app.js:96`

`app.listen(PORT, ...)` always runs unconditionally. In production, an HTTPS server also starts on port 443. This leaves plaintext HTTP open with no redirect to HTTPS.

**Fix:** In production mode, skip the HTTP listener or replace it with an HTTP→HTTPS redirect server.

```js
if (process.env.NODE_ENV === 'production') {
  // Redirect all HTTP to HTTPS
  http.createServer((req, res) => {
    res.writeHead(301, { Location: `https://${req.headers.host}${req.url}` });
    res.end();
  }).listen(PORT);
} else {
  app.listen(PORT, () => { ... });
}
```

---

### #5 — Mass assignment in insert calls
**Files:** `src/features/debtor/repository.js:93`, `src/features/user/repository.js:102`, `src/features/vehicleConfirmation/repository.js:71`

`...data.header` is spread directly into Knex `insert()` calls. A caller can inject arbitrary columns (`tenantId`, `companyId`, `deleted`, `roleId`, etc.).

```js
// Current — dangerous
await trx("ar_txn_debtorTXN").insert({ ...data.header, id, docType, txnType, ... });

// Fix — explicit field picks per table
await trx("ar_txn_debtorTXN").insert({
  id, docType, txnType,
  partner:     data.header.partner,
  txnDate:     data.header.txnDate,
  amount:      data.header.amount,
  // ... only the columns this endpoint should write
});
```

---

### #8 — SongBook update endpoint is publicly writable
**File:** `src/routes/index.js:72`

```js
app.use('/api/song-book', songRoutes); // no authenticate middleware
```

`POST /api/song-book/update` creates/overwrites songs without any authentication. Add `authenticate` unless public writes are intentional.

```js
app.use('/api/song-book', authenticate, songRoutes);
```

---

## Sprint

### #6 — No input validation (`yup` installed but unused)
**Files:** All controllers

Request bodies are passed raw to repositories. Missing required fields, wrong types, or oversized strings cause cryptic DB errors or silent null inserts.

**Fix:** Define a yup schema per endpoint and validate before hitting the DB.

```js
const schema = yup.object({
  userName: yup.string().required().max(100),
  password: yup.string().required().min(8),
  email:    yup.string().email().required(),
});
await schema.validate(req.body, { abortEarly: false, stripUnknown: true });
```

---

### #7 — JWT accepted via URL query string
**File:** `src/middleware/auth.js:42`

```js
if (!token && req.query && req.query.token) token = String(req.query.token).trim();
if (!token && req.body && req.body.token)  token = String(req.body.token).trim();
```

Tokens in URLs appear in server access logs, browser history, and `Referer` headers. Remove both fallbacks — the `Authorization: Bearer` header is sufficient.

---

### #10 — `userId: 0` hardcoded in all inserts — audit trail broken
**Files:** `src/features/debtor/repository.js:98`, `src/features/user/repository.js:105`, `src/features/vehicleConfirmation/repository.js:71`, `src/features/SongBook/repository.js:69`

Every record is written with `userId: 0`. The authenticated user (`req.user.sub`) is available in the controller but never forwarded to the repository.

**Fix:** Pass `userId` through as part of the write call.

```js
// controller.js
await repo.update({ ...req.body, userId: req.user.sub });

// repository.js
await trx("table").insert({ ...fields, userId: data.userId, userDT: new Date() });
```

---

## Backlog

### #14 — `require('crypto')` inside function body ✅ FIXED
**File:** `src/features/auth/controller.js`

`crypto` was required inside two exported handler functions. Moved to top-level import.

---

### #17 — No pagination on list endpoints
**Files:** All `getAll` methods across feature repositories

Most `getAll` queries return all rows with no limit. `vehicleConfirmation` has a hardcoded `LIMIT 100`. Any table that grows will degrade performance and payload size.

**Fix:** Add `limit`/`offset` query parameters with a safe default.

```js
// controller
const limit  = Math.min(Number(req.query.limit)  || 50, 200);
const offset = Number(req.query.offset) || 0;
await repo.getAll({ ...filters, limit, offset });

// repository
query.limit(filters.limit).offset(filters.offset);
```
