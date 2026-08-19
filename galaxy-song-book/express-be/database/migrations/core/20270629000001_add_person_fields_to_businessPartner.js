// Business partner person fields from the B01 spec. Photo and digital signature
// store the uploaded file name. Idempotent column adds.

const COLS = [
  ['nic', (t) => t.string('nic', 30)],
  ['preferredName', (t) => t.string('preferredName', 100)],
  ['fullName', (t) => t.string('fullName', 200)],
  ['empNo', (t) => t.string('empNo', 40)],
  ['photoPath', (t) => t.string('photoPath', 300)],
  ['digitalSignPath', (t) => t.string('digitalSignPath', 300)],
];

exports.up = async function (knex) {
  for (const [col, fn] of COLS) {
    const has = await knex.schema.hasColumn('mas_businessPartner', col);
    if (!has) await knex.schema.alterTable('mas_businessPartner', fn);
  }
};

exports.down = async function (knex) {
  for (const [col] of COLS) {
    const has = await knex.schema.hasColumn('mas_businessPartner', col);
    if (has) await knex.schema.alterTable('mas_businessPartner', (t) => t.dropColumn(col));
  }
};
