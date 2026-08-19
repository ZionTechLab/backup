# Time Tracking — Azure DevOps Extension

A work-item-level time tracking extension for Azure DevOps. Users log time directly from the work item form; entries are stored per work item and automatically sync the **Completed Work** field. A cross-project report with cost-centre grouping is included.

---

## Table of Contents

1. [Features](#features)
2. [Architecture](#architecture)
3. [Tech Stack](#tech-stack)
4. [Project Structure](#project-structure)
5. [Data Model](#data-model)
6. [Storage](#storage)
7. [Installation](#installation)
8. [Development Setup](#development-setup)
9. [Build & Package](#build--package)
10. [Utility Scripts](#utility-scripts)
11. [Extension Contributions](#extension-contributions)

---

## Features

### Work Item Form — Time Tracker panel
- Log time entries against any work item (date, hours, task type, notes)
- All users can view all entries; only the entry owner can edit or delete
- Soft delete — entries are never physically removed (`isDeleted: true`)
- **Completed Work** field on the work item is automatically recalculated and saved on every add, edit, or delete

### TT Settings (Boards sidebar hub)
| Tab | Purpose |
|-----|---------|
| Task Types | Define the organisation-wide list of task type labels (e.g. Development, Meeting, Testing) |
| Project Settings | Assign a Cost Centre code to each ADO project; used for report grouping |

### TT Report (Boards sidebar hub)
- Cross-project, cross-user report
- **Filter bar**: date range, project, cost centre, user, task type (all multi-select)
- **Group by**: User · Project · Cost Centre
- **Summary strip**: total hours, users, projects, cost centres, entries
- **Cost Centre summary box**: per-cost-centre hours breakdown
- **Drill-down**: expand any group row to see individual entries
- **Export CSV** and **Print** (expands all rows automatically before printing)

---

## Architecture

```
┌──────────────────────────────────────────────────────────┐
│                  Azure DevOps Browser                    │
│                                                          │
│  ┌─────────────────┐  ┌──────────┐  ┌───────────────┐  │
│  │  Work Item Form │  │TT Report │  │  TT Settings  │  │
│  │  (iframe)       │  │ (iframe) │  │   (iframe)    │  │
│  │                 │  │          │  │               │  │
│  │  TimeTracker    │  │ Report   │  │ Settings      │  │
│  │  component      │  │ component│  │ component     │  │
│  └────────┬────────┘  └────┬─────┘  └──────┬────────┘  │
│           │                │               │            │
│           ▼                ▼               ▼            │
│     TimeEntryService  ReportService  TaskTypeService    │
│                       ProjectSettings                   │
│           │                │               │            │
│           └────────────────┴───────────────┘            │
│                            │                            │
│              Azure DevOps Extension SDK v4              │
│         ┌──────────────────┴──────────────────┐        │
│         │                                      │        │
│  ExtensionDataService                 WorkItemFormService
│  (document storage)           (read/write WI fields)   │
│                                                         │
│         │                                               │
│  Work Item Tracking REST API (batch fetch — hub only)   │
└──────────────────────────────────────────────────────────┘
```

### Two-phase report loading
The report uses a two-phase load to keep the UI responsive:

| Phase | What happens | Result |
|-------|-------------|--------|
| 1 | Load all `TimeEntries` documents from ExtensionDataService | UI unlocks immediately with stored project/title |
| 2 (background) | Fetch work item details via REST API for entries missing a project (pre-v1.0.8 data) | Project names filled in; cost centres re-applied |

### Optimistic concurrency
Every document read from ExtensionDataService includes an `__etag` field. The service rejects writes with a mismatched etag (error 1660003). The code always reads the full document before writing, then spreads `__etag` back into the payload.

---

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Language | TypeScript 5.2 (strict mode) |
| UI framework | React 18 |
| Bundler | Webpack 5 |
| ADO SDK | azure-devops-extension-sdk v4 |
| ADO REST API | azure-devops-extension-api v4 |
| Storage | ExtensionDataService (built-in ADO extension storage) |
| Packaging | tfx-cli 0.16 |
| Target | `MS.VisualStudio.Services` |
| Min Node | 18 (for scripts) |

---

## Project Structure

```
time-tracking-ext/
├── vss-extension.json          # Extension manifest
├── package.json
├── tsconfig.json
├── webpack.config.js
├── images/
│   └── logo.png
├── scripts/
│   └── backfill-time-entries.js  # One-time data migration utility
└── src/
    ├── styles.css                # Shared styles for all three pages
    ├── models/
    │   ├── TimeEntry.ts          # Core time entry + form value interfaces
    │   ├── ReportEntry.ts        # Report-layer interfaces (filters, GroupBy, result)
    │   └── ProjectSetting.ts     # Project + cost centre model
    ├── services/
    │   ├── TimeEntryService.ts   # CRUD for time entries (ExtensionDataService)
    │   ├── TaskTypeService.ts    # Task type list (Config/task-types doc)
    │   ├── ProjectSettingsService.ts  # Project cost centres + ADO projects API
    │   └── ReportService.ts      # Report loading, filtering, grouping, CSV export
    ├── components/
    │   ├── TimeTracker.tsx        # Work item panel root
    │   ├── TimeEntryTable.tsx     # Entry list table
    │   ├── TimeEntryForm.tsx      # Add/edit form
    │   ├── ConfirmDialog.tsx      # Delete confirmation modal
    │   ├── Settings.tsx           # Settings page (tabbed shell)
    │   ├── ProjectSettings.tsx    # Project settings tab
    │   └── report/
    │       ├── Report.tsx         # Report page root
    │       ├── FilterBar.tsx      # Filter controls
    │       ├── MultiSelect.tsx    # Reusable multi-select dropdown
    │       ├── SummaryStrip.tsx   # KPI cards + cost centre breakdown
    │       └── ReportTable.tsx    # Pivot table with drill-down
    ├── time-tracker/
    │   ├── index.html
    │   └── index.tsx              # Entry point for work item panel iframe
    ├── settings/
    │   ├── index.html
    │   └── index.tsx              # Entry point for settings hub iframe
    └── report/
        ├── index.html
        └── index.tsx              # Entry point for report hub iframe
```

---

## Data Model

### TimeEntry (stored in ExtensionDataService)
```typescript
{
  id: string;           // UUID
  workItemId: number;
  project: string;      // Captured from System.TeamProject at save time
  workItemTitle: string;// Captured from System.Title at save time
  date: string;         // YYYY-MM-DD
  hours: number;
  taskType: string;     // Empty string = Unspecified
  notes: string;
  createdBy: string;    // Display name
  createdById: string;  // Unique identity descriptor
  createdAt: string;    // ISO 8601
  updatedAt: string;
  updatedBy: string;
  updatedById: string;
  isDeleted: boolean;   // Soft delete — never physically removed
}
```

### Storage documents (ExtensionDataService)

| Collection | Document ID | Contents |
|------------|-------------|----------|
| `TimeEntries` | `{workItemId}` | `{ id, entries: TimeEntry[], __etag }` |
| `Config` | `task-types` | `{ id, taskTypes: string[], __etag }` |
| `Config` | `project-settings` | `{ id, settings: { [projectId]: { name, costCenter } }, __etag }` |

---

## Installation

### Prerequisites
- Azure DevOps organisation (cloud or Server 2019+)
- Publisher account on the [Visual Studio Marketplace](https://marketplace.visualstudio.com/manage)
- Node.js 18+ and npm (for building from source)

### Install from .vsix (recommended)

1. Download the latest `hayleysadvantis.time-tracking-ext-x.x.x.vsix` from the releases.
2. In Azure DevOps, go to **Organisation Settings → Extensions → Manage extensions**.
3. Click **Upload extension** and select the `.vsix` file.
4. Once installed, open any work item — the **Time Tracking** panel appears at the bottom of the form.
5. The **TT Report** and **TT Settings** hubs appear in the left sidebar under **Boards**.

### First-time configuration

1. Go to **Boards → TT Settings → Task Types** and add your organisation's task type labels.
2. Go to **Boards → TT Settings → Project Settings**, assign cost centre codes to projects, and click **Save Changes**.

---

## Development Setup

```bash
# Clone
git clone <repo-url>
cd time-tracking-ext

# Install dependencies
npm install

# Development build with file watching
npm run watch
```

To test the extension against a live Azure DevOps organisation you need to:

1. Install `tfx-cli` globally: `npm install -g tfx-cli`
2. Log in to your publisher: `tfx login --service-url https://marketplace.visualstudio.com`
3. Publish a **private** version to your organisation for testing.

> The SDK requires the pages to be served from Azure DevOps' CDN — local file:// serving does not work. You must publish and install the extension to test it.

---

## Build & Package

```bash
# Production build only
npm run build

# Build + package into .vsix in one step
npm run package

# Or manually:
npx tfx extension create --manifest-globs vss-extension.json
```

The output is `hayleysadvantis.time-tracking-ext-{version}.vsix`.

### Bumping the version

Edit `version` in `vss-extension.json` before packaging:
```json
"version": "1.0.11"
```

ADO will not install a `.vsix` with a version number equal to or lower than the currently installed version.

---

## Utility Scripts

### `scripts/backfill-time-entries.js`

One-time migration script. Finds every work item across all projects where `CompletedWork > 0` but no time log entry exists, then creates a backfill entry.

**Requirements**
- Node.js 18+
- PAT with: **Work Items: Read** + **Extensions (all): Read & Manage** (or Full Access)

```bash
# Dry run — preview only, nothing is written
node scripts/backfill-time-entries.js --org <orgName> --pat <PAT> --dry-run

# Live run
node scripts/backfill-time-entries.js --org <orgName> --pat <PAT>

# Via environment variables
ADO_ORG=myorg ADO_PAT=xxxx node scripts/backfill-time-entries.js
```

Each backfill entry uses:
- **Date** — `System.ChangedDate` of the work item
- **Hours** — `Microsoft.VSTS.Scheduling.CompletedWork` value
- **User** — `System.ChangedBy`
- **Task type** — blank (Unspecified)
- **Notes** — `"Backfilled from Completed Work field"`

Work items that already have any active entry are skipped.

---

## Extension Contributions

Defined in `vss-extension.json`:

| ID | Type | Target | URI |
|----|------|--------|-----|
| `time-tracker-form-group` | `ms.vss-work-web.work-item-form-group` | Work item form | `dist/time-tracker/index.html` |
| `time-tracking-settings` | `ms.vss-web.hub` | Boards sidebar | `dist/settings/index.html` |
| `time-tracking-report` | `ms.vss-web.hub` | Boards sidebar | `dist/report/index.html` |

**Required scope:** `vso.work_write` — needed to read/write the Completed Work field on work items.
