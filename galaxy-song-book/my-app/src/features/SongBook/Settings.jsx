import { useState, useEffect } from 'react';
import { getSongbookSettings, saveSongbookSettings, resetSongbookSettings } from '../../helpers/songbookSettings';
import { useNavigate } from 'react-router-dom';

function SongSettings() {
  const navigate = useNavigate();
  const [settings, setSettings] = useState(getSongbookSettings());

  useEffect(() => {
    setSettings(getSongbookSettings());
  }, []);

  const update = (patch) => {
    const next = { ...settings, ...patch };
    setSettings(next);
    saveSongbookSettings(next);
  };

  const handleReset = () => {
    resetSongbookSettings();
    const def = getSongbookSettings();
    setSettings(def);
  };

  return (
    <div className="container mt-3">
      <h4>Song View Settings</h4>
      <div className="card p-3 mt-2">
        <h5>Title Settings</h5>
        <div className="mb-2">
          <label className="form-label">Title Font Family</label>
          <select className="form-select" value={settings.titleFontFamily || ''} onChange={e => update({ titleFontFamily: e.target.value || null })}>
            <option value="">(use body font)</option>
            <option value="serif">Serif</option>
            <option value="sans-serif">Sans Serif</option>
            <option value="monospace">Monospace</option>
            <option value="Google Sans, system-ui, sans-serif">Google Sans</option>
            <option value="Abhaya Libre, serif">Abhaya Libre</option>
            <option value="Noto Sans Sinhala, sans-serif">Noto Sans Sinhala</option>
            <option value="Gemunu Libre, sans-serif">Gemunu Libre</option>
            <option value="Noto Serif Sinhala, serif">Noto Serif Sinhala</option>
            <option value="Yaldevi, serif">Yaldevi</option>
            <option value="Maname, serif">Maname</option>
          </select>
        </div>

        <div className="mb-2">
          <label className="form-label">Title Font Size (px)</label>
          <input type="number" className="form-control" value={settings.titleFontSizePx ?? ''} min={10} max={96} onChange={e => update({ titleFontSizePx: e.target.value ? Number(e.target.value) : null })} />
        </div>

        <div className="mb-2">
          <label className="form-label">Title Line Height</label>
          <input type="number" step="0.1" className="form-control" value={settings.titleLineHeight ?? ''} min={1} max={3} onChange={e => update({ titleLineHeight: e.target.value ? Number(e.target.value) : null })} />
        </div>

        <div className="mb-3">
          <label className="form-label">Title Text Align</label>
          <select className="form-select" value={settings.titleTextAlign || ''} onChange={e => update({ titleTextAlign: e.target.value || null })}>
            <option value="">(use body align)</option>
            <option value="left">Left</option>
            <option value="center">Center</option>
            <option value="justify">Justify</option>
          </select>
        </div>

        <div className="mb-2">
          <label className="form-label">Font Family</label>
          <select className="form-select" value={settings.fontFamily} onChange={e => update({ fontFamily: e.target.value })}>
            <option value="serif">Serif</option>
            <option value="sans-serif">Sans Serif</option>
            <option value="monospace">Monospace</option>
            <option value="Google Sans, system-ui, sans-serif">Google Sans</option>
            <option value="Abhaya Libre, serif">Abhaya Libre</option>
            <option value="Noto Sans Sinhala, sans-serif">Noto Sans Sinhala</option>
            <option value="Gemunu Libre, sans-serif">Gemunu Libre</option>
            <option value="Noto Serif Sinhala, serif">Noto Serif Sinhala</option>
            <option value="Yaldevi, serif">Yaldevi</option>
            <option value="Maname, serif">Maname</option>
          </select>
        </div>

        <div className="mb-2">
          <label className="form-label">Font Size (px)</label>
          <input type="number" className="form-control" value={settings.fontSizePx} min={12} max={48} onChange={e => update({ fontSizePx: Number(e.target.value) || 12 })} />
        </div>

        <div className="mb-2">
          <label className="form-label">Line Height</label>
          <input type="number" step="0.1" className="form-control" value={settings.lineHeight} min={1} max={3} onChange={e => update({ lineHeight: Number(e.target.value) || 1 })} />
        </div>

        <div className="mb-3">
          <label className="form-label">Text Align</label>
          <select className="form-select" value={settings.textAlign} onChange={e => update({ textAlign: e.target.value })}>
            <option value="left">Left</option>
            <option value="center">Center</option>
            <option value="justify">Justify</option>
          </select>
        </div>

        <div className="d-flex gap-2">
          <button className="btn btn-primary" onClick={() => navigate(-1)}>Back</button>
          <button className="btn btn-outline-secondary" onClick={handleReset}>Reset</button>
        </div>
      </div>
    </div>
  );
}

export default SongSettings;
