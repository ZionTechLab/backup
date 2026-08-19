# Backup & Restore

Backup and restore live under **Settings > Backup** in the drawer. The screen has two tabs — Export and Restore.

## Permissions

You need at least one of these to see the screen:

- **Export** (`backup-export`) — download backups for your tenant or selected modules
- **Full Database Export** (`backup-export-full`) — download a complete unfiltered database dump
- **Restore** (`backup-restore`) — restore backups scoped to your tenant or selected modules
- **Full Database Restore** (`backup-restore-full`) — restore across every tenant

The Restore tab only appears if you hold a restore permission.

## Export

![Backup Export screen](/help/images/backup-export.svg)

Pick a scope, optionally narrow by module, then click **Export**. A `.zip` file downloads to your browser.

### Scopes

| Scope | What You Get |
|---|---|
| **This Tenant** | Every registered table filtered to your tenant and company |
| **Selected Module(s)** | Only the tables belonging to the modules you pick |
| **Full Database** | Every table, every tenant, unfiltered — requires the Full Database Export permission |

When you choose **Selected Module(s)**, a list of exportable modules appears with a table count next to each name. You must pick at least one module before the Export button will work.

Full Database exports show an extra confirmation dialog before proceeding.

## Restore

Restoring replaces live data — use it carefully.

### Step by step

1. Choose a backup `.zip` file
2. Pick the scope you want to restore into (same options as Export)
3. Click **Preview** to inspect what is inside the file
4. Review the preview table — it shows every table the backup will touch, how many rows are currently in the database, and how many are in the backup file
5. Click **Confirm Restore** to apply

![Restore preview with table comparison](/help/images/backup-restore.svg)

### What the preview tells you

The preview grid shows three columns per table:

- **Table** — the database table name
- **Currently in DB** — how many rows exist right now
- **In Backup** — how many rows the backup file contains

Warnings appear above the grid if the backup file is missing tables that exist in the database, or vice versa.

### Safety snapshot

Before any restore runs, the system takes a safety snapshot of the current data. If something goes wrong, your administrator can recover from that snapshot.

### Important

- Restoring wipes the selected tables first, then inserts the backup's data
- A Full Database restore replaces data across every tenant — confirm carefully
- The Restore tab stays hidden unless you have a restore permission
