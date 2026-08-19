// Adds a one-time "establish float" mechanism to the cash book. A petty cash
// GL account must be funded before it reflects real cash: without an opening
// entry it starts at zero and goes negative as IOUs pay out, which is
// impossible for physical cash. This posts Dr Petty Cash / Cr Bank once per
// cash book and stamps the result on the master row.
//
// Adds:
//   pc_mas_cashBook.establishedFloat          amount funded
//   pc_mas_cashBook.establishGlTransactionId  the posted opening entry
//   pc_mas_cashBook.establishedAt             when it was funded
//   pc_mas_cashBook.establishedBy             who funded it
// Plus the PFLT doc/txn type so getNextSerialNo can number the entry.

const PFLT = { docType: 'PFLT', txnType: 'PFLT', name: 'PC Establish Float' };

exports.up = async function (knex) {
  await knex.schema.alterTable('pc_mas_cashBook', (t) => {
    t.decimal('establishedFloat', 18, 2);
    t.uuid('establishGlTransactionId').references('transactionId').inTable('gl_transactions');
    t.dateTime('establishedAt');
    t.uuid('establishedBy').references('userId').inTable('mas_users');
  });

  const d = await knex('sec_docType').where({ docType: PFLT.docType }).first();
  if (!d) {
    await knex('sec_docType').insert({ docType: PFLT.docType, docTypename: PFLT.name, isActive: true });
  }
  const tt = await knex('sec_txnType').where({ docType: PFLT.docType, txnType: PFLT.txnType }).first();
  if (!tt) {
    await knex('sec_txnType').insert({ docType: PFLT.docType, txnType: PFLT.txnType, txnTypename: PFLT.name, isActive: true });
  }

  const companies = await knex('sec_companies').select('tenantId', 'companyId');
  for (const c of companies) {
    const cd = await knex('conf_docType').where({ companyId: c.companyId, docType: PFLT.docType }).first();
    if (!cd) {
      await knex('conf_docType').insert({ tenantId: c.tenantId, companyId: c.companyId, docType: PFLT.docType, isActive: true });
    }
    const ct = await knex('conf_txnType').where({ companyId: c.companyId, docType: PFLT.docType, txnType: PFLT.txnType }).first();
    if (!ct) {
      await knex('conf_txnType').insert({
        tenantId: c.tenantId, companyId: c.companyId,
        docType: PFLT.docType, txnType: PFLT.txnType,
        serialNo: 0, isActive: true, isReport: false,
      });
    }
  }
};

exports.down = async function (knex) {
  await knex.schema.alterTable('pc_mas_cashBook', (t) => {
    t.dropColumn('establishedFloat');
    t.dropColumn('establishGlTransactionId');
    t.dropColumn('establishedAt');
    t.dropColumn('establishedBy');
  });
  await knex('conf_txnType').where({ docType: PFLT.docType }).del();
  await knex('conf_docType').where({ docType: PFLT.docType }).del();
  await knex('sec_txnType').where({ docType: PFLT.docType }).del();
  await knex('sec_docType').where({ docType: PFLT.docType }).del();
};
