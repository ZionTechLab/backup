import { createSlice, createAsyncThunk, isAnyOf } from "@reduxjs/toolkit";
import AuthService from "./authService";

const parseStoredExpiresAt = (value) => {
  if (value == null) return null;
  const asNumber = Number(value);
  return Number.isFinite(asNumber) && asNumber > 0 ? asNumber : value;
};

// Single source of truth for auth localStorage keys.
// Append here whenever a new auth key is written so logout clears it automatically.
const AUTH_STORAGE_KEYS = ["user", "initData", "refreshToken", "expiresAt", "selectedGroupId", "selectedCompanyId", "selectedPeriodId"];
const clearAuthStorage = () => AUTH_STORAGE_KEYS.forEach((k) => localStorage.removeItem(k));

// Helper to safely parse JSON from localStorage
const getFromStorage = (key) => {
  try {
    const item = localStorage.getItem(key);
    return item ? JSON.parse(item) : null;
  } catch (error) {
    return null;
  }
};

// Resolve the default company id from init data.
// Prefers the company flagged isDefault, then the first company.
const resolveDefaultCompanyId = (initData) => {
  const companies = initData?.userCompanies ?? [];
  const defaultCompany = companies.find((c) => c.isDefault) ?? companies[0];
  return defaultCompany?.companyId ?? null;
};

// Shared post-auth flow: fetch init data and shape the menu tree.
// Used by both password login and SSO callback so both end up in the same state.
// Shapes a raw init response into store form: flat menu kept, plus a nested
// parent/children menu tree. Shared by initial auth and later reloads.
// Recursively build a tree from a flat menu list keyed by parentId.
// Supports arbitrary depth so 3+ levels render correctly in the drawer.
function buildMenuTree(items, parentId = 0) {
  return items
    .filter((item) => item.parentId === parentId)
    .map((item) => {
      const children = buildMenuTree(items, item.id);
      return {
        id: item.id,
        route: item.route,
        displayName: item.displayName,
        icon: item.icon,
        isGroup: item.isGroup,
        children: children.length > 0 ? children : undefined,
      };
    });
}

function shapeInitData(data) {
  return { ...data, menuItems_Flat: data.menuItems, menuItems: buildMenuTree(data.menuItems) };
}

async function buildAuthPayload(authData) {
  try {
    const initRes = await AuthService.init(authData.user.userId);
    const initData = initRes && initRes.success ? shapeInitData(initRes.data) : null;
    return { ...authData, initData };
  } catch {
    return { ...authData, initData: null };
  }
}

export const loginAsync = createAsyncThunk(
  "auth/login",
  async (credentials, { rejectWithValue }) => {
    try {
      const res = await AuthService.login(credentials);
      if (res && res.success) {
        return await buildAuthPayload(res.data);
      }
      return rejectWithValue(res?.error || "Login failed");
    } catch (error) {
      return rejectWithValue("Login failed");
    }
  }
);

export const ssoCallbackAsync = createAsyncThunk(
  "auth/ssoCallback",
  async ({ code, provider }, { rejectWithValue }) => {
    try {
      const res = await AuthService.ssoExchange({ code, provider });
      if (res && res.success) {
        return await buildAuthPayload(res.data);
      }
      return rejectWithValue(res?.error || "SSO login failed");
    } catch (error) {
      return rejectWithValue("SSO login failed");
    }
  }
);

export const logoutAsync = createAsyncThunk("auth/logout", async () => {
  try {
    await AuthService.logout();
  } catch {
    // Ignore server errors; client state must clear regardless.
  }
  return {};
});

// Re-fetch init data for the current user and refresh the cached store copy.
// Use after server-side changes that affect init (e.g. closing/opening a
// financial month updates a company's current period).
export const reloadInitData = createAsyncThunk(
  "auth/reloadInit",
  async (_, { getState, rejectWithValue }) => {
    const userId = resolveUserId(getState().auth.user);
    if (!userId) return rejectWithValue("No user");
    const initRes = await AuthService.init(userId);
    if (initRes && initRes.success) return shapeInitData(initRes.data);
    return rejectWithValue(initRes?.error || "Init reload failed");
  }
);

