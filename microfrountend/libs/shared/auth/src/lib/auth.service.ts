import { Injectable, Signal, WritableSignal, signal, computed } from '@angular/core';
import { AuthUser } from '@org/shared-models';

const TOKEN_KEY = 'mfe_auth_token';
const USER_KEY = 'mfe_auth_user';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private _user: WritableSignal<AuthUser | null> = signal<AuthUser | null>(this.loadUser());

  readonly user: Signal<AuthUser | null> = this._user.asReadonly();
  readonly isLoggedIn: Signal<boolean> = computed<boolean>(() => this._user() !== null);

  login(username: string, password: string): boolean {
    // Stub: accept any non-empty credentials
    if (!username || !password) return false;
    const authUser: AuthUser = { username, token: btoa(`${username}:${Date.now()}`) };
    this._user.set(authUser);
    localStorage.setItem(TOKEN_KEY, authUser.token);
    localStorage.setItem(USER_KEY, JSON.stringify(authUser));
    return true;
  }

  logout(): void {
    this._user.set(null);
    localStorage.removeItem(TOKEN_KEY);
    localStorage.removeItem(USER_KEY);
  }

  getToken(): string | null {
    return this._user()?.token ?? null;
  }

  private loadUser(): AuthUser | null {
    try {
      const raw = localStorage.getItem(USER_KEY);
      return raw ? (JSON.parse(raw) as AuthUser) : null;
    } catch {
      return null;
    }
  }
}
