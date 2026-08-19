import { useTheme } from '../../hooks/useTheme';
import { UI_THEME_OPTIONS, COLOR_THEME_OPTIONS } from '../../config/themeOptions';

const mainColorOptions = COLOR_THEME_OPTIONS.filter((o) => !o.group);
const specializedColorOptions = COLOR_THEME_OPTIONS.filter((o) => o.group === 'Specialized Palettes');

const ThemeSettings = () => {
  const { uiTheme, colorTheme, menuStyle, changeUiTheme, changeColorTheme, changeMenuStyle, isDark, toggleDark } = useTheme();

  return (
    <div className="container-fluid p-4">
      <h4 className="mb-4">Theme Settings</h4>

      <div className="row g-4">
        {/* Dark / Light mode */}
        <div className="col-12 col-md-6 col-lg-3">
          <div className="card h-100">
            <div className="card-body">
              <h5 className="card-title">Mode</h5>
              <p className="text-muted small">Toggle between light and dark appearance.</p>
              <div className="form-check form-switch">
                <input
                  className="form-check-input"
                  type="checkbox"
                  id="darkModeSwitch"
                  checked={isDark}
                  onChange={toggleDark}
                />
                <label className="form-check-label" htmlFor="darkModeSwitch">
                  {isDark ? 'Dark mode' : 'Light mode'}
                </label>
              </div>
            </div>
          </div>
        </div>

        {/* UI Theme */}
        <div className="col-12 col-md-6 col-lg-3">
          <div className="card h-100">
            <div className="card-body">
              <h5 className="card-title">UI Style</h5>
              <p className="text-muted small">Choose the visual style for components.</p>
              <select
                id="uiThemeSelect"
                className="form-select"
                value={uiTheme}
                onChange={changeUiTheme}
                aria-label="Select UI theme"
              >
                {UI_THEME_OPTIONS.map((o) => (
                  <option key={o.value} value={o.value}>{o.label}</option>
                ))}
              </select>
            </div>
          </div>
        </div>

        {/* Color Theme */}
        <div className="col-12 col-md-6 col-lg-3">
          <div className="card h-100">
            <div className="card-body">
              <h5 className="card-title">Color Palette</h5>
              <p className="text-muted small">Pick a color scheme for the interface.</p>
              <select
                id="colorThemeSelect"
                className="form-select"
                value={colorTheme}
                onChange={changeColorTheme}
                aria-label="Select color theme"
              >
                {mainColorOptions.map((o) => (
                  <option key={o.value} value={o.value}>{o.label}</option>
                ))}
                <optgroup label="Specialized Palettes">
                  {specializedColorOptions.map((o) => (
                    <option key={o.value} value={o.value}>{o.label}</option>
                  ))}
                </optgroup>
              </select>
            </div>
          </div>
        </div>

        {/* Menu Style */}
        <div className="col-12 col-md-6 col-lg-3">
          <div className="card h-100">
            <div className="card-body">
              <h5 className="card-title">Menu Contrast</h5>
              <p className="text-muted small">Variance between the navigation menu and workspace.</p>
              <select
                id="menuStyleSelect"
                className="form-select"
                value={menuStyle}
                onChange={changeMenuStyle}
                aria-label="Select menu style"
              >
                <option value="subtle">Subtle</option>
                <option value="distinct">Distinct</option>
                <option value="contrast">High Contrast (Dark)</option>
              </select>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ThemeSettings;
