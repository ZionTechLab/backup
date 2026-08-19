import { Route } from '@angular/router';
import { OverviewComponent } from './pages/overview/overview';
import { ReportsComponent } from './pages/reports/reports';

export const appRoutes: Route[] = [
  { path: '',        redirectTo: 'overview', pathMatch: 'full' },
  { path: 'overview', component: OverviewComponent },
  { path: 'reports',  component: ReportsComponent },
];
