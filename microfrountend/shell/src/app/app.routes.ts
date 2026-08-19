import { loadRemoteModule } from '@angular-architects/native-federation';
import { Route } from '@angular/router';
import { authGuard } from '@org/shared-auth';
import { LoginComponent } from './pages/login/login';

export const appRoutes: Route[] = [
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  {
    path: 'dashboard',
    canActivate: [authGuard],
    loadChildren: () =>
      loadRemoteModule('dashboard', './Routes').then((m) => m.appRoutes),
  },
  {
    path: 'users',
    canActivate: [authGuard],
    loadChildren: () =>
      loadRemoteModule('user-management', './Routes').then((m) => m.appRoutes),
  },
  { path: '**', redirectTo: 'dashboard' },
];
