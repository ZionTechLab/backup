// Company fb4f3be2 (companyCode 'PPE', "POLY PACKAGING EXPORTS") was at some
// point reassigned from the "demo" tenant to its real tenant ("MR. K.
// BALAKUMAR" / 30447eab-...) via sec_companies.tenantId — but every other
// table scoped by (tenantId, companyId) still carried the old "demo"
// tenantId for this company's rows, orphaning them. Symptoms: the drawer
// menu came back empty (sec_menu/sec_userMenu), and permissions resolved
// against demo's generic role/permission-group setup instead of this
// tenant's own custom approval groups (mas_userRoles).
//
// Fix: for every table with both a tenantId and companyId column, update
// tenantId -> the company's real tenant wherever companyId matches and
// tenantId is still the stale one. Scoped precisely to this one company,
// so demo's other companies (PPS, PPE-the-original, ZZ Test) are untouched.
//
// NOTE: already applied to the live database (batch 4) before this file was
// unexpectedly removed from disk by an external process; recreated verbatim
// so knex's migration-integrity check (which requires every tracked
// filename to exist) stops blocking further migrations. up()/down() are
// idempotent either way.

const STALE_TENANT_ID = 'f935c818-7f81-11f1-9eaa-0200170168d9'; // demo
const CORRECT_TENANT_ID = '30447eab-a8c4-43c5-b370-23972a70cd17'; // MR. K. BALAKUMAR
const TARGET_COMPANY_ID = 'fb4f3be2-7f81-11f1-9eaa-0200170168d9'; // POLY PACKAGING EXPORTS
const TARGET_GROUP_ID = '29993ae2-d28b-4336-abbd-017f4843ce71'; // POLY PACKAGING GROUP OF COMPANIES (PPG)

// mas_userRoles.tenantId is FK'd to ref_roles(tenantId, id) — the target
// tenant has zero ref_roles rows, so reassigning mas_userRoles would violate
// that constraint until these exist. Mirrors demo's own role set/ids.
const ROLES = [
  { id: 1, roleName: 'Admin', roleCode: 'ADMIN' },
  { id: 2, roleName: 'User', roleCode: 'USER' },
  { id: 3, roleName: 'Guest', roleCode: 'GUEST' },
  { id: 4, roleName: 'Supper Admin', roleCode: 'SUP-ADM' },
];

// mas_userRoles must come after ref_roles exists for the target tenant.
const TABLES = [
  'sec_menu', 'sec_userMenu', 'ref_category', 'mas_orgUnit',
  'wf_levelConfig', 'gl_transactionDetail', 'gl_financialMonths', 'gl_transactions',
  'conf_docType', 'conf_txnType', 'gl_centers', 'pc_ref_param',
  'pc_ref_expenseCategory', 'gl_companies', 'pc_mas_cashBook',
  'mas_userRoles',
];

exports.up = async function (knex) {
  const counts = {};
  await knex.transaction(async (trx) => {
    for (const r of ROLES) {
      const existing = await trx('ref_roles').where({ tenantId: CORRECT_TENANT_ID, id: r.id }).first();
      if (!existing) {
        await trx('ref_roles').insert({
          tenantId: CORRECT_TENANT_ID, groupId: TARGET_GROUP_ID, id: r.id,
          roleName: r.roleName, roleCode: r.roleCode, isActive: true, isDeleted: false,
        });
      }
    }

    // gl_*/pc_* tables live in separate migration streams (gl, petycash).
    // On the live DB all three streams have long since run, so every table
    // here already exists — but a from-scratch bootstrap runs `core` to
    // completion before `gl`/`petycash` even start, so those tables don't
    // exist yet at this point in that sequence. Skip whatever isn't there
    // yet; a fresh environment has nothing stale to fix anyway.
    for (const table of TABLES) {
      if (!(await trx.schema.hasTable(table))) { counts[table] = 'skipped (table not created yet)'; continue; }
      const updated = await trx(table)
        .where({ companyId: TARGET_COMPANY_ID, tenantId: STALE_TENANT_ID })
        .update({ tenantId: CORRECT_TENANT_ID });
      counts[table] = updated;
    }
  });
  // eslint-disable-next-line no-console
  console.log('fix_stale_tenant_refs: rows updated per table:', counts);
};

exports.down = async function (knex) {
  await knex.transaction(async (trx) => {
    for (const table of [...TABLES].reverse()) {
      if (!(await trx.schema.hasTable(table))) continue;
      await trx(table)
        .where({ companyId: TARGET_COMPANY_ID, tenantId: CORRECT_TENANT_ID })
        .update({ tenantId: STALE_TENANT_ID });
    }
    // Roles are left in place on rollback — other rows may have come to
    // depend on them since, and demo's own ref_roles are untouched either way.
  });
};
