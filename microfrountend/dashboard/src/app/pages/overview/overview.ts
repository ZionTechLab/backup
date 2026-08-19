import { Component } from '@angular/core';

interface KpiCard {
  label: string;
  value: string;
  change: string;
  up: boolean;
}

@Component({
  selector: 'app-overview',
  standalone: true,
  template: `
    <div class="page">
      <h2>Overview</h2>
      <div class="kpi-grid">
        @for (card of kpis; track card.label) {
          <div class="kpi-card">
            <span class="kpi-label">{{ card.label }}</span>
            <span class="kpi-value">{{ card.value }}</span>
            <span class="kpi-change" [class.up]="card.up" [class.down]="!card.up">
              {{ card.up ? '▲' : '▼' }} {{ card.change }}
            </span>
          </div>
        }
      </div>
    </div>
  `,
  styles: [`
    .page { padding: 2rem; }
    h2 { margin: 0 0 1.5rem; }
    .kpi-grid { display: grid; grid-template-columns: repeat(auto-fill, minmax(200px, 1fr)); gap: 1rem; }
    .kpi-card { background: white; border-radius: 8px; padding: 1.25rem; box-shadow: 0 1px 4px rgba(0,0,0,0.08); display: flex; flex-direction: column; gap: 0.5rem; }
    .kpi-label { font-size: 0.8rem; color: #6b7280; text-transform: uppercase; letter-spacing: 0.05em; }
    .kpi-value { font-size: 1.75rem; font-weight: 700; }
    .kpi-change { font-size: 0.875rem; }
    .up { color: #10b981; }
    .down { color: #ef4444; }
  `],
})
export class OverviewComponent {
  kpis: KpiCard[] = [
    { label: 'Total Users',    value: '12,430', change: '8.2%',  up: true  },
    { label: 'Active Sessions', value: '1,893',  change: '3.1%',  up: true  },
    { label: 'Revenue',        value: '$48,200', change: '12.5%', up: true  },
    { label: 'Bounce Rate',    value: '24.6%',   change: '1.4%',  up: false },
  ];
}
