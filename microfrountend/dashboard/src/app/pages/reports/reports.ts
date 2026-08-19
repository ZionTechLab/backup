import { Component } from '@angular/core';
import { DecimalPipe } from '@angular/common';

interface Report {
  name: string;
  date: string;
  status: 'ready' | 'processing' | 'failed';
  rows: number;
}

@Component({
  selector: 'app-reports',
  standalone: true,
  imports: [DecimalPipe],
  template: `
    <div class="page">
      <h2>Reports</h2>
      <table>
        <thead>
          <tr>
            <th>Report Name</th>
            <th>Generated</th>
            <th>Rows</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          @for (r of reports; track r.name) {
            <tr>
              <td>{{ r.name }}</td>
              <td>{{ r.date }}</td>
              <td>{{ r.rows | number }}</td>
              <td><span class="badge" [class]="r.status">{{ r.status }}</span></td>
            </tr>
          }
        </tbody>
      </table>
    </div>
  `,
  styles: [`
    .page { padding: 2rem; }
    h2 { margin: 0 0 1.5rem; }
    table { width: 100%; border-collapse: collapse; background: white; border-radius: 8px; overflow: hidden; box-shadow: 0 1px 4px rgba(0,0,0,0.08); }
    th { background: #f9fafb; text-align: left; padding: 0.75rem 1rem; font-size: 0.875rem; color: #374151; }
    td { padding: 0.75rem 1rem; border-top: 1px solid #f3f4f6; font-size: 0.9rem; }
    .badge { padding: 2px 10px; border-radius: 9999px; font-size: 0.75rem; font-weight: 500; text-transform: capitalize; }
    .ready { background: #d1fae5; color: #065f46; }
    .processing { background: #fef3c7; color: #92400e; }
    .failed { background: #fee2e2; color: #991b1b; }
  `],
})
export class ReportsComponent {
  reports: Report[] = [
    { name: 'Monthly Sales Summary',  date: '2026-04-01', status: 'ready',      rows: 14_320 },
    { name: 'User Acquisition Q1',    date: '2026-04-05', status: 'ready',      rows:  8_490 },
    { name: 'Churn Analysis April',   date: '2026-04-14', status: 'processing', rows:      0 },
    { name: 'Revenue Forecast',       date: '2026-04-13', status: 'ready',      rows:  2_100 },
    { name: 'Error Rate Report',      date: '2026-04-12', status: 'failed',     rows:      0 },
  ];
}
