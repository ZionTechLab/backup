// Seed REQUIRE_REQUEST parameter — toggles whether an IOU Advance can be
// created directly, or must originate from an Approved IOU Request.
// paramGroup: IOU_LIMIT, paramKey: REQUIRE_REQUEST, numValue: 1 = required / 0 = allowed.
// Default 0 preserves current behavior (direct creation allowed). Idempotent.

const crypto = require('crypto');

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
  const scope = await scopeFor(knex);
  if (!scope) return;

  const admin = await knex('mas_users').where({ userName: 'admin' }).first();
  const updatedBy = admin ? admin.userId : null;
  const now = new Date();

  const exists = await knex('pc_ref_param')
    .where({ companyId: scope.companyId, paramGroup: 'IOU_LIMIT', paramKey: 'REQUIRE_REQUEST', deleted: false })
    .first();
  if (exists) return;

  await knex('pc_ref_param').insert({
    paramId: crypto.randomUUID(),
    tenantId: scope.tenantId,
    companyId: scope.companyId,
    paramGroup: 'IOU_LIMIT',
    paramKey: 'REQUIRE_REQUEST',
    numValue: 0,
    isActive: true,
    deleted: false,
    updatedBy,
    updatedAt: now,
  });
};

exports.down = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;
  await knex('pc_ref_param')
    .where({ companyId: scope.companyId, paramGroup: 'IOU_LIMIT', paramKey: 'REQUIRE_REQUEST' })
    .del();
};
