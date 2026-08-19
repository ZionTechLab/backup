import React, { useEffect, useState } from 'react';
import { useSaveState } from '../hooks/useSaveState';
import * as ProjectSettingsService from '../services/ProjectSettingsService';
import { ProjectSettingEntry } from '../services/ProjectSettingsService';

interface Row {
  projectId: string;
  projectName: string;
  costCenter: string;
}

export function ProjectSettings() {
  const [rows, setRows] = useState<Row[]>([]);
  const [dirty, setDirty] = useState<Record<string, string>>({}); // projectId → edited costCenter
  const [loading, setLoading] = useState(true);
  const { saving, error, success, setError, withSaveState } = useSaveState();

  useEffect(() => {
    Promise.all([
      ProjectSettingsService.fetchADOProjects(),
      ProjectSettingsService.getStoredSettings(),
    ])
      .then(([projects, stored]) => {
        setRows(projects.map(p => ({
          projectId: p.id,
          projectName: p.name,
          costCenter: stored[p.id]?.costCenter ?? '',
        })));
      })
      .catch(e => setError(e?.message ?? 'Failed to load projects.'))
      .finally(() => setLoading(false));
  }, []);

  function handleChange(projectId: string, value: string) {
    setDirty(prev => ({ ...prev, [projectId]: value }));
  }

  const isDirty = Object.keys(dirty).length > 0;

  async function handleSave() {
    await withSaveState(async () => {
      const merged: Record<string, ProjectSettingEntry> = {};
      for (const row of rows) {
        const costCenter = dirty.hasOwnProperty(row.projectId)
          ? dirty[row.projectId]
          : row.costCenter;
        merged[row.projectId] = { name: row.projectName, costCenter };
      }
      await ProjectSettingsService.saveSettings(merged);
      setRows(prev => prev.map(r => ({
        ...r,
        costCenter: merged[r.projectId]?.costCenter ?? '',
      })));
      setDirty({});
    });
  }

  return (
    <div>
      <p className="settings-desc">
        Assign a cost centre code to each project. Used for grouping in the report.
      </p>

      {error && (
        <div className="error-banner" role="alert">
          {error}
          <button className="error-dismiss" onClick={() => setError('')} aria-label="Dismiss">×</button>
        </div>
      )}
      {success && <div className="success-banner" role="status">{success}</div>}

      {loading ? (
        <div className="loading-state">Loading projects…</div>
      ) : (
        <>
          <div className="proj-toolbar">
            <button
              className="btn btn-primary"
              onClick={handleSave}
              disabled={!isDirty || saving}
            >
              {saving ? 'Saving…' : 'Save Changes'}
            </button>
            {isDirty && !saving && (
              <span className="proj-unsaved">Unsaved changes</span>
            )}
          </div>

          <div className="proj-table-wrap">
            <table className="entry-table proj-table">
              <thead>
                <tr>
                  <th>Project</th>
                  <th className="proj-col-cc">Cost Centre</th>
                </tr>
              </thead>
              <tbody>
                {rows.length === 0 && (
                  <tr>
                    <td colSpan={2} className="proj-empty">No projects found.</td>
                  </tr>
                )}
                {rows.map(row => {
                  const value = dirty.hasOwnProperty(row.projectId)
                    ? dirty[row.projectId]
                    : row.costCenter;
                  return (
                    <tr key={row.projectId}>
                      <td>{row.projectName}</td>
                      <td className="proj-col-cc">
                        <input
                          type="text"
                          className="proj-cc-input"
                          value={value}
                          onChange={e => handleChange(row.projectId, e.target.value)}
                          placeholder="e.g. CC-1234"
                          maxLength={40}
                          disabled={saving}
                          aria-label={`Cost Centre for ${row.projectName}`}
                        />
                      </td>
                    </tr>
                  );
                })}
              </tbody>
            </table>
          </div>
        </>
      )}
    </div>
  );
}
