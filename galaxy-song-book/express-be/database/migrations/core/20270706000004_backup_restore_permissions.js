// Restore permissions. Unlike backup-export (auto-granted to each tenant's
// Full Access group, since export is read-only), restore is destructive —
// the chosen strategy wipes the target scope before reinserting — so both
// codes are seeded but deliberately left ungranted. An admin must assign
// them by hand via Permission Groups after weighing the risk.
//   backup-restore       — tenant/module scope, wipes only the current
//                          tenant+company's rows in the affected tables.
//   backup-restore-full  — whole database, wipes and replaces every table
//                          for every tenant. Platform-admin only.

exports.up = async function (knex) {
  const module = await knex('sec_module').where({ moduleCode: 'SECURITY' }).first();
  if (!module) return;
  const mx = await knex('sec_permission').max('sortOrder as m').first();
  let nextSort = (mx?.m ?? 0) + 1;

  for (const [code, name] of [
    ['backup-restore', 'Backup - Restore'],
    ['backup-restore-full', 'Backup - Restore Full Database'],
  ]) {
    const existing = await knex('sec_permission').where({ permCode: code }).first();
    if (!existing) {
      await knex('sec_permission').insert({ permCode: code, permName: name, moduleId: module.moduleId, sortOrder: nextSort++ });
    }
  }
};

exports.down = async function (knex) {
  for (const code of ['backup-restore', 'backup-restore-full']) {
    const perm = await knex('sec_permission').where({ permCode: code }).first();
    if (perm) {
      await knex('sec_permissionGroupDetail').where({ permId: perm.permId }).del();
      await knex('sec_permission').where({ permId: perm.permId }).del();
    }
  }
};