// Async thunk for refreshing access token
export const refreshAccessToken = createAsyncThunk(
  "auth/refreshAccessToken",
  async (_, { getState, rejectWithValue }) => {
    try {
      const state = getState();
      const rt =
        state?.auth?.refreshToken ??
        state?.auth?.user?.refreshToken ??
        state?.auth?.user?.refresh_token;
      if (!rt) return rejectWithValue("Missing refresh token");
      const res = await AuthService.refreshToken(rt);
      if (res && res.success) {
        // Expect backend to return { token, expiresAt, refreshToken? }
        return res.data;
      }
      return rejectWithValue(res?.error || "Refresh failed");
    } catch (error) {
      return rejectWithValue("Refresh failed");
    }
  }
);

// Define default empty state
const defaultState = {
  isLoggedIn: false,
  user: null,
  token: null,
  expiresAt: null,
  refreshToken: null,
  initData: null,
  loading: false,
  error: null,
  selectedGroupId: null,
  selectedCompanyId: null,
  selectedPeriodId: null,
};

// Initialize state from localStorage if available.
// Access token is intentionally NOT persisted to localStorage (XSS risk).
// isLoggedIn is derived from the refresh token instead; the access token is
// restored via a silent refresh dispatched from App.js on startup.
const user = getFromStorage("user");
const initData = getFromStorage("initData");

const initialState = {
  ...defaultState,
  isLoggedIn: !!localStorage.getItem("refreshToken"),
  user: user,
  token: null,
  expiresAt: parseStoredExpiresAt(localStorage.getItem("expiresAt")),
  refreshToken: localStorage.getItem("refreshToken"),
  initData: initData,
  selectedGroupId: localStorage.getItem("selectedGroupId") || null,
  selectedCompanyId:
    localStorage.getItem("selectedCompanyId") || resolveDefaultCompanyId(initData) || null,
  selectedPeriodId: localStorage.getItem("selectedPeriodId") || null,
};

const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    clearError: (state) => {
      state.error = null;
    },
    initSuccess: (state, action) => {
      state.initData = action.payload ?? null;
      localStorage.setItem("initData", JSON.stringify(state.initData));
      if (!state.selectedCompanyId) {
        const companyId = resolveDefaultCompanyId(state.initData);
        if (companyId) {
          state.selectedCompanyId = companyId;
          localStorage.setItem("selectedCompanyId", companyId);
        }
      }
    },
    setContext: (state, action) => {
      const { groupId, companyId, periodId } = action.payload ?? {};
      if (groupId !== undefined) {
        state.selectedGroupId = groupId;
        if (groupId) localStorage.setItem("selectedGroupId", groupId);
        else localStorage.removeItem("selectedGroupId");
      }
      if (companyId !== undefined) {
        state.selectedCompanyId = companyId;
        if (companyId) localStorage.setItem("selectedCompanyId", companyId);
        else localStorage.removeItem("selectedCompanyId");
      }
      if (periodId !== undefined) {
        state.selectedPeriodId = periodId;
        if (periodId) localStorage.setItem("selectedPeriodId", periodId);
        else localStorage.removeItem("selectedPeriodId");
      }
    },
  },
  extraReducers: (builder) => {
    builder
      // Logout cases
      .addCase(logoutAsync.fulfilled, () => {
        clearAuthStorage();
        return defaultState;
      })
      // Refresh cases
      .addCase(refreshAccessToken.fulfilled, (state, action) => {
        // Ignore a late-arriving refresh response after the user has logged out.
        if (!state.isLoggedIn) return;

        const { token, expiresAt, refreshToken } = action.payload || {};
        state.token = token ?? state.token;
        state.expiresAt = expiresAt ?? state.expiresAt;
        if (refreshToken) state.refreshToken = refreshToken;

        // Access token intentionally excluded from localStorage (stays in memory only).
        // Persist only non-sensitive fields.
        if (state.expiresAt) localStorage.setItem("expiresAt", state.expiresAt);
        if (state.refreshToken) localStorage.setItem("refreshToken", state.refreshToken);
      })
      // Reload init: refresh the cached initData without touching auth/session.
      .addCase(reloadInitData.fulfilled, (state, action) => {
        if (!state.isLoggedIn || !action.payload) return;
        state.initData = action.payload;
        localStorage.setItem("initData", JSON.stringify(action.payload));
      })
      .addCase(refreshAccessToken.rejected, () => {
        // Refresh failed (expired or network error) — force a clean logout so
        // the user is not stuck in isLoggedIn: true with no usable token.
        clearAuthStorage();
        return defaultState;
      })
      // Shared matchers: password login and SSO callback share auth success/failure
      .addMatcher(isAnyOf(loginAsync.pending, ssoCallbackAsync.pending), (state) => {
        state.loading = true;
        state.error = null;
      })
      .addMatcher(isAnyOf(loginAsync.fulfilled, ssoCallbackAsync.fulfilled), (state, action) => {
        state.loading = false;
        state.isLoggedIn = true;
        state.user = action.payload?.user || null;
        state.token = action.payload?.token || null;
        state.expiresAt = action.payload?.expiresAt || null;
        state.refreshToken = action.payload?.refreshToken || null;
        state.initData = action.payload?.initData || null;
        state.error = null;

        if (!state.selectedCompanyId) {
          const companyId = resolveDefaultCompanyId(state.initData);
          if (companyId) state.selectedCompanyId = companyId;
        }

        if (state.user) localStorage.setItem("user", JSON.stringify(state.user));
        if (state.initData) localStorage.setItem("initData", JSON.stringify(state.initData));
        if (state.refreshToken) localStorage.setItem("refreshToken", state.refreshToken);
        if (state.expiresAt) localStorage.setItem("expiresAt", state.expiresAt);
        if (state.selectedCompanyId) localStorage.setItem("selectedCompanyId", state.selectedCompanyId);
      })
      .addMatcher(isAnyOf(loginAsync.rejected, ssoCallbackAsync.rejected), (state, action) => {
        state.loading = false;
        state.isLoggedIn = false;
        state.user = null;
        state.token = null;
        state.refreshToken = null;
        state.error = action.payload || "Login failed";
      });
  },
});

