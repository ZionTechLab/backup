import * as SDK from 'azure-devops-extension-sdk';
import { CommonServiceIds, IExtensionDataService } from 'azure-devops-extension-api';

const COLLECTION_NAME = 'Config';
const DOC_ID = 'project-settings';

export interface ProjectSettingEntry {
  name: string;
  costCenter: string;
}

interface ProjectSettingsDoc {
  id: string;
  settings: Record<string, ProjectSettingEntry>; // projectId → { name, costCenter }
  __etag?: number;
  [key: string]: unknown;
}

async function getDataManager() {
  const dataService = await SDK.getService<IExtensionDataService>(CommonServiceIds.ExtensionDataService);
  return dataService.getExtensionDataManager(
    SDK.getExtensionContext().id,
    await SDK.getAccessToken()
  );
}

async function readDoc(): Promise<ProjectSettingsDoc> {
  try {
    const manager = await getDataManager();
    const doc = await manager.getDocument(COLLECTION_NAME, DOC_ID);
    return doc as ProjectSettingsDoc;
  } catch (e: unknown) {
    const err = e as { status?: number; message?: string };
    if (err?.status === 404 || err?.message?.includes('not found')) {
      return { id: DOC_ID, settings: {} };
    }
    throw e;
  }
}

export async function getStoredSettings(): Promise<Record<string, ProjectSettingEntry>> {
  const doc = await readDoc();
  return doc.settings && typeof doc.settings === 'object' ? doc.settings : {};
}

// Returns projectName → costCenter map for use in reports.
export async function getNameToCostCenterMap(): Promise<Record<string, string>> {
  const stored = await getStoredSettings();
  const map: Record<string, string> = {};
  for (const entry of Object.values(stored)) {
    if (entry?.name && entry.costCenter) {
      map[entry.name] = entry.costCenter;
    }
  }
  return map;
}

export async function saveSettings(settings: Record<string, ProjectSettingEntry>): Promise<void> {
  const doc = await readDoc();
  const manager = await getDataManager();
  await manager.setDocument(COLLECTION_NAME, { ...doc, settings });
}

export async function fetchADOProjects(): Promise<{ id: string; name: string }[]> {
  const [token, host] = await Promise.all([
    SDK.getAccessToken(),
    Promise.resolve(SDK.getHost()),
  ]);
  const url = `https://dev.azure.com/${encodeURIComponent(host.name)}/_apis/projects?api-version=7.1&$top=500&stateFilter=wellFormed`;
  const response = await fetch(url, {
    headers: { Authorization: `Bearer ${token}` },
  });
  if (!response.ok) throw new Error(`Projects API returned ${response.status}`);
  const data = await response.json();
  return ((data.value ?? []) as { id: string; name: string }[])
    .map(p => ({ id: p.id, name: p.name }))
    .sort((a, b) => a.name.localeCompare(b.name));
}
