import { createContext, useContext, useState, useEffect } from 'react';
import { useSelector } from 'react-redux';
import { selectTenantSettings } from '../features/auth';

const ThemeContext = createContext(null);

// Hardcoded last-resort fallbacks, used only until a tenant default is known
// (e.g. before first login on a fresh browser).
const HARDCODED_DEFAULTS = { isDark: true, uiTheme: 'material', colorTheme: 'default' };

// A value in localStorage means the user personally overrode the tenant
// default. Absent that, the tenant's default (from DB) wins; absent that too,
// fall back to the hardcoded default above.
const resolveInitial = (storageKey, tenantValue, fallback) => {
  const stored = localStorage.getItem(storageKey);
  if (stored !== null) return stored;
  return tenantValue ?? fallback;
};

export const ThemeProvider = ({ children }) => {
  const tenantSettings = useSelector(selectTenantSettings);

  const [uiTheme, setUiTheme] = useState(() => resolveInitial('uiTheme', tenantSettings?.uiTheme, HARDCODED_DEFAULTS.uiTheme));
  const [colorTheme, setColorTheme] = useState(() => resolveInitial('colorTheme', tenantSettings?.colorTheme, HARDCODED_DEFAULTS.colorTheme));
  const [menuStyle, setMenuStyle] = useState('distinct');
  const [isDark, setIsDark] = useState(() => {
    const saved = resolveInitial('theme', tenantSettings?.theme, HARDCODED_DEFAULTS.isDark ? 'dark' : 'light');
    return saved === 'dark';
  });

  // Dark mode
  useEffect(() => {
    document.documentElement.classList.toggle('ml-light', !isDark);
    document.documentElement.setAttribute('data-bs-theme', isDark ? 'dark' : 'light');
  }, [isDark]);

  const toggleDark = () => {
    setIsDark((v) => {
      const next = !v;
      localStorage.setItem('theme', next ? 'dark' : 'light');
      return next;
    });
  };

  // UI Theme change logic — explicit user choice, persisted as a personal override.
  const changeUiTheme = (e) => {
    const value = e.target.value;
    setUiTheme(value);
    document.documentElement.setAttribute('data-theme', value);
    localStorage.setItem('uiTheme', value);
  };

  // Color theme change logic — explicit user choice, persisted as a personal override.
  const changeColorTheme = (e) => {
    const value = e.target.value;
    setColorTheme(value);
    if (value === 'default') {
      document.documentElement.removeAttribute('data-color');
    } else {
      document.documentElement.setAttribute('data-color', value);
    }
    localStorage.setItem('colorTheme', value);
  };

  // Menu style change logic
  const changeMenuStyle = (e) => {
    const value = e.target.value;
    setMenuStyle(value);
    document.documentElement.setAttribute('data-menu-style', value);
    localStorage.setItem('menuStyle', value);
  };

  // Apply the initial (mount-time) theme attributes.
  useEffect(() => {
    document.documentElement.setAttribute('data-theme', uiTheme);
    if (colorTheme === 'default') {
      document.documentElement.removeAttribute('data-color');
    } else {
      document.documentElement.setAttribute('data-color', colorTheme);
    }
    const savedMenuStyle = localStorage.getItem('menuStyle') || 'distinct';
    setMenuStyle(savedMenuStyle);
    document.documentElement.setAttribute('data-menu-style', savedMenuStyle);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  // Tenant settings can arrive asynchronously after mount (fresh login/SSO).
  // If the user has never personally overridden a value, adopt the tenant
  // default once it loads (or changes) — without writing to localStorage, so
  // it keeps tracking the tenant default rather than becoming a fixed override.
  useEffect(() => {
    if (!tenantSettings) return;

    if (localStorage.getItem('uiTheme') === null && tenantSettings.uiTheme && tenantSettings.uiTheme !== uiTheme) {
      setUiTheme(tenantSettings.uiTheme);
      document.documentElement.setAttribute('data-theme', tenantSettings.uiTheme);
    }
    if (localStorage.getItem('colorTheme') === null && tenantSettings.colorTheme && tenantSettings.colorTheme !== colorTheme) {
      setColorTheme(tenantSettings.colorTheme);
      if (tenantSettings.colorTheme === 'default') {
        document.documentElement.removeAttribute('data-color');
      } else {
        document.documentElement.setAttribute('data-color', tenantSettings.colorTheme);
      }
    }
    if (localStorage.getItem('theme') === null && tenantSettings.theme) {
      const tenantIsDark = tenantSettings.theme === 'dark';
      if (tenantIsDark !== isDark) setIsDark(tenantIsDark);
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [tenantSettings]);

  return (
    <ThemeContext.Provider value={{ uiTheme, colorTheme, menuStyle, isDark, toggleDark, changeUiTheme, changeColorTheme, changeMenuStyle }}>
      {children}
    </ThemeContext.Provider>
  );
};

export const useTheme = () => {
  const ctx = useContext(ThemeContext);
  if (!ctx) throw new Error('useTheme must be used within ThemeProvider');
  return ctx;
};
