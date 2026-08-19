// Seed BLOCK_MULTIPLE_IOU parameter — toggles the "one pending IOU per person" rule.
// paramGroup: IOU_LIMIT, paramKey: BLOCK_MULTIPLE, numValue: 1 = enabled / 0 = disabled.
// Idempotent — skips if already present.

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
    .where({ companyId: scope.companyId, paramGroup: 'IOU_LIMIT', paramKey: 'BLOCK_MULTIPLE', deleted: false })
    .first();
  if (exists) return;

  await knex('pc_ref_param').insert({
    paramId: crypto.randomUUID(),
    tenantId: scope.tenantId,
    companyId: scope.companyId,
    paramGroup: 'IOU_LIMIT',
    paramKey: 'BLOCK_MULTIPLE',
    numValue: 1,
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
    .where({ companyId: scope.companyId, paramGroup: 'IOU_LIMIT', paramKey: 'BLOCK_MULTIPLE' })
    .del();
};
