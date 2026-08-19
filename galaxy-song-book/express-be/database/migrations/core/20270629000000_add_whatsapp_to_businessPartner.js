// Adds WhatsApp ID to the business partner master. Other master-data fields from
// the petty cash spec (NIC, photo, digital sign, multi-state status) are future work.

exports.up = async function (knex) {
  const has = await knex.schema.hasColumn('mas_businessPartner', 'whatsappId');
  if (!has) {
    await knex.schema.alterTable('mas_businessPartner', (t) => {
      t.string('whatsappId', 50);
    });
  }
};

exports.down = async function (knex) {
  const has = await knex.schema.hasColumn('mas_businessPartner', 'whatsappId');
  if (has) {
    await knex.schema.alterTable('mas_businessPartner', (t) => {
      t.dropColumn('whatsappId');
    });
  }
};
