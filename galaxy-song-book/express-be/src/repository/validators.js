// Generic validation utilities for repositories

/**
 * Ensures that no existing row matches the given where clause, optionally excluding a record.
 * Throws an Error with statusCode when a duplicate is found.
 *
 * @param {import('knex')} trxOrDb - Knex transaction or db instance
 * @param {string} table - Table name
 * @param {object} where - Column/value pairs to match for uniqueness
 * @param {object} [exclude] - Column/value pairs to exclude (e.g., { id })
 * @param {string} [message] - Error message when duplicate exists
 * @param {number} [statusCode] - HTTP status code for error
 * @param {object} [extraFilters] - Additional filters, defaults to { deleted: false }
 */
async function ensureUnique(
 
  trxOrDb,
  table,
  where,
  exclude = {},
  message = "Resource already exists.",
  statusCode = 409,
  extraFilters = { deleted: false }
) {
  const query = trxOrDb(table).where({ ...extraFilters, ...where });

  if (exclude && Object.keys(exclude).length) {
    query.whereNot(exclude);
  }

  const existing = await query.first();
  if (existing) {
    const err = new Error(message);
    err.statusCode = statusCode;
    throw err;
  }
}

module.exports = { ensureUnique };
