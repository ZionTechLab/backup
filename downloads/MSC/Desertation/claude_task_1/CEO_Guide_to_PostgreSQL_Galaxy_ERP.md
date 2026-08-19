# CEO's Guide to PostgreSQL — Galaxy ERP

*Prepared for: Founder/CTO, Galaxy ERP. Multi-tenant ERP (React/Node.js), migrating dev from MySQL to production PostgreSQL. DBA: Shanith (SQL Server background).*

---

## 1. PostgreSQL vs MySQL — The Hard Truth

**What bites you during migration (not syntax — operational surprises):**

- **Connections are expensive.** Postgres forks an OS process per connection (~5–10MB each, real context-switch cost). MySQL uses lightweight threads. If your Node app opens connections per-request the way it might against MySQL, Postgres will choke around a few hundred connections. You need a pooler (Section 5) from day one, not as an afterthought.
- **Identifier case folding.** Unquoted identifiers are lowercased automatically. If your Knex migrations or hand-written SQL used `CamelCase` column names without quotes, Postgres silently folds them to `camelcase` — and then your ORM's quoted references stop matching. Standardize on `snake_case` unquoted identifiers before you migrate.
- **Strict typing.** MySQL silently coerces types (`'5' + 3` just works). Postgres throws. Any code relying on implicit casts between strings, numbers, and dates will break on first contact.
- **GROUP BY strictness.** Postgres requires every non-aggregated selected column to appear in GROUP BY (or be functionally dependent on the primary key). MySQL's default mode lets you get away with sloppy queries. Audit reporting queries before cutover.
- **Case-sensitive text matching by default.** `LIKE` is case-sensitive; MySQL's default collation often isn't. Use `ILIKE` or a citext column where you actually want case-insensitivity.
- **DDL is transactional.** Schema changes in Postgres can be wrapped in a transaction and rolled back. This is a genuine advantage for Knex migrations — a failed migration doesn't leave you in a half-changed schema (with one big exception: `CREATE INDEX CONCURRENTLY`, which cannot run inside a transaction — see Section 7).

**What Postgres does that MySQL simply cannot:**

- **True transactional DDL** — roll back a bad schema migration like any other transaction.
- **Rich indexing beyond B-tree** — GIN for JSONB/arrays/full-text, GiST for ranges/geometry, BRIN for huge append-only tables. MySQL's index story is comparatively thin.
- **Native JSONB** with indexing and query operators — genuinely queryable semi-structured data, not just a text blob.
- **Row-Level Security (RLS)** — database-enforced per-row access policies, directly relevant to your multi-tenant decision (Section 2 and 7).
- **Extensibility** — `pg_stat_statements`, `pg_cron`, `postgis`, `pg_trgm`, custom types, all as first-class extensions.
- **Window functions and CTEs** matured earlier and more completely in Postgres; recursive CTEs are commonly used for BOM/hierarchy queries — relevant for ERP.

**What MySQL honestly does better:**

- **Lower operational floor.** Cheaper to run small, easier to find generalist hosting, smaller memory footprint out of the box.
- **Simpler replication story historically**, though this gap has narrowed with Postgres logical replication.
- **Faster for dead-simple read-heavy workloads** on constrained hardware, mostly because connections/threads are cheaper.

**ERP-specific example:** a multi-tenant SaaS ERP doing month-end close will run heavy reporting joins (GL, AP/AR, inventory valuation) alongside transactional writes. Postgres's query planner and richer join strategies (hash joins, better statistics-driven plans) generally handle this mixed workload better than MySQL once data volumes grow past a few million rows per tenant.

**PostgreSQL version to target:**

> **Target PostgreSQL 16 or 17.** Do not install anything older than 15. Several recommendations in this guide assume modern PG features (scram-sha-256, improved logical replication, `total_exec_time` in `pg_stat_statements`). Installing PG 10-12 will create subtle incompatibilities. Check your distribution: Ubuntu 24.04 ships PG 16; use `apt.postgresql.org` for the latest version regardless of OS.

