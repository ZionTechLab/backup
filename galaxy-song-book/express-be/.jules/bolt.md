## 2026-06-02 - Sequential Queries
**Learning:** Found sequential db queries block execution of endpoints in `getUi` methods that load multiple lists from DB.
**Action:** Use `Promise.all` to fetch queries concurrently instead of sequentially whenever possible.
## 2024-05-15 - Concurrent Queries with Promise.all
**Learning:** Found sequential database reference data lookups (N+1 pattern) adding unnecessary round-trip latency in UI data loading paths.
**Action:** Always check `getUi` methods and similar data preparation blocks for sequential `await` calls that can be safely batched using `Promise.all`.

## Optimization: Bulk Insert instead of N+1 Queries
* **Date:** $(date +%Y-%m-%d)
* **Context:** `src/repository/glPosting.js` was running `await trx(DETAIL).insert(...)` inside a `for` loop over `details`.
* **Pattern / Anti-pattern:** N+1 Query pattern for inserts causes a round-trip delay to the database for each row inserted.
* **Correction:** Used `.map()` to build an array of row objects and passed the array directly to `await trx(DETAIL).insert(detailRows)`.
* **Result:** Total DB inserts reduced from N+1 down to 2, drastically reducing elapsed time for the function call.

## 2026-05-02 - Unauthenticated routes
**Anti-pattern:** Exposing modifying routes like `/update` or `/delete` publicly without authentication middleware.
**Learning:** Always ensure that modifying API routes have proper authentication, like an `authenticate` middleware, attached at the application routing level to prevent unauthorized writes.
