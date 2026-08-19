import React from 'react';
import { ReportFilters } from '../../models/ReportEntry';
import { MultiSelect, SelectOption } from './MultiSelect';

interface Props {
  filters: ReportFilters;
  projectOptions: SelectOption[];
  userOptions: SelectOption[];
  taskTypeOptions: SelectOption[];
  costCenterOptions: SelectOption[];
  onApply: (filters: ReportFilters) => void;
  disabled?: boolean;
}

export function FilterBar({ filters, projectOptions, userOptions, taskTypeOptions, costCenterOptions, onApply, disabled }: Props) {
  const [draft, setDraft] = React.useState<ReportFilters>(filters);

  React.useEffect(() => { setDraft(filters); }, [filters]);

  function set<K extends keyof ReportFilters>(key: K, value: ReportFilters[K]) {
    setDraft(f => ({ ...f, [key]: value }));
  }

  function handleClear() {
    const cleared: ReportFilters = {
      ...draft,
      projects: [],
      users: [],
      taskTypes: [],
      costCenters: [],
    };
    setDraft(cleared);
    onApply(cleared);
  }

  return (
    <div className="filter-bar">
      <div className="filter-bar-row">
        <div className="filter-field">
          <label className="filter-label" htmlFor="filter-date-from">From</label>
          <input
            id="filter-date-from"
            type="date"
            className="filter-input"
            value={draft.dateFrom}
            onChange={e => set('dateFrom', e.target.value)}
            disabled={disabled}
          />
        </div>

        <div className="filter-field">
          <label className="filter-label" htmlFor="filter-date-to">To</label>
          <input
            id="filter-date-to"
            type="date"
            className="filter-input"
            value={draft.dateTo}
            onChange={e => set('dateTo', e.target.value)}
            disabled={disabled}
          />
        </div>

        <div className="filter-field">
          <label className="filter-label">Project</label>
          <MultiSelect
            label="Projects"
            options={projectOptions}
            selected={draft.projects}
            onChange={v => set('projects', v)}
            disabled={disabled}
          />
        </div>

        <div className="filter-field">
          <label className="filter-label">Cost Centre</label>
          <MultiSelect
            label="Cost Centres"
            options={costCenterOptions}
            selected={draft.costCenters}
            onChange={v => set('costCenters', v)}
            disabled={disabled}
          />
        </div>

        <div className="filter-field">
          <label className="filter-label">User</label>
          <MultiSelect
            label="Users"
            options={userOptions}
            selected={draft.users}
            onChange={v => set('users', v)}
            disabled={disabled}
          />
        </div>

        <div className="filter-field">
          <label className="filter-label">Task Type</label>
          <MultiSelect
            label="Types"
            options={taskTypeOptions}
            selected={draft.taskTypes}
            onChange={v => set('taskTypes', v)}
            disabled={disabled}
          />
        </div>

        <div className="filter-field filter-field--actions">
          <label className="filter-label">&nbsp;</label>
          <div className="filter-buttons">
            <button className="btn btn-primary" onClick={() => onApply(draft)} disabled={disabled}>
              Apply
            </button>
            <button className="btn btn-secondary" onClick={handleClear} disabled={disabled}>
              Clear
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}
