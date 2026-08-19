import React from 'react';
import { ReportEntry, ReportResult } from '../../models/ReportEntry';
import { fmt } from '../../utils/formatUtils';

interface Props {
  result: ReportResult;
  filteredEntries: ReportEntry[];
}

export function SummaryStrip({ result, filteredEntries }: Props) {
  // Build per-cost-centre totals for the breakdown box
  const ccTotals = new Map<string, number>();
  for (const e of filteredEntries) {
    const cc = e.costCenter || 'No Cost Centre';
    ccTotals.set(cc, (ccTotals.get(cc) ?? 0) + e.hours);
  }
  const ccRows = [...ccTotals.entries()]
    .sort((a, b) => a[0].localeCompare(b[0]));
  const hasCC = ccRows.some(([cc]) => cc !== 'No Cost Centre');

  return (
    <>
      <div className="summary-strip">
        <div className="summary-card">
          <span className="summary-value">{fmt(result.grandTotal)}</span>
          <span className="summary-label">Total Hours</span>
        </div>
        <div className="summary-card">
          <span className="summary-value">{result.totalUsers}</span>
          <span className="summary-label">Users</span>
        </div>
        <div className="summary-card">
          <span className="summary-value">{result.totalProjects}</span>
          <span className="summary-label">Projects</span>
        </div>
        <div className="summary-card">
          <span className="summary-value">{result.totalCostCenters}</span>
          <span className="summary-label">Cost Centres</span>
        </div>
        <div className="summary-card">
          <span className="summary-value">{result.totalEntries}</span>
          <span className="summary-label">Entries</span>
        </div>
      </div>

      <div className="cc-summary-box">
        <div className="cc-summary-title">Category Breakdown</div>
        <div className="cc-summary-rows">
          <div className="cc-summary-row">
            <span className="cc-summary-label">AMC</span>
            <span className="cc-summary-hours">{fmt(result.totalAmcHours)}</span>
          </div>
          <div className="cc-summary-row">
            <span className="cc-summary-label">Other</span>
            <span className="cc-summary-hours">{fmt(result.grandTotal - result.totalAmcHours)}</span>
          </div>
        </div>
      </div>

      {hasCC && (
        <div className="cc-summary-box">
          <div className="cc-summary-title">Hours by Cost Centre</div>
          <div className="cc-summary-rows">
            {ccRows.map(([cc, hours]) => (
              <div key={cc} className="cc-summary-row">
                <span className="cc-summary-label">{cc}</span>
                <span className="cc-summary-hours">{fmt(hours)}</span>
              </div>
            ))}
          </div>
        </div>
      )}
    </>
  );
}
