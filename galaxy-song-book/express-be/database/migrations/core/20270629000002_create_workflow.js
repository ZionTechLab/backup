// Minimal centralized approval workflow. Config-driven levels per transaction
// type, a current-state row per document, and an action log. Any feature plugs
// in by docType + docId. No per-document next-person field; routing comes from
// the level config.

exports.up = async function (knex) {
  // Config: ordered approval levels per transaction type, with an optional band.
  await knex.schema.createTable('wf_levelConfig', function (t) {
    t.uuid('levelId').primary().defaultTo(knex.fn.uuid());
    t.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    t.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
    t.string('docType', 20).notNullable();
    t.integer('levelNo').notNullable();
    t.string('levelName', 100).notNullable();
    t.string('approverFunction', 80).notNullable();
    t.decimal('minAmount', 18, 2);
    t.decimal('maxAmount', 18, 2);
    t.boolean('isActive').notNullable().defaultTo(true);
    t.boolean('deleted').notNullable().defaultTo(false);
    t.uuid('updatedBy').references('userId').inTable('mas_users');
    t.dateTime('updatedAt').defaultTo(knex.fn.now());
    t.unique(['companyId', 'docType', 'levelNo']);
  });

  // Current position of a document in its approval flow.
  await knex.schema.createTable('wf_approvalState', function (t) {
    t.string('docType', 20).notNullable();
    t.string('docId', 64).notNullable();
    t.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    t.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
    t.integer('currentLevel').notNullable().defaultTo(1);
    t.string('status', 20).notNullable().defaultTo('Pending');
    t.dateTime('updatedAt').defaultTo(knex.fn.now());
    t.primary(['docType', 'docId']);
    t.index(['status', 'currentLevel']);
  });

  // History of actions across all transaction types.
  await knex.schema.createTable('wf_approvalLog', function (t) {
    t.uuid('logId').primary().defaultTo(knex.fn.uuid());
    t.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    t.uuid('companyId').notNullable().references('companyId').inTable('sec_companies');
    t.string('docType', 20).notNullable();
    t.string('docId', 64).notNullable();
    t.integer('levelNo').notNullable();
    t.string('action', 20).notNullable();
    t.uuid('actorUserId').references('userId').inTable('mas_users');
    t.string('comment', 500);
    t.date('onHoldUntil');
    t.dateTime('actedAt').defaultTo(knex.fn.now());
    t.index(['docType', 'docId']);
  });
};

exports.down = async function (knex) {
  await knex.schema.dropTableIfExists('wf_approvalLog');
  await knex.schema.dropTableIfExists('wf_approvalState');
  await knex.schema.dropTableIfExists('wf_levelConfig');
};
