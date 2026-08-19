// Generic development mock API layer for any registered entity in mockRegistry.
// Intercepts axios requests that start with config.apiBaseUrl + <entity>/
// Supports: GET <entity>/get-all, GET <entity>/get?id=, POST <entity>/update, POST <entity>/delete

import axios from '../helpers/axiosInterceptors';
import config from '../config/config';
import mockRegistry from './mockRegistry';

function load(storageKey) {
  try {
    const raw = localStorage.getItem(storageKey);
    if (!raw) return [];
    return JSON.parse(raw) || [];
  } catch { return []; }
}

function save(storageKey, list) {
  localStorage.setItem(storageKey, JSON.stringify(list));
}

function ensureSeed(entityCfg) {
  const list = load(entityCfg.storage);
  if (list.length === 0 && entityCfg.seed && entityCfg.seed.length) {
    save(entityCfg.storage, entityCfg.seed);
  }
}

function parseEntityFromUrl(url) {
  if (!url.startsWith(config.apiBaseUrl)) return null;
  const rest = url.substring(config.apiBaseUrl.length); // e.g. 'uom/get-all'
  const segment = rest.split('/')[0];
  return segment || null;
}

function generateCode(entityCfg, header, list, newId) {
  if (!entityCfg.code) return undefined;
  const src = header[entityCfg.code.from] || 'NEW';
  const raw = src.substring(0, entityCfg.code.length).toUpperCase().replace(/[^A-Z0-9]/g, '');
  let finalCode = raw || 'NEW';
  if (list.some(r => r[entityCfg.code.field] === finalCode)) {
    finalCode = finalCode + newId; // simple collision avoider
  }
  return finalCode;
}

export function registerFakeApi() {
  if (registerFakeApi._registered) return;
  registerFakeApi._registered = true;

  // Seed each registered entity once
  Object.values(mockRegistry).forEach(cfg => ensureSeed(cfg));

  axios.interceptors.request.use((req) => {
    if (!req.url) return req;
    if (!req.url.startsWith(config.apiBaseUrl)) return req;

    const entityKey = parseEntityFromUrl(req.url);
    const entityCfg = mockRegistry[entityKey];
    if (!entityCfg) return req; // not mocked

    req.adapter = async () => {
      const url = req.url || '';
      const method = (req.method || 'get').toLowerCase();
      const list = load(entityCfg.storage);
      const idField = entityCfg.idField || 'id';
      const respond = (data, status = 200) => ({
        data,
        status,
        statusText: 'OK',
        headers: {},
        config: req,
        request: {},
      });

      // get-all
      if (url.endsWith('/get-all') && method === 'get') {
        return respond(list);
      }
      // get-ui (UI metadata like roles, categories etc.)
      if (url.endsWith('/get-ui') && method === 'get') {
        return respond(entityCfg.uiData || {});
      }
      // get?id=  (support axios { params: { id } } where params not yet appended to url)
      if (url.includes('/get') && method === 'get') {
        let idParam = null;
        try {
          idParam = new URL(url, window.location.origin).searchParams.get('id');
        } catch { /* ignore */ }
        if ((idParam === null || idParam === undefined) && req.params) {
          // axios stores original params in req.params when using our interceptor stage
            if (req.params.id !== undefined) idParam = req.params.id;
            else if (req.params.ID !== undefined) idParam = req.params.ID;
        }
        const entity = list.find(r => String(r[idField]) === String(idParam));
        return respond(entity || null);
      }
      // update
      if (url.endsWith('/update') && method === 'post') {
        const body = req.data && typeof req.data === 'string' ? JSON.parse(req.data) : req.data;
        const header = body?.header || {};
        let next = [...list];
        const idVal = header[idField];
        if (!idVal || idVal === 0) {
          const maxId = next.reduce((m, r) => (r[idField] > m ? r[idField] : m), 0);
          const newId = maxId + 1;
            const record = { [idField]: newId };
            // copy allowed fields
            (entityCfg.createFields || Object.keys(header)).forEach(f => { if (header[f] !== undefined) record[f] = header[f]; });
            // code generation
            const codeVal = generateCode(entityCfg, header, next, newId);
            if (codeVal !== undefined) record[entityCfg.code.field] = codeVal;
            // default active
            if (record.active === undefined) record.active = true;
            next.push(record);
            save(entityCfg.storage, next);
            return respond({ success: true, data: record });
        } else {
          const idx = next.findIndex(r => r[idField] === idVal);
          if (idx >= 0) {
            const updated = { ...next[idx] };
            (entityCfg.updateFields || Object.keys(header)).forEach(f => {
              if (header[f] === undefined) return;
              // omit empty field update if configured
              if (header[f] === '' && entityCfg.omitEmptyOnUpdate && entityCfg.omitEmptyOnUpdate.includes(f)) return;
              updated[f] = header[f];
            });
            next[idx] = updated;
            save(entityCfg.storage, next);
            return respond({ success: true, data: updated });
          }
          return respond({ success: false, error: 'Not found' }, 404);
        }
      }
      // delete
      if (url.endsWith('/delete') && method === 'post') {
        const body = req.data && typeof req.data === 'string' ? JSON.parse(req.data) : req.data;
        const { id } = body || {};
        const next = list.filter(r => String(r[idField]) !== String(id));
        save(entityCfg.storage, next);
        return respond({ success: true });
      }

      return respond({ success: false, error: 'Unhandled mock path' }, 400);
    };
    return req;
  });
}

export default registerFakeApi;
