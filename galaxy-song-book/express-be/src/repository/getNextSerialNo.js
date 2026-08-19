async function getNextSerialNo(trx, docType, txnType) {
  const client = trx.client.config.client;

  // PostgreSQL: single atomic statement — no gap between increment and read
  if (client === 'pg' || client === 'postgresql') {
    const rows = await trx('conf_txnType')
      .where({ docType, txnType })
      .increment('serialNo', 1)
      .returning('serialNo');
    return rows[0].serialNo;
  }

  // MySQL / SQLite: UPDATE acquires a row-level exclusive lock so concurrent
  // transactions block on the UPDATE itself — the SELECT below reads the
  // post-increment value within the same transaction snapshot.
  await trx('conf_txnType').where({ docType, txnType }).increment('serialNo', 1);
  const row = await trx('conf_txnType').where({ docType, txnType }).select('serialNo').first();
  return row.serialNo;
}

module.exports = { getNextSerialNo };
