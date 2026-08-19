import * as SDK from 'azure-devops-extension-sdk';
import { CommonServiceIds, IExtensionDataService, IProjectPageService } from 'azure-devops-extension-api';
import { TimeEntry } from '../models/TimeEntry';
import { GroupBy, GroupedRow, ReportEntry, ReportFilters, ReportResult } from '../models/ReportEntry';

const COLLECTION_NAME = 'TimeEntries';
const BATCH_SIZE = 200;
const UNSPECIFIED = 'Unspecified';
const ENRICH_TIMEOUT_MS = 12000;

interface StoredDoc {
  id: string;
  entries: TimeEntry[];
  [key: string]: unknown;
}

async function getDataManager() {
  const dataService = await SDK.getService<IExtensionDataService>(CommonServiceIds.ExtensionDataService);
  return dataService.getExtensionDataManager(
    SDK.getExtensionContext().id,
    await SDK.getAccessToken()
  );
}

function toReportEntry(workItemId: number, entry: TimeEntry): ReportEntry {
  return {
    id: entry.id,
    workItemId,
    workItemTitle: entry.workItemTitle || `#${workItemId}`,
    workItemType: '',
    project: entry.project || '',
    costCenter: '',
    category: '',
    date: entry.date,
    hours: entry.hours,
    taskType: entry.taskType || '',
    notes: entry.notes,
    createdBy: entry.createdBy,
    createdById: entry.createdById,
  };
}

// Attaches cost centres to entries using a projectName → costCenter map.
// Call this after each load phase (raw + enriched) so the data stays in sync.
export function applyCostCenters(
  entries: ReportEntry[],
  ccMap: Record<string, string>
): ReportEntry[] {
  return entries.map(e => ({
    ...e,
    costCenter: e.project ? (ccMap[e.project] ?? '') : '',
  }));
}

// Phase 1: return all active entries using project/title stored at save time.
// No external API calls — always fast.
export async function loadRawEntries(): Promise<ReportEntry[]> {
  const manager = await getDataManager();
  let docs: StoredDoc[] = [];
  try {
    docs = await manager.getDocuments(COLLECTION_NAME);
  } catch (e: unknown) {
    const err = e as { status?: number };
    if (err?.status === 404) return [];
    throw e;
  }

  const result: ReportEntry[] = [];
  for (const doc of docs) {
    const workItemId = parseInt(doc.id, 10);
    if (isNaN(workItemId)) continue;
    const entries = Array.isArray(doc.entries) ? doc.entries : [];
    for (const entry of entries) {
      if (!entry.isDeleted) result.push(toReportEntry(workItemId, entry));
    }
  }
  return result;
}

// Phase 2: for any entries that predate the project field (project is empty),
// fetch from the Work Item Tracking API and fill in the gaps.
// Uses direct fetch + SDK token to avoid getClient URL resolution failures in hub iframes.
export async function enrichEntries(raw: ReportEntry[]): Promise<ReportEntry[]> {
  const unknownIds = [...new Set(
    raw.filter(e => !e.project).map(e => e.workItemId)
  )];

  if (unknownIds.length === 0) return raw;

  const wiMap = new Map<number, { project: string; title: string }>();

  try {
    const [token, host] = await Promise.all([
      SDK.getAccessToken(),
      Promise.resolve(SDK.getHost()),
    ]);
    const orgName = host.name;

    const chunkPromises = [];

    for (let i = 0; i < unknownIds.length; i += BATCH_SIZE) {
      const chunk = unknownIds.slice(i, i + BATCH_SIZE);
      chunkPromises.push((async () => {
        try {
          const url = `https://dev.azure.com/${encodeURIComponent(orgName)}/_apis/wit/workitemsbatch?api-version=7.1`;
          const fetchCall = fetch(url, {
            method: 'POST',
            headers: {
              'Authorization': `Bearer ${token}`,
              'Content-Type': 'application/json',
            },
            body: JSON.stringify({
              ids: chunk,
              fields: ['System.TeamProject', 'System.Title'],
              errorPolicy: 'omit',
            }),
          });
          const dead = new Promise<never>((_, reject) =>
            setTimeout(() => reject(new Error('Work item lookup timed out')), ENRICH_TIMEOUT_MS)
          );
          const response = await Promise.race([fetchCall, dead]);
          if (response.ok) {
            const data = await response.json();
            for (const wi of data.value ?? []) {
              if (wi?.id) {
                wiMap.set(wi.id, {
                  project: wi.fields['System.TeamProject'] ?? '',
                  title: wi.fields['System.Title'] ?? `#${wi.id}`,
                });
              }
            }
          } else {
            console.warn('[TT Report] Work item batch returned', response.status);
          }
        } catch (e) {
          console.warn('[TT Report] Work item enrichment chunk failed:', e);
        }
      })());
    }

    await Promise.all(chunkPromises);
  } catch (e) {
    console.warn('[TT Report] Could not initialise enrichment:', e);
  }

  return raw.map(e => {
    if (e.project) return e;
    const wi = wiMap.get(e.workItemId);
    return {
      ...e,
      project: wi?.project ?? 'Unknown',
      workItemTitle: wi?.title ?? e.workItemTitle,
    };
  });
}