> **CEO Summary — Do this:** Budget migration time for identifier casing, implicit-cast bugs, and GROUP BY strictness — these are the real migration bugs, not syntax. Put a connection pooler in front of Postgres before launch, not after you get paged.

---

## 2. Multi-Tenant Architecture — The Critical Decision

**Three models:**

| Model | Isolation | Ops overhead at 10–20 tenants | Backup/restore per tenant | Cross-tenant reporting |
|---|---|---|---|---|
| Row-level (`tenant_id` column, shared tables) | Weakest (app-bug = data leak) | Lowest — one schema, one migration | Hard — must filter every table | Easiest |
| Schema-per-tenant (same DB, N schemas) | Good | Moderate — migrations loop over N schemas | Easy — `pg_dump -n schema_name` | Requires cross-schema queries |
| Database-per-tenant | Strongest | Highest — N databases, N connection pools, N migration runs | Trivial — dump/restore whole DB | Hardest — needs FDW or ETL |

**Right call for Galaxy ERP at 2 tenants scaling to 10–20: schema-per-tenant.**

Why:

- You're an ERP handling financial data (PPS, PPE). Customers will eventually ask "can you export/restore just our data" — schema-per-tenant answers that with one `pg_dump -n`. Row-level can't do this cleanly; database-per-tenant is overkill at your scale.
- At 10–20 schemas, looping a Knex migration across tenants is a for-loop, not an engineering problem. That stops being true past ~100–200 schemas (catalog bloat: `pg_class`, `pg_attribute` etc. grow with schema × table count, and `pg_dump`/planner performance degrades).
- Schema boundaries give you real isolation without database-per-tenant's connection and resource multiplication. Each database needs its own connection pool allocation; 10–20 separate databases means 10–20 separate pools to size and monitor. Schemas share one pool.
- Row-level with RLS is the cheapest to operate but puts a single bug in a `WHERE tenant_id = ?` clause between you and a cross-tenant data leak — unacceptable risk for ERP financial data unless RLS is enforced as a hard backstop (see Section 7).

**Performance implications:** schema-per-tenant queries perform identically to a single-schema query once `search_path` is set — no extra join, no extra filter cost. Row-level adds a `WHERE` (or RLS policy check) to every query; usually cheap if indexed, but it's one more thing that must never be forgotten. Database-per-tenant has no query-time penalty but multiplies background process overhead (autovacuum workers, WAL, stats collector) per database.

**Security/isolation trade-off in plain terms:** schema-per-tenant means a compromised app credential scoped to one schema (via `GRANT` on that schema only) genuinely cannot read another tenant's tables — that's enforced by Postgres's permission system, not application code. That's the isolation guarantee row-level can't give you without RLS.

