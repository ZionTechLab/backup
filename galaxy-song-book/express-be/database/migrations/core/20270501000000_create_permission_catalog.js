// Permission (RBAC) catalog. Adds an action-level permission layer on top of the
// existing menu-grant model. Modules and permissions are app-global. Permission
// groups and their assignments are per tenant. Roles are keyed (tenantId, id),
// so role links carry tenantId. Menu grants (sec_userMenu) stay as-is for now.

exports.up = async function (knex) {
  // Global catalog: a feature area.
  await knex.schema.createTable('sec_module', function (t) {
    t.increments('moduleId').primary();
    t.string('moduleCode', 60).notNullable().unique();
    t.string('moduleName', 150).notNullable();
    t.integer('sortOrder').notNullable().defaultTo(0);
    t.boolean('isActive').notNullable().defaultTo(true);
    t.uuid('updatedBy').references('userId').inTable('mas_users');
    t.dateTime('updatedAt').defaultTo(knex.fn.now());
  });

  // Global catalog: one atomic capability. permCode is the kebab action string.
  await knex.schema.createTable('sec_permission', function (t) {
    t.increments('permId').primary();
    t.string('permCode', 80).notNullable().unique();
    t.string('permName', 150).notNullable();
    t.integer('moduleId').unsigned().notNullable().references('moduleId').inTable('sec_module');
    t.integer('sortOrder').notNullable().defaultTo(0);
    t.boolean('isActive').notNullable().defaultTo(true);
    t.uuid('updatedBy').references('userId').inTable('mas_users');
    t.dateTime('updatedAt').defaultTo(knex.fn.now());
  });

  // Per tenant: a reusable bundle of permissions.
  await knex.schema.createTable('sec_permissionGroup', function (t) {
    t.increments('permGroupId').primary();
    t.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    t.string('permGroupName', 150).notNullable();
    t.boolean('isActive').notNullable().defaultTo(true);
    t.boolean('deleted').notNullable().defaultTo(false);
    t.uuid('updatedBy').references('userId').inTable('mas_users');
    t.dateTime('updatedAt').defaultTo(knex.fn.now());
    t.unique(['tenantId', 'permGroupName']);
  });

  // The matrix. Presence of a row means the permission is granted in the group.
  await knex.schema.createTable('sec_permissionGroupDetail', function (t) {
    t.integer('permGroupId').unsigned().notNullable().references('permGroupId').inTable('sec_permissionGroup');
    t.integer('permId').unsigned().notNullable().references('permId').inTable('sec_permission');
    t.primary(['permGroupId', 'permId']);
  });

  // Per tenant: links a role to a permission group. roleId is ref_roles.id within
  // the tenant. No hard FK because ref_roles is keyed (tenantId, id), not by id.
  await knex.schema.createTable('sec_rolePermissionGroup', function (t) {
    t.uuid('tenantId').notNullable().references('tenantId').inTable('sec_tenants');
    t.integer('roleId').notNullable();
    t.integer('permGroupId').unsigned().notNullable().references('permGroupId').inTable('sec_permissionGroup');
    t.primary(['tenantId', 'roleId', 'permGroupId']);
    t.index(['tenantId', 'roleId']);
  });

  // Optional direct grant to a user, bypassing roles.
  await knex.schema.createTable('sec_userPermission', function (t) {
    t.uuid('userId').notNullable().references('userId').inTable('mas_users');
    t.integer('permId').unsigned().notNullable().references('permId').inTable('sec_permission');
    t.primary(['userId', 'permId']);
  });

  // Roles gain a stable code alongside the name.
  const hasRoleCode = await knex.schema.hasColumn('ref_roles', 'roleCode');
  if (!hasRoleCode) {
    await knex.schema.alterTable('ref_roles', function (t) {
      t.string('roleCode', 40);
    });
  }
};

exports.down = async function (knex) {
  await knex.schema.dropTableIfExists('sec_userPermission');
  await knex.schema.dropTableIfExists('sec_rolePermissionGroup');
  await knex.schema.dropTableIfExists('sec_permissionGroupDetail');
  await knex.schema.dropTableIfExists('sec_permissionGroup');
  await knex.schema.dropTableIfExists('sec_permission');
  await knex.schema.dropTableIfExists('sec_module');
  const hasRoleCode = await knex.schema.hasColumn('ref_roles', 'roleCode');
  if (hasRoleCode) {
    await knex.schema.alterTable('ref_roles', function (t) {
      t.dropColumn('roleCode');
    });
  }
};
