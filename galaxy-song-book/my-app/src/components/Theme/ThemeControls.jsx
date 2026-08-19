
import { useTheme } from '../../hooks/useTheme';

const ThemeControls = ({ isMinimized }) => {
  const { uiTheme, colorTheme, changeUiTheme, changeColorTheme } = useTheme();

  // Dark mode lives in the top bar only. This footer keeps the UI and color themes.
  return (
    <div className="drawer-footer mt-auto p-3 border-top">
      <div className="d-flex flex-column gap-2">
        {!isMinimized && (
          <div className="m-0">
            <label htmlFor="uiThemeSelect" className="form-label mb-1">Theme</label>
            <select
              id="uiThemeSelect"
              className="form-select form-select-sm"
              value={uiTheme}
              onChange={changeUiTheme}
              aria-label="Select UI theme"
              title="Select UI theme"
            >
              <option value="flat">Flat UI (current)</option>
              <option value="material">Material</option>
              <option value="round">Round Corners</option>
              <option value="paper">Paper-like</option>
              <option value="glass">Glass</option>
              <option value="soft">Soft</option>
              <option value="fluent">Fluent (Microsoft)</option>
            </select>
          </div>
        )}

        {!isMinimized && (
          <div className="m-0">
            <label htmlFor="colorThemeSelect" className="form-label mb-1">Color</label>
            <select
              id="colorThemeSelect"
              className="form-select form-select-sm"
              value={colorTheme}
              onChange={changeColorTheme}
              aria-label="Select color theme"
              title="Select color theme"
            >
              <option value="default">Default</option>
              <option value="ocean">Ocean</option>
              <option value="forest">Forest</option>
              <option value="sunset">Sunset</option>
              <option value="grape">Grape</option>
              <option value="slate">Slate</option>
              <option value="candy">Candy (Bright Pink)</option>
              <option value="aqua">Aqua (Bright Cyan)</option>
              <option value="citrus">Citrus (Bright Lime)</option>
              <option value="flamingo">Flamingo (Coral)</option>
              <option value="sky">Sky (Bright Blue) — Default</option>
              <option value="datta">Datta (Dashboard Style)</option>
              <optgroup label="Old style">
                <option value="sepia">Sepia</option>
                <option value="newspaper">Newspaper</option>
                <option value="terminal">Terminal</option>
                <option value="vintage">Vintage</option>
              </optgroup>
              <optgroup label="Fancy">
                <option value="neon">Neon</option>
                <option value="aurora">Aurora</option>
                <option value="luxe">Luxe</option>
              </optgroup>
            </select>
          </div>
        )}
      </div>
    </div>
  );
};

export default ThemeControls;
