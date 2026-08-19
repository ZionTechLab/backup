// Seed companies PPS & PPE plus org-unit hierarchy (Branch, Division,
// Department, Section) under each.
//
// Companies:
//   PPS — under demo tenant / Headquarters group
//   PPE — under demo tenant / Headquarters group
//
// Hierarchy per company:
//   Branch ELA (Elakanda)
//     Division OPS (Operations)
//       Department PROD (Production)
//         Section MIX (Mixing)
//         Section EXT (Extrusion)
//         Section PRT (Printing)
//       Department FAC (Factory)
//         Section GUS (Gusset)
//         Section CUT (Cutting)
//     Division ADM (Administration)
//   Branch HEN (Hendala)
//     Division OPS (Operations)
//       Department PROD (Production)
//         Section MIX (Mixing)
//         Section EXT (Extrusion)
//         Section PRT (Printing)
//       Department FAC (Factory)
//         Section GUS (Gusset)
//         Section CUT (Cutting)
//     Division ADM (Administration)

const crypto = require('crypto');

async function scopeFor(knex) {
  const tenant = await knex('sec_tenants').where({ tenantName: 'demo' }).first();
  if (!tenant) return null;
  return { tenantId: tenant.tenantId };
}

async function upsertUnit(knex, companyId, tenantId, unitType, code, name, parentId, updatedBy, now) {
  const existing = await knex('mas_orgUnit')
    .where({ companyId, unitType, code, deleted: false })
    .first();
  if (existing) return existing.orgUnitId;

  const orgUnitId = crypto.randomUUID();
  await knex('mas_orgUnit').insert({
    orgUnitId, tenantId, companyId,
    unitType, code, name, parentId,
    isActive: true, deleted: false,
    updatedBy, updatedAt: now,
  });
  return orgUnitId;
}

exports.up = async function (knex) {
  const scope = await scopeFor(knex);
  if (!scope) return;

  const group = await knex('sec_groups')
    .where({ tenantId: scope.tenantId, groupName: 'Headquarters' })
    .first();
  if (!group) return;

  const admin = await knex('mas_users').where({ userName: 'admin' }).first();
  const updatedBy = admin ? admin.userId : null;
  const now = new Date();

  const companies = [
    { code: 'PPS', name: 'PPS' },
    { code: 'PPE', name: 'PPE' },
  ];

  const branches = [
    { code: 'ELA', name: 'Elakanda' },
    { code: 'HEN', name: 'Hendala' },
  ];

  const divisions = [
    { code: 'OPS', name: 'Operations' },
    { code: 'ADM', name: 'Administration' },
  ];

  const departments = [
    { code: 'PROD', name: 'Production' },
    { code: 'FAC', name: 'Factory' },
  ];

  const sectionsByDept = {
    PROD: [
      { code: 'MIX', name: 'Mixing' },
      { code: 'EXT', name: 'Extrusion' },
      { code: 'PRT', name: 'Printing' },
    ],
    FAC: [
      { code: 'GUS', name: 'Gusset' },
      { code: 'CUT', name: 'Cutting' },
    ],
  };

  for (const c of companies) {
    let company = await knex('sec_companies')
      .where({ tenantId: scope.tenantId, companyCode: c.code })
      .first();

    if (!company) {
      const companyId = crypto.randomUUID();
      await knex('sec_companies').insert({
        companyId,
        tenantId: scope.tenantId,
        groupId: group.groupId,
        companyCode: c.code,
        companyName: c.name,
        legalName: c.name,
        registrationNumber: `REG-${c.code}`,
        addressLine1: '-',
        city: '-',
        country: '23',
        baseCurrencyCode: 'LKR',
        isActive: true,
      });
      company = { companyId, tenantId: scope.tenantId };
    }

    for (const b of branches) {
      const branchId = await upsertUnit(knex, company.companyId, scope.tenantId, 'Branch', b.code, b.name, null, updatedBy, now);

      for (const d of divisions) {
        const divId = await upsertUnit(knex, company.companyId, scope.tenantId, 'Division', d.code, d.name, branchId, updatedBy, now);

        for (const dept of departments) {
          const deptId = await upsertUnit(knex, company.companyId, scope.tenantId, 'Department', dept.code, dept.name, divId, updatedBy, now);

          const sections = sectionsByDept[dept.code] || [];
          for (const s of sections) {
            await upsertUnit(knex, company.companyId, scope.tenantId, 'Section', s.code, s.name, deptId, updatedBy, now);
          }
        }
      }
    }
  }
};

exports.down = async function (knex) {
  const companies = await knex('sec_companies')
    .whereIn('companyCode', ['PPS', 'PPE'])
    .select('companyId');
  const ids = companies.map(c => c.companyId);
  if (ids.length > 0) {
    await knex('mas_orgUnit').whereIn('companyId', ids).del();
  }
  await knex('sec_companies').whereIn('companyCode', ['PPS', 'PPE']).del();
};
