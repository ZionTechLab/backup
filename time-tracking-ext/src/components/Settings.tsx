import React, { useEffect, useRef, useState } from 'react';
import { useSaveState } from '../hooks/useSaveState';
import * as TaskTypeService from '../services/TaskTypeService';
import { ProjectSettings } from './ProjectSettings';
import { RolesTab } from './RolesTab';
import { UserRolesTab } from './UserRolesTab';

type Tab = 'taskTypes' | 'projects' | 'roles' | 'userRoles';

export function Settings() {
  const [activeTab, setActiveTab] = useState<Tab>('taskTypes');

  return (
    <div className="settings-root">
      <h2 className="settings-title">TT Settings</h2>

      <div className="settings-tabs">
        <button
          className={`settings-tab${activeTab === 'taskTypes' ? ' settings-tab--active' : ''}`}
          onClick={() => setActiveTab('taskTypes')}
        >
          Task Types
        </button>
        <button
          className={`settings-tab${activeTab === 'projects' ? ' settings-tab--active' : ''}`}
          onClick={() => setActiveTab('projects')}
        >
          Project Settings
        </button>
        <button
          className={`settings-tab${activeTab === 'roles' ? ' settings-tab--active' : ''}`}
          onClick={() => setActiveTab('roles')}
        >
          Roles
        </button>
        <button
          className={`settings-tab${activeTab === 'userRoles' ? ' settings-tab--active' : ''}`}
          onClick={() => setActiveTab('userRoles')}
        >
          User Roles
        </button>
      </div>

      <div className="settings-tab-content">
        {activeTab === 'taskTypes' && <TaskTypeTab />}
        {activeTab === 'projects' && <ProjectSettings />}
        {activeTab === 'roles' && <RolesTab />}
        {activeTab === 'userRoles' && <UserRolesTab />}
      </div>
    </div>
  );
}

function TaskTypeTab() {
  const [taskTypes, setTaskTypes] = useState<string[]>([]);
  const [amcTaskTypes, setAmcTaskTypes] = useState<string[]>([]);
  const [loading, setLoading] = useState(true);
  const { saving, error, success, setError, withSaveState } = useSaveState();
  const [inputValue, setInputValue] = useState('');
  const inputRef = useRef<HTMLInputElement>(null);

  useEffect(() => {
    Promise.all([
      TaskTypeService.getTaskTypes(),
      TaskTypeService.getAmcTaskTypes(),
    ])
      .then(([types, amc]) => { setTaskTypes(types); setAmcTaskTypes(amc); })
      .catch(e => setError(e?.message ?? 'Failed to load task types.'))
      .finally(() => setLoading(false));
  }, []);

  async function persist(updated: string[]) {
    await withSaveState(async () => {
      await TaskTypeService.saveTaskTypes(updated);
      setTaskTypes(updated);
    });
  }

  async function toggleAmc(label: string) {
    const next = amcTaskTypes.includes(label)
      ? amcTaskTypes.filter(t => t !== label)
      : [...amcTaskTypes, label];
    setAmcTaskTypes(next);
    await TaskTypeService.saveAmcTaskTypes(next);
  }

  function handleAdd() {
    const label = inputValue.trim();
    if (!label) return;
    if (taskTypes.some(t => t.toLowerCase() === label.toLowerCase())) {
      setError(`"${label}" already exists.`);
      return;
    }
    setInputValue('');
    persist([...taskTypes, label]);
    inputRef.current?.focus();
  }

  function handleDelete(index: number) {
    const label = taskTypes[index];
    const nextAmc = amcTaskTypes.filter(t => t !== label);
    if (nextAmc.length !== amcTaskTypes.length) {
      setAmcTaskTypes(nextAmc);
      TaskTypeService.saveAmcTaskTypes(nextAmc);
    }
    persist(taskTypes.filter((_, i) => i !== index));
  }

  function handleKeyDown(e: React.KeyboardEvent) {
    if (e.key === 'Enter') { e.preventDefault(); handleAdd(); }
  }

  return (
    <div>
      <p className="settings-desc">
        Define the task type labels available when logging time. Changes apply organisation-wide.
      </p>

      {error && (
        <div className="error-banner" role="alert">
          {error}
          <button className="error-dismiss" onClick={() => setError('')} aria-label="Dismiss">×</button>
        </div>
      )}
      {success && <div className="success-banner" role="status">{success}</div>}

      {loading ? (
        <div className="loading-state">Loading…</div>
      ) : (
        <>
          <ul className="task-type-list">
            {taskTypes.length === 0 && (
              <li className="task-type-empty">No task types yet. Add one below.</li>
            )}
            {taskTypes.map((label, i) => (
              <li key={i} className="task-type-item">
                <label className="task-type-amc-toggle">
                  <input
                    type="checkbox"
                    checked={amcTaskTypes.includes(label)}
                    onChange={() => toggleAmc(label)}
                    disabled={saving}
                  />
                  <span className="amc-badge">AMC</span>
                </label>
                <span className="task-type-label">{label}</span>
                <button
                  className="action-btn action-btn--danger"
                  onClick={() => handleDelete(i)}
                  disabled={saving}
                  aria-label={`Remove ${label}`}
                >
                  Remove
                </button>
              </li>
            ))}
          </ul>

          <div className="settings-add-row">
            <input
              ref={inputRef}
              type="text"
              className="settings-input"
              placeholder="New task type…"
              value={inputValue}
              onChange={e => setInputValue(e.target.value)}
              onKeyDown={handleKeyDown}
              disabled={saving}
              maxLength={60}
            />
            <button
              className="btn btn-primary"
              onClick={handleAdd}
              disabled={saving || !inputValue.trim()}
            >
              {saving ? 'Saving…' : 'Add'}
            </button>
          </div>
        </>
      )}
    </div>
  );
}
