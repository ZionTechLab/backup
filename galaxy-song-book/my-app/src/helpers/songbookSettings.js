const STORAGE_KEY = 'songbook_settings_v1';

const defaultSettings = {
  fontFamily: 'serif',
  fontSizePx: 18,
  lineHeight: 1.6,
  textAlign: 'left',
  // Title-specific settings
  titleFontFamily: null,
  titleFontSizePx: null,
  titleLineHeight: null,
  titleTextAlign: null,
};

export function getSongbookSettings() {
  try {
    const raw = localStorage.getItem(STORAGE_KEY);
    if (!raw) return { ...defaultSettings };
    const parsed = JSON.parse(raw);
    return { ...defaultSettings, ...parsed };
  } catch (e) {
    return { ...defaultSettings };
  }
}

export function saveSongbookSettings(settings) {
  try {
    const toSave = { ...getSongbookSettings(), ...settings };
    localStorage.setItem(STORAGE_KEY, JSON.stringify(toSave));
    // Dispatch a storage event for same-window listeners
    try {
      window.dispatchEvent(new StorageEvent('storage', { key: STORAGE_KEY, newValue: JSON.stringify(toSave) }));
    } catch (e) {
      // ignore
    }
    return toSave;
  } catch (e) {
    return null;
  }
}

export function resetSongbookSettings() {
  localStorage.removeItem(STORAGE_KEY);
}

export default {
  getSongbookSettings,
  saveSongbookSettings,
  resetSongbookSettings,
};
