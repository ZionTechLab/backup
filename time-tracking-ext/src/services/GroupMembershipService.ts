import * as SDK from 'azure-devops-extension-sdk';

const cache = new Map<string, boolean>();

export async function isUserInGroup(groupName: string): Promise<boolean> {
  if (cache.has(groupName)) return cache.get(groupName)!;

  const [token, user] = [await SDK.getAccessToken(), SDK.getUser()];
  const org = SDK.getHost().name;
  const base = `https://vssps.dev.azure.com/${encodeURIComponent(org)}/_apis/graph`;
  const headers = { Authorization: `Bearer ${token}`, 'Content-Type': 'application/json' };

  const membershipsRes = await fetch(
    `${base}/memberships/${encodeURIComponent(user.descriptor)}?direction=up&api-version=7.1-preview.1`,
    { headers }
  );
  if (!membershipsRes.ok) {
    cache.set(groupName, false);
    return false;
  }

  const membershipsData: { value: { containerDescriptor: string }[] } = await membershipsRes.json();
  const descriptors = membershipsData.value.map(m => m.containerDescriptor);

  if (descriptors.length === 0) {
    cache.set(groupName, false);
    return false;
  }

  const lookupRes = await fetch(`${base}/subjectlookup?api-version=7.1-preview.1`, {
    method: 'POST',
    headers,
    body: JSON.stringify({ lookupKeys: descriptors.map(d => ({ descriptor: d })) }),
  });

  if (!lookupRes.ok) {
    cache.set(groupName, false);
    return false;
  }

  const lookupData: { value: Record<string, { displayName: string }> } = await lookupRes.json();
  const found = Object.values(lookupData.value).some(
    g => g.displayName.toLowerCase() === groupName.toLowerCase()
  );

  cache.set(groupName, found);
  return found;
}
