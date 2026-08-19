exports.up = async function (knex) {
  await knex.schema.createTable('ims_mas_uom', (t) => {
    t.integer('id').notNullable();
    t.integer('tenantId').nullable();
    t.integer('companyId').nullable();
    t.string('uomCode', 50).notNullable();
    t.string('uomName', 100).notNullable();
    t.text('description').nullable();
    t.boolean('active').notNullable().defaultTo(true);
    t.boolean('deleted').notNullable().defaultTo(false);
    t.integer('updatedBy').nullable();
    t.datetime('updatedAt').nullable();
    t.primary(['id']);
  });

  // conf_txnType row so getNextSerialNo can allocate IDs
  await knex('conf_txnType').insert({ tenantId: 1, companyId: 1, docType: 'UOM', txnType: 'UOM', serialNo: 0, isActive: true, isReport: false });
};

exports.down = async function (knex) {
  await knex('conf_txnType').where({ docType: 'UOM', txnType: 'UOM' }).delete();
  await knex.schema.dropTableIfExists('ims_mas_uom');
};
