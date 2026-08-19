import * as SDK from 'azure-devops-extension-sdk';
import { CommonServiceIds, IExtensionDataService } from 'azure-devops-extension-api';

const COLLECTION_NAME = 'Config';
const DOC_ID = 'task-types';
const AMC_DOC_ID = 'amc-task-types';

const DEFAULTS = ['Development', 'Meeting', 'Brainstorming', 'Design', 'Testing', 'Code Review', 'Documentation'];

interface TaskTypesDoc {
  id: string;
  taskTypes: string[];
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

async function readDoc(): Promise<TaskTypesDoc> {
  try {
    const manager = await getDataManager();
    const doc = await manager.getDocument(COLLECTION_NAME, DOC_ID);
    return doc as TaskTypesDoc;
  } catch (e: unknown) {
    const err = e as { status?: number; message?: string };
    if (err?.status === 404 || err?.message?.includes('not found')) {
      return { id: DOC_ID, taskTypes: [...DEFAULTS] };
    }
    throw e;
  }
}

export async function getTaskTypes(): Promise<string[]> {
  const doc = await readDoc();
  return Array.isArray(doc.taskTypes) ? doc.taskTypes : [...DEFAULTS];
}

export async function saveTaskTypes(taskTypes: string[]): Promise<void> {
  const doc = await readDoc();
  const manager = await getDataManager();
  await manager.setDocument(COLLECTION_NAME, { ...doc, taskTypes });
}

/* ---- AMC task types ---- */

interface AmcDoc {
  id: string;
  amcTaskTypes: string[];
  __etag?: number;
  [key: string]: unknown;
}

async function readAmcDoc(): Promise<AmcDoc> {
  try {
    const manager = await getDataManager();
    const doc = await manager.getDocument(COLLECTION_NAME, AMC_DOC_ID);
    return doc as AmcDoc;
  } catch (e: unknown) {
    const err = e as { status?: number; message?: string };
    if (err?.status === 404 || err?.message?.includes('not found')) {
      return { id: AMC_DOC_ID, amcTaskTypes: [] };
    }
    throw e;
  }
}

export async function getAmcTaskTypes(): Promise<string[]> {
  const doc = await readAmcDoc();
  return Array.isArray(doc.amcTaskTypes) ? doc.amcTaskTypes : [];
}

export async function saveAmcTaskTypes(amcTaskTypes: string[]): Promise<void> {
  const doc = await readAmcDoc();
  const manager = await getDataManager();
  await manager.setDocument(COLLECTION_NAME, { ...doc, amcTaskTypes });
}
