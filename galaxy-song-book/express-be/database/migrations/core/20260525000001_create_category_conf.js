exports.up = function (knex) {
  return knex.schema.createTable("conf_category", function (table) {
    table.uuid("tenantId").notNullable().references("tenantId").inTable("sec_tenants");
    table.uuid("companyId").notNullable().references("companyId").inTable("sec_companies");
    table.integer("categoryType").notNullable();
    table.integer("parentCategoryType").notNullable();
    table.string("categoryTypeName").notNullable();
    table.integer("serialNo").notNullable();
    table.json("metaValue").notNullable();
    table.json("metaDesc").notNullable();
    table.json("ref1");
    table.json("ref2");
    table.json("ref3");
    table.json("ref4");
    table.json("ref5");
    table.integer("menuParentId").unsigned().defaultTo(0);
    table.string("icon");
    table.integer("order");
    table.boolean("isActive").notNullable().defaultTo(true);
    table.uuid("updatedBy").references("userId").inTable("mas_users");
    table.dateTime("updatedAt").defaultTo(knex.fn.now());
  });
};

exports.down = function (knex) {
  return knex.schema.dropTable("conf_category");
};