// Sets entry.category to 'AMC' if the entry's taskType is in the AMC list, else 'Other'.
export function applyAmcCategories(
  entries: ReportEntry[],
  amcTaskTypes: string[],
): ReportEntry[] {
  const amcSet = new Set(amcTaskTypes.map(t => t.trim().toLowerCase()));
  return entries.map(e => ({
    ...e,
    category: e.taskType && amcSet.has(e.taskType.trim().toLowerCase()) ? 'AMC' : 'Other',
  }));
}

function displayType(taskType: string): string {
  return taskType.trim() || UNSPECIFIED;
}

export function applyFilters(allEntries: ReportEntry[], filters: ReportFilters): ReportEntry[] {
  return allEntries.filter(e => {
    if (e.date < filters.dateFrom || e.date > filters.dateTo) return false;
    if (filters.projects.length > 0 && !filters.projects.includes(e.project)) return false;
    if (filters.users.length > 0 && !filters.users.includes(e.createdBy)) return false;
    if (filters.taskTypes.length > 0 && !filters.taskTypes.includes(displayType(e.taskType))) return false;
    if (filters.costCenters.length > 0 && !filters.costCenters.includes(e.costCenter || '')) return false;
    return true;
  });
}

export function buildReport(filtered: ReportEntry[], groupBy: GroupBy): ReportResult {
  const taskTypeSet = new Set<string>();
  const projectSet = new Set<string>();
  const userSet = new Set<string>();
  const ccSet = new Set<string>();

  for (const e of filtered) {
    taskTypeSet.add(displayType(e.taskType));
    projectSet.add(e.project);
    userSet.add(e.createdById);
    if (e.costCenter) ccSet.add(e.costCenter);
  }

  const taskTypeColumns = [...taskTypeSet].sort();
  const groupMap = new Map<string, GroupedRow>();

  for (const e of filtered) {
    let key: string;
    let label: string;
    if (groupBy === 'user') {
      key = e.createdBy;
      label = e.createdBy;
    } else if (groupBy === 'date') {
      key = e.date;
      label = e.date;
    } else if (groupBy === 'costCenter') {
      key = e.costCenter || '__none__';
      label = e.costCenter || 'No Cost Centre';
    } else if (groupBy === 'category') {
      key = e.category || 'Other';
      label = e.category || 'Other';
    } else {
      key = e.project;
      label = e.project;
    }

    const type = displayType(e.taskType);
    if (!groupMap.has(key)) {
      groupMap.set(key, { key, label, hoursByType: {}, total: 0, entries: [] });
    }
    const row = groupMap.get(key)!;
    row.hoursByType[type] = (row.hoursByType[type] ?? 0) + e.hours;
    row.total += e.hours;
    row.entries.push(e);
  }

  const rows = [...groupMap.values()].sort((a, b) => a.label.localeCompare(b.label));
  const grandTotal = rows.reduce((s, r) => s + r.total, 0);
  const totalAmcHours = filtered.filter(e => e.category === 'AMC').reduce((s, e) => s + e.hours, 0);

  return {
    rows,
    taskTypeColumns,
    grandTotal,
    totalAmcHours,
    totalUsers: userSet.size,
    totalProjects: projectSet.size,
    totalCostCenters: ccSet.size,
    totalEntries: filtered.length,
  };
}