**Real-world pattern:** this is the same shape Salesforce (row-level, but at their scale it's the only option), Basecamp-style Rails multi-tenancy (often schema-per-tenant via `apartment` gem), and most mid-market B2B SaaS ERPs use schema-per-tenant specifically because it matches "you have dozens, not thousands, of tenants, and they're paying enough to expect real isolation."

> **CEO Summary — Do this:** Go schema-per-tenant now. Build the migration runner as a loop over `information_schema.schemata` from day one so it's not a rewrite at tenant #10. Revisit only if you cross ~100 tenants — cross that bridge with Citus or database-per-tenant then, not now.

---

## 3. Security Configuration — Don't Get Hacked

**Top 5 defaults to change:**

1. **Authentication method** — default `pg_hba.conf` entries often use `md5` or even `trust` for local connections. Change every remote entry to `scram-sha-256`.
2. **`listen_addresses`** — don't leave it at `*` on a public VPS without a firewall backing it. Bind to the private interface, or `*` only behind a security group/ufw rule that blocks 5432 from the internet.
3. **`pg_hba.conf` scope** — never use `0.0.0.0/0`. Scope entries to your app server's private IP/subnet and your admin VPN range only.
4. **SSL/TLS** — set `ssl = on`, require `sslmode=require` (ideally `verify-full` with a proper cert) on every client connection string.
5. **Least privilege roles** — stop connecting the app as `postgres` (superuser). Create a role per app service with `GRANT` only on the schemas/tables it needs. In schema-per-tenant, this pairs naturally: one role per tenant schema, or one shared app role with schema-scoped grants plus RLS as backstop.

**Locking down remote access on a public-facing VPS:**

- Don't expose port 5432 to the internet at all if you can avoid it. Put Postgres on a private network/VPC, reach it from the app tier only, and manage/admin access via SSH tunnel or a VPN (Tailscale/WireGuard), not direct public exposure.
- If you must expose it (e.g., no VPC), firewall it to specific IPs (`ufw allow from <app-ip> to any port 5432`) and enforce SCRAM + SSL as non-negotiable.
- Rate-limit and monitor failed auth attempts — `log_connections`/`log_disconnections` on, watch for brute-force patterns.

**Connection pooling — what and why:** a pool sits between your app and Postgres, reusing a small number of real database connections across many client requests instead of opening a new (expensive) Postgres process per request. Without it, a traffic spike or a leaked connection in your Node code can exhaust `max_connections` and take the whole app down. With 10–20 tenants and a handful of Node app instances, you need this — see Section 5 for PgBouncer specifics.

**Auth methods, plainly:**

- `trust` — no password check at all. Never use this except for local dev on a machine only you touch.
- `peer` — matches the OS user to the Postgres role. Local-socket only, not usable for your app's network connections.
- `md5` — password hash, but vulnerable to certain replay/interception patterns and being phased out. Fine as a fallback, not your default.
- `scram-sha-256` — the current standard (Postgres 10+), resistant to replay attacks. This is what you should be running everywhere in production. Node's `pg` driver and Knex both support it natively.

> **CEO Summary — Do this:** Never expose 5432 directly to the public internet. Force `scram-sha-256` + SSL, create per-service least-privilege roles, and get PgBouncer in front of Postgres before your first real traffic spike.

---

## 4. Backup & Disaster Recovery

**`mysqldump` equivalent:** `pg_dump` (single database, logical backup) and `pg_dumpall` (whole cluster including roles). For schema-per-tenant, `pg_dump -n <schema_name>` gives you a clean per-tenant backup — this is one of the concrete payoffs of the schema-per-tenant decision.

**WAL, for a CEO who codes:** every change to the database is first written to the Write-Ahead Log before it touches the actual data files — think of it as a flight recorder that logs every transaction sequentially before it's applied. Two things fall out of this: (1) if the server crashes mid-write, Postgres replays the WAL on restart to recover to a consistent state — you don't lose committed transactions; (2) if you archive WAL files continuously, you can replay them against an old base backup to reconstruct the database at any point in time between backups. That second property is Point-in-Time Recovery.

**When you need PITR:** when "restore last night's backup" isn't good enough — e.g., a bad migration or a bug wipes/corrupts data at 2:47pm and you need the database as it was at 2:46pm, not as it was at midnight. For an ERP holding financial transactions, this matters — a single bad `UPDATE` without a `WHERE` clause is the realistic failure mode PITR protects against.

**Realistic backup strategy for a 3-person team (not the "perfect" one):**

- Nightly `pg_dump -Fc` (custom compressed format, enables parallel restore with `pg_restore -j 4`) per schema/tenant, shipped off-box to S3/object storage immediately (don't just leave it on the same VPS).
- Enable continuous WAL archiving (`archive_mode = on`) with 7-day retention — this is your safety net for "oh no" moments between nightly dumps, and it's genuinely cheap to set up. For `archive_command`, use `wal-g` (recommended — actively maintained, supports S3/GCS/Azure) or `pgBackRest`. Do NOT attempt to write a custom shell script for WAL archiving — a bug in your archive script means silent data-loss risk. Install and test `wal-g` before enabling `archive_mode`.
- Test a restore quarterly. An untested backup is a belief, not a backup.
- Skip a hot standby/streaming replica until you have the budget or a compliance requirement forcing it — it adds real operational complexity (failover logic, split-brain risk) that a 3-person team shouldn't take on prematurely. Nightly dump + WAL archiving covers 95% of real-world disaster scenarios for your current scale.

> **CEO Summary — Do this:** Set up nightly per-tenant `pg_dump` to off-box storage plus WAL archiving this week — it's a few hours of work and it's the difference between "we lost a day" and "we lost nothing." Don't build a hot standby yet; it's not where your risk is at 10–20 tenants.

---

## 5. Performance — Make It Fast

**Index types for ERP data:**

- **B-tree (default):** use for primary keys, foreign keys, `tenant_id`, status/enum columns, date range filters (invoice date, period). This covers the vast majority of your ERP indexes.
- **GIN:** use on JSONB columns (custom fields, metadata blobs common in ERP configurability) and for full-text search on descriptions/notes. Also good for array columns.
- **GiST:** relevant if you ever add geospatial (delivery/warehouse locations) or range types (date ranges for contracts, fiscal periods). Skip it if you don't have that use case yet.

**Config parameters to tune from defaults (Postgres defaults are HDD-era):**

- **`shared_buffers`**: Set to 25% of system RAM (e.g., `4GB` on a 16GB VPS). This is Postgres's internal cache. The default (128MB) is tiny. Don't exceed 8GB on Linux — diminishing returns beyond that.
- **`work_mem`**: Memory per sort/hash operation per query. Default 4MB is too low for ERP reporting queries. Start at `16MB` and increase based on `EXPLAIN ANALYZE` output showing on-disk sorts. Be careful — this is per-operation, not per-query, and a single query can use many allocations.
- **`random_page_cost`**: Default 4.0 assumes spinning disk. On NVMe/SSD (which you have per §9), set to `1.1`. This tells the planner that random I/O is nearly as cheap as sequential, dramatically improving index usage decisions.

**Reading `EXPLAIN ANALYZE`:** read it inside-out, not top-down — the innermost/deepest nodes execute first. Look for: `Seq Scan` on a table with more than a few thousand rows (usually means a missing or unused index); a large gap between "estimated rows" and "actual rows" (means table statistics are stale — run `ANALYZE`); and whichever node has the highest `actual time` — that's your bottleneck, not the top-level total.

**VACUUM — what it is and why you can't ignore it:** Postgres's MVCC model means an `UPDATE` or `DELETE` doesn't overwrite a row in place — it marks the old version dead and writes a new one. VACUUM reclaims that dead space and updates the visibility map so the planner knows what's live. `autovacuum` does this automatically and should stay on. If you disable it or it falls behind on a hot table (audit logs, session tables, frequently-updated order/inventory rows), you get table bloat (queries scan far more pages than necessary, getting steadily slower) and, in the worst case, transaction ID wraparound — Postgres forces the database into a read-only state to protect data integrity until you vacuum. That's a self-inflicted outage. Never disable autovacuum; if a specific large table needs more aggressive settings, tune its `autovacuum_vacuum_scale_factor` per-table rather than turning it off.

**Connection pooling — PgBouncer vs "built-in":** Postgres has no built-in connection pooler comparable to PgBouncer. Some ORMs/drivers do app-instance-local pooling, but that doesn't help when you have multiple app instances all opening their own pools against the database — you still hit `max_connections` as you scale horizontally. PgBouncer sits in front of Postgres and multiplexes many client connections onto far fewer real backend connections. For a Node app (especially with autoscaling or serverless-style deployment), run PgBouncer in **transaction pooling mode** — it's the right default for typical short-lived ERP queries. Avoid transaction-mode pooling if you rely on session-level features like `SET search_path` per connection without re-setting it per transaction — for schema-per-tenant, make sure your app sets `search_path` (or fully qualifies schema names) per transaction, not assuming it persists across pooled connections.

> **CEO Summary — Do this:** Index `tenant_id`/status/date columns with B-tree by default, use GIN only where you have JSONB or full-text search. Never disable autovacuum. Run PgBouncer in transaction mode in front of every environment, including staging — catch pooling bugs before production.

---

## 6. Monitoring — Know Before Users Scream

**Metrics that matter most for an ERP workload:**

- Active connections vs `max_connections` (heading toward the ceiling = incident waiting to happen)
- Cache hit ratio (buffer cache hit rate should stay well above 99% for a well-sized instance; a drop signals you're outgrowing your RAM allocation)
- Autovacuum activity and table bloat % on your hottest tables
- Slow query count/rate (see below)
- Lock waits and deadlocks (ERPs with concurrent order/inventory updates are prone to these)
- Disk usage growth rate and free space
- Transaction ID age (early warning for wraparound risk — should never approach the autovacuum freeze threshold)

**`pg_stat_statements` — set it up:**

```sql
-- postgresql.conf: shared_preload_libraries = 'pg_stat_statements'  (requires restart)
CREATE EXTENSION IF NOT EXISTS pg_stat_statements;

-- worst offenders by total time:
SELECT query, calls, total_exec_time, mean_exec_time, rows
FROM pg_stat_statements
ORDER BY total_exec_time DESC
LIMIT 20;
```

This is your single best tool for finding "which query is actually killing us" instead of guessing.

**Slow query logging:** set `log_min_duration_statement = 1000` (milliseconds) to log every query taking over a second — tune the threshold down for OLTP-heavy ERP paths once you have a baseline. Ship these logs somewhere searchable (even a simple log aggregator); don't let them just sit in a file on the VPS.

**Two safety nets you must configure in `postgresql.conf`:**

- **`statement_timeout = 30000`** (30 seconds, tune for your workload). Automatically cancels any query exceeding the limit. Individual long-running reports can override with `SET statement_timeout = 0`. This is your first line of defense against runaway queries.
- **`idle_in_transaction_session_timeout = 60000`** (60 seconds). Kills connections stuck in an open transaction. Node.js apps are particularly prone to this — a forgotten `.commit()` or `.rollback()` leaves locks held and prevents autovacuum from cleaning up dead rows. Without this, table bloat accumulates silently and performance degrades over weeks.

**Alert thresholds that make sense for an ERP:**

- Connections > 80% of `max_connections`
- Disk > 80% full
- Any query on a transactional path (order entry, invoicing) exceeding ~2–5 seconds
- Autovacuum not completing within its expected window on large tables
- Replication lag > 30s (once you have a replica)
- Spike in failed login attempts (security signal, not just performance)

> **CEO Summary — Do this:** Enable `pg_stat_statements` and slow query logging this week — they're free and take an hour to set up. Alert on connection count and disk space first; those are what actually cause outages, not subtle query slowness. Set `statement_timeout` and `idle_in_transaction_session_timeout` — they're your seatbelt and airbag against runaway queries and silent table bloat.

---

## 7. PostgreSQL for Your Specific Stack

**Node.js: knex.js, `pg`, or Sequelize?** You already use Knex — stick with it. `pg` (node-postgres) is the low-level driver everything else is built on; Knex gives you a query builder plus migrations without full ORM magic, which is the right level of control for ERP-grade data integrity. Sequelize adds more abstraction and can generate inefficient queries (especially N+1 patterns and eager-loading joins) that are harder to spot and tune — avoid introducing it alongside Knex; pick one.

**Knex migration gotchas moving to Postgres:**

- `CREATE INDEX CONCURRENTLY` cannot run inside a transaction, but Knex wraps each migration in a transaction by default on Postgres. For any migration adding an index to a large live table, disable the transaction for that migration (`exports.config = { transaction: false }`) or you'll get a runtime error — and without `CONCURRENTLY`, a plain `CREATE INDEX` locks the table for writes for the duration.
- Explicitly specify `jsonb`, not `json`, for JSON columns (`table.jsonb(...)`) — `jsonb` is indexable and almost always what you want; the plain `json` type just stores text.
- Enum handling differs from MySQL — Knex creates a native Postgres `ENUM` type by default, which is more annoying to alter later (adding a value requires a separate `ALTER TYPE`) than a MySQL enum column. Consider a plain text column with a `CHECK` constraint instead if you expect enum values to change often (status fields in ERP definitely will).
- Timestamp defaults: `table.timestamps(true, true)` behaves slightly differently across DBs — verify it's using `timestamptz` (timezone-aware), not `timestamp`, especially since a multi-company ERP will eventually have tenants in different timezones.
- If a migration fails partway, Knex's migration lock table (`knex_migrations_lock`) can be left locked — you'll need to manually clear it before retrying.

**UUID vs SERIAL for primary keys in multi-tenant:** don't treat this as binary. Recommended hybrid for Galaxy ERP: keep `BIGSERIAL`/`IDENTITY` as the internal primary key (compact, sequential, fast for joins and indexes), and add a separate indexed `UUID` column as the external/public identifier used in APIs and URLs. Reasons: sequential integer PKs keep indexes small and insert-friendly; random UUIDv4 as a primary key causes index page-split fragmentation under write load. But a public integer ID leaks record counts and order-of-creation to competitors/customers browsing your API (`/invoices/1042` tells them a lot) — the UUID solves that without sacrificing internal performance. If you later consolidate tenant schemas or migrate data between environments, UUIDs also avoid ID collisions that plain integers would create.

**Row-Level Security — is this the answer to multi-tenant?** Not the *primary* answer for you, but a valuable second layer. With schema-per-tenant as your primary isolation boundary, RLS isn't required to prevent cross-tenant leaks — the schema boundary already does that at the permission-system level. Where RLS earns its keep: (1) as defense-in-depth inside a schema if you ever add shared/reference tables, or (2) if you ever introduce a row-level "global" table shared across tenants (e.g., a shared product catalog with tenant-specific overrides). Don't reach for RLS as a substitute for the schema decision — it's a supplement, and it adds real complexity (every pooled connection must correctly `SET` the session's tenant context before every query, and a missed `SET` is its own class of bug).

> **CEO Summary — Do this:** Stay on Knex, disable transactions for concurrent-index migrations, use `jsonb` not `json`, and use text+`CHECK` instead of native enums for anything like status fields. Use BIGSERIAL internally with a UUID public identifier. Treat RLS as a future defense-in-depth layer, not your multi-tenant strategy.

---

## 8. The Operational Reality

**What actually breaks first (not the textbook answer):** connection exhaustion under a traffic spike, because Postgres's per-connection cost gets forgotten until the day it matters. Close behind: a migration that locks a large live table during business hours because someone forgot `CONCURRENTLY`; and autovacuum quietly falling behind on a hot table (audit log, session table, or an inventory table getting hammered by updates) until query latency creeps up over weeks and nobody notices until it's bad.

**Major version upgrades — painful or smooth?** For a database your current size, `pg_upgrade` with `--link` mode is fast (minutes, not hours) and the standard path — but it requires a maintenance window and you should always test it against a staging copy first, including checking that every extension you use (`pg_stat_statements`, `uuid-ossp`, etc.) has a compatible version for the target release.

> **⚠ `--link` is irreversible.** It uses hard links, meaning the old cluster's data files are shared with and modified by the new cluster. If the upgrade fails, you cannot restart the old version — you must restore from backup. Always take a full backup immediately before running `pg_upgrade --link`. If you need a safe rollback path, use `--clone` mode instead (copies files, slower but safe).

As you grow, logical replication (built into Postgres since v10) enables near-zero-downtime upgrades by replicating to a new-version instance and cutting over — worth planning for once downtime windows become unacceptable, not needed yet.

**What Shanith needs to unlearn from SQL Server:**

- No clustered index by default — Postgres tables are heap-organized; physical row order isn't automatically maintained by the primary key the way SQL Server's clustered index works. `CLUSTER` exists but is a one-time manual operation, not continuously maintained.
- No SQL Agent — scheduled jobs need `pg_cron` (extension) or external cron/systemd timers.
- Backup mental model is different — no `.bak` full/differential/log the SQL Server way. It's logical (`pg_dump`) plus physical WAL archiving, combined for the equivalent of SQL Server's recovery model.
- MVCC vs SQL Server's locking model (even with RCSI) behaves differently under concurrent writes — expect different deadlock and blocking patterns than SQL Server produced.
- Stored procedure culture is much lighter in Postgres shops than SQL Server shops — PL/pgSQL exists and is fully capable, but most Postgres app logic lives in the app layer, not the database, which will feel unfamiliar coming from an SQL Server-centric shop.
- Terminology: `IDENTITY`/`SERIAL`/sequences map roughly to SQL Server's `IDENTITY`, but the underlying sequence object is separate and directly queryable/alterable — worth the 20 minutes to understand `pg_sequences`.

**Common Postgres traps for MySQL developers:** assuming implicit type coercion works like MySQL (it doesn't — Postgres errors instead of guessing); assuming unquoted identifiers preserve case (they're folded to lowercase); forgetting that DDL is transactional and can be part of a larger transaction (this is a feature, but it surprises people who expect DDL to auto-commit); forgetting `ANALYZE` after large bulk loads, leaving the planner working off stale statistics; and underestimating how much connection overhead matters at scale.

> **CEO Summary — Do this:** Have Shanith read up specifically on MVCC/autovacuum and `pg_cron` before go-live — those are the two biggest mental-model gaps coming from SQL Server. Rehearse a `pg_upgrade` on staging before your first major version bump in production.

---

## 9. Cost & Scale

**When does Postgres get expensive?** The license is free — cost shows up as compute/storage/backup infrastructure and, more importantly, your team's operational time. Self-hosting is cheap in dollars and expensive in attention: patching, backup verification, monitoring, and incident response all fall on Shanith and you. That "cost" becomes real the first time something breaks at 2am with nobody covering it.

**Self-hosted VPS sizing for 10 tenants, 50 users (ERP workload):** start around 4–8 vCPUs, 16–32GB RAM, NVMe/SSD storage with 200–500GB depending on document/attachment retention, and budget storage headroom for backups (backups roughly double your effective storage need if kept on the same provider). This is a reasonable range for an ERP with moderate reporting load — revisit sizing once you have real `pg_stat_statements` data rather than guessing further.

**When you outgrow a VPS and need managed Postgres:** the trigger isn't a specific tenant count, it's when any of these becomes true — you need real HA (automatic failover, not "someone reruns a restore script"), you need push-button PITR instead of a manual WAL replay process, compliance requirements demand audited encryption/access controls you don't want to build yourself, or your 3-person team's time is better spent on product than on database operations. For most companies your size, that inflection point lands somewhere between 20–50 tenants or the first time you sign a customer contract with an uptime SLA you can't credibly self-host against. At that point, RDS/Cloud SQL/Crunchy Bridge trade a real cost premium for taking failover, patching, and backup verification off your plate.

> **CEO Summary — Do this:** Stay self-hosted on a right-sized VPS through 10–20 tenants; it's the cheaper and faster path while you're small. Start pricing managed Postgres options once you sign your first SLA-bound enterprise contract — don't wait for an outage to force the decision.

---

## 10. One-Page Quick Reference

**Top 10 `psql` commands you'll use daily**

```
\l              list databases
\c dbname       connect to a database
\dn             list schemas
\dt             list tables in current schema/search_path
\d tablename    describe a table (columns, indexes, constraints)
\du             list roles/users and their attributes
\x              toggle expanded (vertical) output — great for wide rows
\timing         toggle query execution timing
\i file.sql     run a SQL script file
\q              quit
```

**Config file locations**

- Debian/Ubuntu: `/etc/postgresql/<version>/main/postgresql.conf` and `pg_hba.conf` in the same directory
- RHEL/CentOS: `/var/lib/pgsql/<version>/data/postgresql.conf` and `pg_hba.conf`
- Confirm on your box: `SHOW config_file;` and `SHOW hba_file;` from inside `psql`

**Restart/reload without downtime**

- Most `pg_hba.conf` changes and many `postgresql.conf` settings: `SELECT pg_reload_conf();` (or `pg_ctl reload`) — no downtime, no dropped connections.
- Settings requiring a full restart (e.g., `shared_buffers`, `max_connections`): these need a real restart and brief downtime — schedule a maintenance window.

**Kill a runaway query**

```sql
-- find it
SELECT pid, now() - query_start AS duration, state, query
FROM pg_stat_activity
WHERE state = 'active'
ORDER BY duration DESC;

-- graceful cancel (like Ctrl+C)
SELECT pg_cancel_backend(<pid>);

-- forceful kill if cancel doesn't work
SELECT pg_terminate_backend(<pid>);
```

---

## Decision Log

| Decision | Options Considered | Chosen | Why | Trade-off |
|---|---|---|---|---|
| Multi-tenant architecture | Row-level (`tenant_id`), Schema-per-tenant, Database-per-tenant | **Schema-per-tenant** | Balances real isolation with manageable ops overhead at 10–20 tenants; enables clean per-tenant backup/restore, which ERP customers will ask for | Migrations must loop across N schemas; catalog bloat becomes a real concern past ~100–200 schemas |
| Authentication method | trust, peer, md5, scram-sha-256 | **scram-sha-256** | Current secure standard, resistant to replay attacks, supported natively by `pg`/Knex | Requires Postgres 10+ and modern client drivers (already satisfied) |
| Primary key strategy | Plain SERIAL, Plain UUID, BIGSERIAL + external UUID | **BIGSERIAL internal + UUID external** | Internal PK stays compact and index-friendly; external UUID avoids leaking record counts/order and simplifies future data consolidation | Two ID columns per table to maintain and document |
| Connection handling | App-side pooling only, PgBouncer in front of Postgres | **PgBouncer (transaction pooling mode)** | Postgres connections are expensive; a shared pooler prevents connection exhaustion as app instances scale | One more piece of infrastructure to run, monitor, and understand (`search_path` must be set per-transaction) |
| Backup strategy | Full HA standby, logical dump only, dump + WAL archiving | **Nightly per-tenant `pg_dump` + continuous WAL archiving** | Realistic for a 3-person team; gives point-in-time recovery without the operational load of a hot standby | Recovery time is tens of minutes, not seconds; no automatic failover |
| Row-Level Security | RLS as primary isolation, RLS as defense-in-depth, no RLS | **Defense-in-depth only, not primary isolation** | Schema boundary already provides strong isolation; RLS adds complexity better spent later on shared/reference tables | Deferred protection layer — revisit if a shared cross-tenant table is ever introduced |
| Hosting | Self-hosted VPS, Managed Postgres (RDS/Cloud SQL/Crunchy) | **Self-hosted VPS through ~20 tenants** | Lower cost while team and tenant count are small; team can absorb the operational load at this scale | Revisit at first SLA-bound enterprise contract or once ops burden exceeds available team time |
