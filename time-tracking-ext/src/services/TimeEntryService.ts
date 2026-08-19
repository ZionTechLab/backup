import * as SDK from 'azure-devops-extension-sdk';
import { CommonServiceIds, IExtensionDataManager, IExtensionDataService } from 'azure-devops-extension-api';
import { IWorkItemFormService, WorkItemTrackingServiceIds } from 'azure-devops-extension-api/WorkItemTracking';
import { TimeEntry, UserRef } from '../models/TimeEntry';

const COLLECTION_NAME = 'TimeEntries';
const COMPLETED_WORK_FIELD = 'Microsoft.VSTS.Scheduling.CompletedWork';

// The server adds __etag to every document for optimistic concurrency.
// We must round-trip it on every write or we get error 1660003.
interface StoredDoc {
  id: string;
  entries: TimeEntry[];
  __etag?: number;
  [key: string]: unknown;
}

async function getDataManager(): Promise<IExtensionDataManager> {
  const dataService = await SDK.getService<IExtensionDataService>(CommonServiceIds.ExtensionDataService);
  return dataService.getExtensionDataManager(
    SDK.getExtensionContext().id,
    await SDK.getAccessToken()
  );
}

async function getFormService(): Promise<IWorkItemFormService> {
  return SDK.getService<IWorkItemFormService>(WorkItemTrackingServiceIds.WorkItemFormService);
}

async function readDocument(workItemId: number): Promise<StoredDoc> {
  try {
    const manager = await getDataManager();
    const doc = await manager.getDocument(COLLECTION_NAME, workItemId.toString());
    return doc as StoredDoc;
  } catch (e: unknown) {
    const err = e as { status?: number; message?: string };
    if (err?.status === 404 || err?.message?.includes('not found')) {
      return { id: workItemId.toString(), entries: [] };
    }
    throw e;
  }
}

async function writeDocument(doc: StoredDoc): Promise<void> {
  const manager = await getDataManager();
  await manager.setDocument(COLLECTION_NAME, doc);
}

async function syncCompletedWork(allEntries: TimeEntry[]): Promise<void> {
  const total = allEntries
    .filter(e => !e.isDeleted)
    .reduce((sum, e) => sum + e.hours, 0);

  try {
    const formService = await getFormService();
    await formService.setFieldValue(COMPLETED_WORK_FIELD, total);
    await formService.save();
  } catch (e) {
    console.warn('[TimeTracking] Could not sync Completed Work field:', e);
  }
}

export async function getActiveEntries(workItemId: number): Promise<TimeEntry[]> {
  const doc = await readDocument(workItemId);
  const entries = Array.isArray(doc.entries) ? doc.entries : [];
  return entries.filter(e => !e.isDeleted);
}

export async function addEntry(
  workItemId: number,
  values: { date: string; hours: number; taskType: string; notes: string; project: string; workItemTitle: string },
  user: UserRef
): Promise<TimeEntry> {
  const doc = await readDocument(workItemId);
  const entries = Array.isArray(doc.entries) ? doc.entries : [];
  const now = new Date().toISOString();
  const entry: TimeEntry = {
    id: crypto.randomUUID(),
    workItemId,
    project: values.project,
    workItemTitle: values.workItemTitle,
    date: values.date,
    hours: values.hours,
    taskType: values.taskType,
    notes: values.notes,
    createdBy: user.displayName,
    createdById: user.id,
    createdAt: now,
    updatedAt: now,
    updatedBy: user.displayName,
    updatedById: user.id,
    isDeleted: false,
  };
  entries.push(entry);
  await writeDocument({ ...doc, entries });
  await syncCompletedWork(entries);
  return entry;
}

export async function updateEntry(
  workItemId: number,
  entryId: string,
  values: { date: string; hours: number; taskType: string; notes: string; project: string; workItemTitle: string },
  user: UserRef
): Promise<TimeEntry> {
  const doc = await readDocument(workItemId);
  const entries = Array.isArray(doc.entries) ? doc.entries : [];
  const idx = entries.findIndex(e => e.id === entryId);
  if (idx < 0) throw new Error(`Time entry ${entryId} not found`);

  const now = new Date().toISOString();
  const updated: TimeEntry = {
    ...entries[idx],
    project: values.project,
    workItemTitle: values.workItemTitle,
    date: values.date,
    hours: values.hours,
    taskType: values.taskType,
    notes: values.notes,
    updatedAt: now,
    updatedBy: user.displayName,
    updatedById: user.id,
  };
  entries[idx] = updated;
  await writeDocument({ ...doc, entries });
  await syncCompletedWork(entries);
  return updated;
}

export async function softDeleteEntry(
  workItemId: number,
  entryId: string,
  user: UserRef
): Promise<void> {
  const doc = await readDocument(workItemId);
  const entries = Array.isArray(doc.entries) ? doc.entries : [];
  const idx = entries.findIndex(e => e.id === entryId);
  if (idx < 0) throw new Error(`Time entry ${entryId} not found`);

  const now = new Date().toISOString();
  entries[idx] = {
    ...entries[idx],
    isDeleted: true,
    updatedAt: now,
    updatedBy: user.displayName,
    updatedById: user.id,
  };
  await writeDocument({ ...doc, entries });
  await syncCompletedWork(entries);
}
