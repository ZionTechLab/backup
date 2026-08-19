import React, { useCallback, useEffect, useRef, useState } from 'react';
import { GroupBy, ReportEntry, ReportFilters, ReportResult } from '../../models/ReportEntry';
import {
  applyAmcCategories,
  applyCostCenters,
  applyFilters,
  buildReport,
  enrichEntries,
  getDistinctOptions,
  loadRawEntries,
} from '../../services/ReportService';
import { getAmcTaskTypes } from '../../services/TaskTypeService';
import { getNameToCostCenterMap } from '../../services/ProjectSettingsService';
import { SelectOption } from './MultiSelect';
import { FilterBar } from './FilterBar';
import { SummaryStrip } from './SummaryStrip';
import { ReportTable } from './ReportTable';
import { currentMonthRange, localDateStr } from '../../utils/dateUtils';

const DEFAULT_FILTERS: ReportFilters = {
  ...currentMonthRange(),
  projects: [],
  users: [],
  taskTypes: [],
  costCenters: [],
};

export function Report() {
  const [allEntries, setAllEntries] = useState<ReportEntry[]>([]);
  const [loading, setLoading] = useState(true);
  const [enriching, setEnriching] = useState(false);
  const [error, setError] = useState('');

  const [filters, setFilters] = useState<ReportFilters>(DEFAULT_FILTERS);
  const [groupBy, setGroupBy] = useState<GroupBy>('user');

  // Keep a ref to the latest groupBy so phase-2 callbacks use the current value
  const groupByRef = useRef<GroupBy>('user');
  groupByRef.current = groupBy;

  const [filteredEntries, setFilteredEntries] = useState<ReportEntry[]>([]);
  const [result, setResult] = useState<ReportResult | null>(null);

  const [projectOptions, setProjectOptions] = useState<SelectOption[]>([]);
  const [userOptions, setUserOptions] = useState<SelectOption[]>([]);
  const [taskTypeOptions, setTaskTypeOptions] = useState<SelectOption[]>([]);
  const [costCenterOptions, setCostCenterOptions] = useState<SelectOption[]>([]);

  // Stable ref so phase-2 callback can read latest filters
  const filtersRef = useRef<ReportFilters>(DEFAULT_FILTERS);
  filtersRef.current = filters;

  function applyAndBuild(entries: ReportEntry[], f: ReportFilters, g: GroupBy) {
    const filtered = applyFilters(entries, f);
    setFilteredEntries(filtered);
    setResult(buildReport(filtered, g));
  }

  function refreshOptions(entries: ReportEntry[]) {
    const opts = getDistinctOptions(entries);
    setProjectOptions(opts.projects.map(p => ({ value: p, label: p })));
    setUserOptions(opts.users.map(u => ({ value: u.id, label: u.name })));
    setTaskTypeOptions(opts.taskTypes.map(t => ({ value: t, label: t })));
    setCostCenterOptions(opts.costCenters.map(c => ({ value: c, label: c })));
  }

  useEffect(() => {
    Promise.all([loadRawEntries(), getNameToCostCenterMap(), getAmcTaskTypes()])
      .then(([raw, ccMap, amcTypes]) => {
        const withCC = applyCostCenters(raw, ccMap);
        const withCat = applyAmcCategories(withCC, amcTypes);
        setAllEntries(withCat);
        refreshOptions(withCat);
        applyAndBuild(withCat, DEFAULT_FILTERS, 'user');
        setLoading(false);

        if (raw.length === 0) return;
        setEnriching(true);
        enrichEntries(raw)
          .then(enriched => {
            const enrichedWithCC = applyCostCenters(enriched, ccMap);
            const enrichedWithCat = applyAmcCategories(enrichedWithCC, amcTypes);
            setAllEntries(enrichedWithCat);
            refreshOptions(enrichedWithCat);
            applyAndBuild(enrichedWithCat, filtersRef.current, groupByRef.current);
          })
          .catch(e => console.warn('[TT Report] Enrichment failed:', e))
          .finally(() => setEnriching(false));
      })
      .catch(e => {
        setError(e?.message ?? 'Failed to load time entries.');
        setLoading(false);
      });
  }, []);

  const handleApply = useCallback((newFilters: ReportFilters) => {
    setFilters(newFilters);
    applyAndBuild(allEntries, newFilters, groupBy);
  }, [allEntries, groupBy]);

  function handleGroupByChange(g: GroupBy) {
    setGroupBy(g);
    if (result) setResult(buildReport(filteredEntries, g));
  }

  const groupByLabel = (g: GroupBy) =>
    g === 'user' ? 'User' : g === 'project' ? 'Project' : g === 'costCenter' ? 'Cost Centre' : g === 'date' ? 'Date' : 'Category';

  return (
    <div className="report-root">
      <div className="report-header">
        <h2 className="report-title">Time Tracking Report</h2>
        <div className="groupby-toggle">
          <span className="groupby-label">Group by</span>
          {(['user', 'project', 'costCenter', 'category', 'date'] as GroupBy[]).map(g => (
            <button
              key={g}
              className={`groupby-btn ${groupBy === g ? 'groupby-btn--active' : ''}`}
              onClick={() => handleGroupByChange(g)}
              disabled={loading}
            >
              {groupByLabel(g)}
            </button>
          ))}
        </div>
      </div>

      {error && <div className="error-banner" role="alert">{error}</div>}

      <FilterBar
        filters={filters}
        projectOptions={projectOptions}
        userOptions={userOptions}
        taskTypeOptions={taskTypeOptions}
        costCenterOptions={costCenterOptions}
        onApply={handleApply}
        disabled={loading}
      />

      {loading ? (
        <div className="loading-state">Loading time entries…</div>
      ) : result ? (
        <>
          {enriching && (
            <div className="enrich-banner">Loading project and work item details…</div>
          )}
          <SummaryStrip result={result} filteredEntries={filteredEntries} />
          <ReportTable result={result} groupBy={groupBy} filteredEntries={filteredEntries} />
        </>
      ) : (
        <p className="empty-state">No entries match the selected filters.</p>
      )}
    </div>
  );
}
