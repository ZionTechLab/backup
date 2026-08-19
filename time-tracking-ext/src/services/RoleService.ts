import * as SDK from 'azure-devops-extension-sdk';
import { CommonServiceIds, IExtensionDataService } from 'azure-devops-extension-api';

const COLLECTION_NAME = 'Config';
const ROLES_DOC_ID = 'roles';
const USER_ROLES_DOC_ID = 'user-roles';

export interface Role {
  roleId: string;
  name: string;
  desc: string;
}

interface RolesDoc {
  id: string;
  roles: Role[];
  __etag?: number;
  [key: string]: unknown;
}

export interface UserRoles {
  [userId: string]: string[]; // Array of roleIds
}

interface UserRolesDoc {
  id: string;
  userRoles: UserRoles;
  __etag?: number;
  [key: string]: unknown;
}

export interface ADOUser {
  principalName: string;
  displayName: string;
  descriptor: string;
}

async function getDataManager() {
  const dataService = await SDK.getService<IExtensionDataService>(CommonServiceIds.ExtensionDataService);
  return dataService.getExtensionDataManager(
    SDK.getExtensionContext().id,
    await SDK.getAccessToken()
  );
}

export async function getRoles(): Promise<Role[]> {
  try {
    const manager = await getDataManager();
    const doc = await manager.getDocument(COLLECTION_NAME, ROLES_DOC_ID) as RolesDoc;
    return Array.isArray(doc.roles) ? doc.roles : [];
  } catch (e: unknown) {
    const err = e as { status?: number; message?: string };
    if (err?.status === 404 || err?.message?.includes('not found')) {
      return [];
    }
    throw e;
  }
}

export async function saveRoles(roles: Role[]): Promise<void> {
  const manager = await getDataManager();
  let doc: RolesDoc = { id: ROLES_DOC_ID, roles: [] };
  try {
    doc = await manager.getDocument(COLLECTION_NAME, ROLES_DOC_ID) as RolesDoc;
  } catch (e: unknown) {
    // Ignore 404
  }
  await manager.setDocument(COLLECTION_NAME, { ...doc, roles });
}

export async function getUserRoles(): Promise<UserRoles> {
  try {
    const manager = await getDataManager();
    const doc = await manager.getDocument(COLLECTION_NAME, USER_ROLES_DOC_ID) as UserRolesDoc;
    return doc.userRoles && typeof doc.userRoles === 'object' ? doc.userRoles : {};
  } catch (e: unknown) {
    const err = e as { status?: number; message?: string };
    if (err?.status === 404 || err?.message?.includes('not found')) {
      return {};
    }
    throw e;
  }
}

export async function saveUserRoles(userRoles: UserRoles): Promise<void> {
  const manager = await getDataManager();
  let doc: UserRolesDoc = { id: USER_ROLES_DOC_ID, userRoles: {} };
  try {
    doc = await manager.getDocument(COLLECTION_NAME, USER_ROLES_DOC_ID) as UserRolesDoc;
  } catch (e: unknown) {
    // Ignore 404
  }
  await manager.setDocument(COLLECTION_NAME, { ...doc, userRoles });
}

export async function fetchAllUsers(): Promise<ADOUser[]> {
  const [token, host] = await Promise.all([
    SDK.getAccessToken(),
    Promise.resolve(SDK.getHost()),
  ]);
  const url = `https://vssps.dev.azure.com/${encodeURIComponent(host.name)}/_apis/graph/users?api-version=7.1-preview.1`;
  const response = await fetch(url, {
    headers: { Authorization: `Bearer ${token}` },
  });
  if (!response.ok) throw new Error(`Graph API returned ${response.status}`);
  const data = await response.json();

  return ((data.value ?? []) as (ADOUser & { origin?: string; subjectKind?: string; domain?: string })[])
    .filter(u => {
      if (u.subjectKind && u.subjectKind !== 'user') return false;
      const name = u.displayName || '';
      if (name.includes('Build Service') || name.includes('Project Collection')) return false;
      return true;
    })
    .map(u => ({
      principalName: u.principalName,
      displayName: u.displayName,
      descriptor: u.descriptor
    }))
    .sort((a, b) => a.displayName.localeCompare(b.displayName));
}
