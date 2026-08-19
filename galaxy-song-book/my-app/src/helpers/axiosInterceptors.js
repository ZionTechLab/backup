import axios from "axios";
import config from "../config/config";
import { getState, dispatch } from "../storeAccessor";
import { refreshAccessToken, selectUserId, selectTenantId, selectSelectedCompanyId } from "../features/auth";

const USER_ID_HEADER = (config && config.userIdHeaderName) || "X-User-Id";
const TENANT_ID_HEADER = (config && config.tenantIdHeaderName) || "X-Tenant-Id";
const COMPANY_ID_HEADER = (config && config.companyIdHeaderName) || "X-Company-Id";

export function registerAxiosInterceptors() {
  // idempotent: avoid adding multiple interceptors if called repeatedly
  if (registerAxiosInterceptors._registered) return;
  registerAxiosInterceptors._registered = true;

  axios.defaults.timeout = 30_000;

  // Refresh slightly before expiry to avoid race conditions
  const EXPIRY_SKEW_MS = 30_000; // 30 seconds

  // Single-flight refresh control
  let refreshPromise = null;

  function parseExpiresAt(expiresAt) {
    if (!expiresAt) return null;
    if (typeof expiresAt === "number") return expiresAt;
    const asNumber = Number(expiresAt);
    if (Number.isFinite(asNumber) && asNumber > 0) return asNumber;
    const ts = Date.parse(expiresAt);
    return Number.isNaN(ts) ? null : ts;
  }

  function getAuthSnapshot() {
    const state = getState();
    const auth = state?.auth ?? {};
    const user = auth.user ?? {};
    return {
      token:
        auth.token ??
        user.token ??
        user.accessToken ??
        user.access_token ??
        null,
      refreshToken:
        auth.refreshToken ??
        user.refreshToken ??
        user.refresh_token ??
        null,
      expiresAt: parseExpiresAt(auth.expiresAt ?? user.expiresAt),
      userId: selectUserId(state),
      tenantId: selectTenantId(state),
      companyId: selectSelectedCompanyId(state),
    };
  }

  async function ensureValidToken() {
    const { expiresAt, refreshToken } = getAuthSnapshot();
    if (!expiresAt || !refreshToken) return; // nothing to do
    const now = Date.now();
    const nearExpiry = expiresAt - now <= EXPIRY_SKEW_MS;
    if (!nearExpiry) return;

    if (!refreshPromise) {
      refreshPromise = dispatch(refreshAccessToken()).finally(() => {
        refreshPromise = null;
      });
    }
    await refreshPromise;
  }

  // Pre-request: validate/refresh token and attach headers
  axios.interceptors.request.use(async (req) => {
    try {
      // Allow callers to bypass auth logic for specific requests (e.g., refresh)
      if (!req._skipAuth) {
        await ensureValidToken();
      }

      const { token, userId, tenantId, companyId } = getAuthSnapshot();

      req.headers = req.headers || {};

      if (token) {
        if (!req.headers["Authorization"] && !req.headers["authorization"]) {
          req.headers["Authorization"] = `Bearer ${token}`;
        }
      }

      if (userId != null && userId !== "") {
        if (!req.headers[USER_ID_HEADER]) {
          req.headers[USER_ID_HEADER] = String(userId);
        }
      }

      if (tenantId != null && tenantId !== "") {
        if (!req.headers[TENANT_ID_HEADER]) {
          req.headers[TENANT_ID_HEADER] = String(tenantId);
        }
      }

      if (companyId != null && companyId !== "") {
        if (!req.headers[COMPANY_ID_HEADER]) {
          req.headers[COMPANY_ID_HEADER] = String(companyId);
        }
      }
    } catch {
      // Swallow to avoid breaking requests due to header injection issues
    }
    return req;
  });

  // Response fallback: on 401, try a single refresh and retry once
  axios.interceptors.response.use(
    (res) => res,
    async (error) => {
      const original = error?.config || {};
      if (error?.response?.status !== 401 || original._retry || original._skipAuth) {
        return Promise.reject(error);
      }

      try {
        original._retry = true;
        if (!refreshPromise) {
          refreshPromise = dispatch(refreshAccessToken()).finally(() => {
            refreshPromise = null;
          });
        }
        await refreshPromise;

        const { token } = getAuthSnapshot();
        original.headers = original.headers || {};
        if (token) {
          original.headers["Authorization"] = `Bearer ${token}`;
        }
        return axios(original);
      } catch (e) {
        return Promise.reject(e || error);
      }
    }
  );
}

export default axios;