export const { clearError, initSuccess, setContext } = authSlice.actions;

// Resolves user ID from various backend field naming conventions.
// Centralised here so every consumer reads from the same place rather
// than each maintaining its own fallback chain.
export function resolveUserId(user) {
  if (!user) return null;
  return user.id ?? user.userId ?? user._id ?? user.ID ?? user.UserID ?? null;
}

// Selectors
export const selectIsLoggedIn = (state) => state.auth.isLoggedIn;
export const selectToken = (state) => state.auth.token;
export const selectUser = (state) => state.auth.user;
export const selectUserId = (state) => resolveUserId(state.auth.user);
export const selectInitData = (state) => state.auth.initData;
export const selectUserCompanies = (state) => state.auth.initData?.userCompanies ?? [];
// The active company record (carries currentFinYear / currentFinMonth).
export const selectSelectedCompany = (state) => {
  const companies = state.auth.initData?.userCompanies ?? [];
  const id = state.auth.selectedCompanyId;
  return (
    companies.find((c) => c.companyId === id) ??
    companies.find((c) => c.isDefault) ??
    companies[0] ??
    null
  );
};
export const selectUserGroups = (state) => state.auth.initData?.userGroups ?? [];
export const selectUserTenants = (state) => state.auth.initData?.userTenants ?? [];

// Tenant-level settings (theme defaults, table/behavior flags) for the user's
// default tenant, as returned by the backend init call. Null until loaded.
export const selectTenantSettings = (state) => state.auth.initData?.tenantSettings ?? null;

// Effective permission codes for the logged-in user. Drives the permission gate.
export const selectPermissions = (state) => state.auth.initData?.permissions ?? [];

// Resolve the active tenant from init data.
// Prefer the tenant of the selected company, then the default tenant,
// then the default company's tenant. No hardcoded fallback.
export const selectTenantId = (state) => {
  const initData = state.auth.initData;
  if (!initData) return null;
  const companies = initData.userCompanies ?? [];
  const tenants = initData.userTenants ?? [];

  const selectedCompanyId = state.auth.selectedCompanyId;
  if (selectedCompanyId) {
    const match = companies.find((c) => c.companyId === selectedCompanyId);
    if (match?.tenantId) return match.tenantId;
  }

  const defaultTenant = tenants.find((t) => t.isDefault) ?? tenants[0];
  if (defaultTenant?.tenantId) return defaultTenant.tenantId;

  const defaultCompany = companies.find((c) => c.isDefault) ?? companies[0];
  return defaultCompany?.tenantId ?? null;
};
export const selectSelectedGroupId = (state) => state.auth.selectedGroupId;
export const selectSelectedCompanyId = (state) => state.auth.selectedCompanyId;
export const selectSelectedPeriodId = (state) => state.auth.selectedPeriodId;
export const selectAuthLoading = (state) => state.auth.loading;
export const selectAuthError = (state) => state.auth.error;

export default authSlice.reducer;
