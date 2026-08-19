exports.up = function(knex) {
  return knex.schema.createTable('sec_tenants', function(table) {
    table.uuid('tenantId').primary().defaultTo(knex.fn.uuid());
    table.string('tenantName').notNullable();
    table.string('legalName');
    table.string('status').defaultTo('active');

    // Contact & Location
    table.string('email');
    table.string('phone');
    table.string('addressLine1');
    table.string('addressLine2');
    table.string('city');
    table.string('stateProvince');
    table.string('postalCode');
    table.string('country');
    table.uuid('updatedBy').references('userId').inTable('mas_users');
    table.dateTime('updatedAt').defaultTo(knex.fn.now());

    // Configuration
    // table.string('default_language').defaultTo('en');
    // table.integer('default_timezone')
    // table.string('currency_code').defaultTo('LKR');
    // table.string('theme').defaultTo('light');
    // table.string('logo_url');
    // table.string('custom_domain');

    // Security & Access
    // table.uuid('admin_user_id').references('user_id').inTable('users').onDelete('SET NULL');
    // table.string('auth_provider').defaultTo('local');
    // table.string('subscription_plan').defaultTo('free');
    // table.date('plan_expiry_date');
    // table.integer('max_users_allowed').defaultTo(10);

    // Billing & Usage
    // table.timestamp('created_at').defaultTo(knex.fn.now());
    // table.string('created_by');
    // table.timestamp('updated_at').defaultTo(knex.fn.now());
    // table.string('updated_by');
    // table.timestamp('last_login_at');
    // table.string('billing_cycle').defaultTo('monthly');
    // table.string('billing_status').defaultTo('unpaid');
    // table.timestamp('trial_ends_at');

    // Integration Hooks
    // table.string('external_system_id');
    // table.string('webhook_url');
    // table.string('api_key');
    // table.string('data_retention_policy');
  });
};

exports.down = function(knex) {
  return knex.schema.dropTableIfExists('sec_tenants');
};