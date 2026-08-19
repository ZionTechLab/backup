// Persist each financial month's start/end date. Backfills existing rows with
// calendar-month boundaries derived from fnYear/fnMonth.
exports.up = async function(knex) {
  await knex.schema.alterTable('gl_financialMonths', (t) => {
    t.date('startDate');
    t.date('endDate');
  });

  const pad = (n) => String(n).padStart(2, '0');
  const rows = await knex('gl_financialMonths').select('companyId', 'fnYear', 'fnMonth');
  for (const r of rows) {
    const lastDay = new Date(r.fnYear, r.fnMonth, 0).getDate();
    await knex('gl_financialMonths')
      .where({ companyId: r.companyId, fnYear: r.fnYear, fnMonth: r.fnMonth })
      .update({
        startDate: `${r.fnYear}-${pad(r.fnMonth)}-01`,
        endDate:   `${r.fnYear}-${pad(r.fnMonth)}-${pad(lastDay)}`,
      });
  }
};

exports.down = async function(knex) {
  await knex.schema.alterTable('gl_financialMonths', (t) => {
    t.dropColumn('startDate');
    t.dropColumn('endDate');
  });
};
