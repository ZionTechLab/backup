// Seed petty cash document and transaction types so getNextSerialNo can issue
// docNo values. Inserts sec_docType + sec_txnType once, then conf_docType +
// conf_txnType per company. Idempotent on the sec_* rows.

const TYPES = [
  { docType: 'PCV',  txnType: 'PCV',  name: 'PC Payment Voucher' },
  { docType: 'PIOU', txnType: 'PIOU', name: 'PC IOU' },
  { docType: 'PSET', txnType: 'PSET', name: 'PC IOU Settlement' },
  { docType: 'PRPL', txnType: 'PRPL', name: 'PC Replenishment' },
  { docType: 'PCNT', txnType: 'PCNT', name: 'PC Cash Count' },
  { docType: 'PREQ', txnType: 'PREQ', name: 'IOU Request' },
];

exports.up = async function (knex) {
  for (const x of TYPES) {
    const d = await knex('sec_docType').where({ docType: x.docType }).first();
    if (!d) {
      await knex('sec_docType').insert({ docType: x.docType, docTypename: x.name, isActive: true });
    }
    const tt = await knex('sec_txnType').where({ docType: x.docType, txnType: x.txnType }).first();
    if (!tt) {
      await knex('sec_txnType').insert({ docType: x.docType, txnType: x.txnType, txnTypename: x.name, isActive: true });
    }
  }

  const companies = await knex('sec_companies').select('tenantId', 'companyId');
  for (const c of companies) {
    for (const x of TYPES) {
      const cd = await knex('conf_docType')
        .where({ companyId: c.companyId, docType: x.docType }).first();
      if (!cd) {
        await knex('conf_docType').insert({
          tenantId: c.tenantId, companyId: c.companyId, docType: x.docType, isActive: true,
        });
      }
      const ct = await knex('conf_txnType')
        .where({ companyId: c.companyId, docType: x.docType, txnType: x.txnType }).first();
      if (!ct) {
        await knex('conf_txnType').insert({
          tenantId: c.tenantId, companyId: c.companyId,
          docType: x.docType, txnType: x.txnType,
          serialNo: 0, isActive: true, isReport: false,
        });
      }
    }
  }
};

exports.down = async function (knex) {
  const docTypes = TYPES.map((x) => x.docType);
  await knex('conf_txnType').whereIn('docType', docTypes).del();
  await knex('conf_docType').whereIn('docType', docTypes).del();
  await knex('sec_txnType').whereIn('docType', docTypes).del();
  await knex('sec_docType').whereIn('docType', docTypes).del();
};
