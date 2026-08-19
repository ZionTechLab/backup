// Data-integrity backfill. Several users have a company assignment
// (sec_userCompanies -> sec_companies.tenantId) whose tenant was never
// granted to them in sec_userTenants — e.g. admin's only company, POLY
// PACKAGING SERVICES, belongs to tenant "Poly Packaging Services", but
// admin's only sec_userTenants row is for the unrelated "demo" tenant.
//
// The frontend resolves its X-Tenant-Id header from the user's selected
// company, not from sec_userTenants directly, so this mismatch surfaces as
// "403 Forbidden: tenant not allowed" on any request once that company (or
// its tenant) is the active context — the membership row backing it was
// simply never created.
//
// This adds the missing membership (non-default, so nobody's existing
// default tenant selection changes) for every user affected, not just admin.

exports.up = async function (knex) {
  const gaps = await knex('sec_userCompanies as uc')
    .join('sec_companies as c', 'c.companyId', 'uc.companyId')
    .leftJoin('sec_userTenants as ut', function () {
      this.on('ut.userId', 'uc.userId').andOn('ut.tenantId', 'c.tenantId');
    })
    .whereNull('ut.id')
    .andWhere('uc.isDeleted', false)
    .select('uc.userId', 'c.tenantId')
    .distinct();

  const now = new Date();
  for (const gap of gaps) {
    await knex('sec_userTenants').insert({
      userId: gap.userId, tenantId: gap.tenantId,
      isDefault: 0, isActive: true, isDeleted: false,
      updatedBy: null, updatedAt: now,
    });
  }
};

exports.down = async function (knex) {
  // Not reversible in isolation — would require knowing exactly which rows
  // this migration itself inserted vs. pre-existing ones. Left as a no-op;
  // rolling back the affected companies/tenants (if ever needed) should
  // clean these up via their own FK cascade or a manual pass instead.
};
