// Two cleanups:
// 1. Drops requesterUserId from pc_txn_iouRequest. It duplicated partyId
//    (who the request is for already identifies the person), added this same
//    session and never used in production, so it's removed rather than left
//    as dead data.
// 2. Renames the "IOU Advances" menu item to "IOU Issues", matching the
//    renamed IOU Advance -> IOU Issue screens.

async function scopeFor(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  if (!tenant) return null;
  const company = await knex('sec_companies')
    .where({ tenantId: tenant.tenantId, companyName: 'Demo Company' })
    .first();
  if (!company) return null;
  return { tenantId: tenant.tenantId, companyId: company.companyId };
}

exports.up = async function (knex) {
  if (knex.client.config.client === 'mysql') {
    await knex.raw('ALTER TABLE ?? DROP FOREIGN KEY ??', ['pc_txn_iouRequest', 'pc_txn_iourequest_requesteruserid_foreign']);
  }
  await knex.schema.alterTable('pc_txn_iouRequest', (t) => {
    t.dropColumn('requesterUserId');
  });

  const scope = await scopeFor(knex);
  if (scope) {
    await knex('sec_menu').where({ ...scope, id: 404 }).update({ displayName: 'IOU Issues' });
  }
};

exports.down = async function (knex) {
  await knex.schema.alterTable('pc_txn_iouRequest', (t) => {
    t.uuid('requesterUserId').references('userId').inTable('mas_users');
  });

  const scope = await scopeFor(knex);
  if (scope) {
    await knex('sec_menu').where({ ...scope, id: 404 }).update({ displayName: 'IOU Advances' });
  }
};
