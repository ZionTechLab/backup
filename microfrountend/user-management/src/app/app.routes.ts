import { Route } from '@angular/router';
import { UserListComponent } from './pages/user-list/user-list';
import { UserDetailComponent } from './pages/user-detail/user-detail';
import { SettingsComponent } from './pages/settings/settings';

export const appRoutes: Route[] = [
  { path: '',           redirectTo: 'list', pathMatch: 'full' },
  { path: 'list',       component: UserListComponent },
  { path: ':id',        component: UserDetailComponent },
  { path: 'settings',   component: SettingsComponent },
];