export function getDistinctOptions(entries: ReportEntry[]): {
  projects: string[];
  users: { id: string; name: string }[];
  taskTypes: string[];
  costCenters: string[];
} {
  const projects = [...new Set(entries.map(e => e.project).filter(Boolean))].sort();
  const costCenters = [...new Set(entries.map(e => e.costCenter).filter(Boolean))].sort();
  const userMap = new Map<string, string>();
  const taskTypeSet = new Set<string>();
  for (const e of entries) {
    userMap.set(e.createdBy, e.createdBy);
    taskTypeSet.add(displayType(e.taskType));
  }
  const users = [...userMap.entries()]
    .map(([id, name]) => ({ id, name }))
    .sort((a, b) => a.name.localeCompare(b.name));
  const taskTypes = [...taskTypeSet].sort();
  return { projects, users, taskTypes, costCenters };
}

export function exportToCsv(filtered: ReportEntry[], groupBy: GroupBy): void {
  const rows: string[][] = [
    ['Date', 'Project', 'Cost Centre', 'Work Item ID', 'Work Item Title', 'User', 'Task Type', 'Hours', 'Notes'],
  ];
  const sorted = [...filtered].sort((a, b) => {
    if (groupBy === 'user') return a.createdBy.localeCompare(b.createdBy) || a.date.localeCompare(b.date);
    if (groupBy === 'costCenter') return a.costCenter.localeCompare(b.costCenter) || a.date.localeCompare(b.date);
    if (groupBy === 'date') return a.date.localeCompare(b.date) || a.project.localeCompare(b.project);
    if (groupBy === 'category') return a.category.localeCompare(b.category) || a.date.localeCompare(b.date);
    return a.project.localeCompare(b.project) || a.date.localeCompare(b.date);
  });
  for (const e of sorted) {
    rows.push([
      e.date, e.project, e.costCenter, String(e.workItemId), e.workItemTitle,
      e.createdBy, displayType(e.taskType), String(e.hours), e.notes,
    ]);
  }
  const csv = rows.map(r => r.map(c => `"${c.replace(/"/g, '""')}"`).join(',')).join('\r\n');
  const blob = new Blob([csv], { type: 'text/csv;charset=utf-8;' });
  const url = URL.createObjectURL(blob);
  const a = document.createElement('a');
  a.href = url;
  a.download = `time-report-${new Date().toISOString().slice(0, 10)}.csv`;
  a.click();
  URL.revokeObjectURL(url);
}

// Returns display names of all members across every team in the current project.
// Requires vso.project scope. Falls back to empty array on any failure so the
// caller can degrade gracefully to the entry-derived user list.
export async function loadOrgMembers(): Promise<string[]> {
  try {
    const [token, host, projectService] = await Promise.all([
      SDK.getAccessToken(),
      Promise.resolve(SDK.getHost()),
      SDK.getService<IProjectPageService>(CommonServiceIds.ProjectPageService),
    ]);
    const project = await projectService.getProject();
    if (!project) return [];

    const org = encodeURIComponent(host.name);
    const headers = { Authorization: `Bearer ${token}` };

    const teamsRes = await fetch(
      `https://dev.azure.com/${org}/_apis/projects/${project.id}/teams?$mine=false&api-version=7.1`,
      { headers }
    );
    if (!teamsRes.ok) return [];
    const teamsData = await teamsRes.json();
    const teams: { id: string }[] = teamsData.value ?? [];

    const memberMap = new Map<string, string>();
    await Promise.all(
      teams.map(async team => {
        try {
          const membersRes = await fetch(
            `https://dev.azure.com/${org}/_apis/projects/${project.id}/teams/${team.id}/members?api-version=7.1`,
            { headers }
          );
          if (!membersRes.ok) return;
          const membersData = await membersRes.json();
          for (const m of membersData.value ?? []) {
            if (m.identity?.id && !m.identity?.isContainer) {
              memberMap.set(m.identity.id, m.identity.displayName as string);
            }
          }
        } catch { /* skip failing team */ }
      })
    );

    return [...memberMap.values()].sort((a, b) => a.localeCompare(b));
  } catch {
    return [];
  }
}
