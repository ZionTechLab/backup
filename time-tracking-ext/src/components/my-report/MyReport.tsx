import React, { useCallback, useEffect, useRef, useState } from 'react';
import * as SDK from 'azure-devops-extension-sdk';
import { GroupBy, ReportEntry, ReportFilters, ReportResult } from '../../models/ReportEntry';
import {
  applyCostCenters,
  applyFilters,
  buildReport,
  enrichEntries,
  loadRawEntries,
} from '../../services/ReportService';
import { getNameToCostCenterMap } from '../../services/ProjectSettingsService';
import { ReportTable } from '../report/ReportTable';
import { SummaryStrip } from '../report/SummaryStrip';
import { currentMonthRange, localDateStr } from '../../utils/dateUtils';

const DEFAULT_FILTERS: ReportFilters = {
  ...currentMonthRange(),
  projects: [],
  users: [],
  taskTypes: [],
  costCenters: [],
};

export function MyReport() {
  const [allEntries, setAllEntries] = useState<ReportEntry[]>([]);
  const [loading, setLoading] = useState(true);
  const [enriching, setEnriching] = useState(false);
  const [error, setError] = useState('');

  const [filters, setFilters] = useState<ReportFilters>(DEFAULT_FILTERS);
  const groupBy: GroupBy = 'date';

  const [filteredEntries, setFilteredEntries] = useState<ReportEntry[]>([]);
  const [result, setResult] = useState<ReportResult | null>(null);

  const filtersRef = useRef<ReportFilters>(DEFAULT_FILTERS);
  filtersRef.current = filters;

  function applyAndBuild(entries: ReportEntry[], f: ReportFilters) {
    const filtered = applyFilters(entries, f);
    setFilteredEntries(filtered);
    setResult(buildReport(filtered, groupBy));
  }

  useEffect(() => {
    Promise.all([loadRawEntries(), getNameToCostCenterMap()])
      .then(([raw, ccMap]) => {
        const user = SDK.getUser();
        const userId = user.id;
        const userName = user.displayName;

        // Filter all entries to only include the current user
        const userRaw = raw.filter(e => e.createdBy === userName || e.createdById === userId);

        const withCC = applyCostCenters(userRaw, ccMap);
        setAllEntries(withCC);

        // Ensure filters are locked to the user
        const userFilters = { ...DEFAULT_FILTERS, users: [userName] };
        setFilters(userFilters);
        filtersRef.current = userFilters;

        applyAndBuild(withCC, userFilters);
        setLoading(false);

        if (userRaw.length === 0) return;
        setEnriching(true);
        enrichEntries(userRaw)
          .then(enriched => {
            const enrichedWithCC = applyCostCenters(enriched, ccMap);
            setAllEntries(enrichedWithCC);
            applyAndBuild(enrichedWithCC, filtersRef.current);
          })
          .catch(e => console.warn('[TT My Report] Enrichment failed:', e))
          .finally(() => setEnriching(false));
      })
      .catch(e => {
        setError(e?.message ?? 'Failed to load time entries.');
        setLoading(false);
      });
  }, []);

  const handleApply = useCallback((newFilters: ReportFilters) => {
    setFilters(newFilters);
    applyAndBuild(allEntries, newFilters);
  }, [allEntries]);

  function handleDateChange(field: 'dateFrom' | 'dateTo', value: string) {
    const newFilters = { ...filters, [field]: value };
    handleApply(newFilters);
  }

  return (
    <div className="report-root">
      <div className="report-header">
        <h2 className="report-title">My Time Report</h2>
        <div className="groupby-toggle">
          <span className="groupby-label">Grouped by Date</span>
        </div>
      </div>

      {error && <div className="error-banner" role="alert">{error}</div>}

      <div className="filter-bar">
        <div className="filter-group">
          <label className="filter-label" htmlFor="my-date-from">From</label>
          <input
            id="my-date-from"
            type="date"
            className="filter-date"
            value={filters.dateFrom}
            onChange={e => handleDateChange('dateFrom', e.target.value)}
            disabled={loading}
          />
        </div>
        <div className="filter-group">
          <label className="filter-label" htmlFor="my-date-to">To</label>
          <input
            id="my-date-to"
            type="date"
            className="filter-date"
            value={filters.dateTo}
            onChange={e => handleDateChange('dateTo', e.target.value)}
            disabled={loading}
          />
        </div>
      </div>

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
