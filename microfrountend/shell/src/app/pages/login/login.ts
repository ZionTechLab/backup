import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '@org/shared-auth';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  template: `
    <div class="login-wrapper">
      <div class="login-card">
        <h1>Sign in</h1>
        <form [formGroup]="form" (ngSubmit)="submit()">
          <label>
            Username
            <input formControlName="username" type="text" placeholder="Enter username" autocomplete="username" />
          </label>
          <label>
            Password
            <input formControlName="password" type="password" placeholder="Enter password" autocomplete="current-password" />
          </label>
          @if (error) {
            <p class="error">{{ error }}</p>
          }
          <button type="submit" [disabled]="form.invalid">Sign in</button>
        </form>
        <p class="hint">Use any username and password to log in.</p>
      </div>
    </div>
  `,
  styles: [`
    .login-wrapper {
      display: flex;
      align-items: center;
      justify-content: center;
      min-height: 100vh;
      background: #f0f2f5;
    }
    .login-card {
      background: white;
      padding: 2rem;
      border-radius: 8px;
      box-shadow: 0 2px 12px rgba(0,0,0,0.1);
      width: 100%;
      max-width: 360px;
    }
    h1 { margin: 0 0 1.5rem; font-size: 1.5rem; }
    label { display: flex; flex-direction: column; gap: 4px; margin-bottom: 1rem; font-size: 0.875rem; font-weight: 500; }
    input { padding: 0.5rem 0.75rem; border: 1px solid #d1d5db; border-radius: 6px; font-size: 1rem; outline: none; }
    input:focus { border-color: #6366f1; box-shadow: 0 0 0 3px rgba(99,102,241,0.15); }
    button { width: 100%; padding: 0.625rem; background: #6366f1; color: white; border: none; border-radius: 6px; font-size: 1rem; cursor: pointer; }
    button:disabled { opacity: 0.5; cursor: not-allowed; }
    .error { color: #ef4444; font-size: 0.875rem; margin: -0.5rem 0 0.75rem; }
    .hint { font-size: 0.75rem; color: #9ca3af; margin-top: 1rem; text-align: center; }
  `],
})
export class LoginComponent {
  private auth = inject(AuthService);
  private router = inject(Router);
  private fb = inject(FormBuilder);

  form = this.fb.nonNullable.group({
    username: ['', Validators.required],
    password: ['', Validators.required],
  });

  error = '';

  submit(): void {
    const { username, password } = this.form.getRawValue();
    const ok = this.auth.login(username, password);
    if (ok) {
      this.router.navigate(['/dashboard']);
    } else {
      this.error = 'Invalid credentials. Please try again.';
    }
  }
}
