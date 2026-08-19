import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-settings',
  standalone: true,
  imports: [ReactiveFormsModule],
  template: `
    <div class="page">
      <h2>Settings</h2>
      <div class="card">
        <h3>Profile</h3>
        <form [formGroup]="form" (ngSubmit)="save()">
          <label>
            Display Name
            <input formControlName="displayName" type="text" />
          </label>
          <label>
            Email Notifications
            <input formControlName="emailNotifications" type="checkbox" />
          </label>
          @if (saved) {
            <p class="success">Settings saved.</p>
          }
          <button type="submit">Save Changes</button>
        </form>
      </div>
    </div>
  `,
  styles: [`
    .page { padding: 2rem; }
    h2 { margin: 0 0 1.5rem; }
    .card { background: white; border-radius: 8px; padding: 1.5rem; box-shadow: 0 1px 4px rgba(0,0,0,0.08); max-width: 480px; }
    h3 { margin: 0 0 1rem; font-size: 1rem; }
    label { display: flex; flex-direction: column; gap: 4px; margin-bottom: 1rem; font-size: 0.875rem; font-weight: 500; }
    input[type=text] { padding: 0.5rem 0.75rem; border: 1px solid #d1d5db; border-radius: 6px; font-size: 1rem; }
    input[type=checkbox] { width: 18px; height: 18px; }
    button { background: #6366f1; color: white; border: none; padding: 0.5rem 1.25rem; border-radius: 6px; cursor: pointer; }
    .success { color: #10b981; font-size: 0.875rem; margin: 0 0 0.75rem; }
  `],
})
export class SettingsComponent {
  private fb = inject(FormBuilder);
  saved = false;

  form = this.fb.nonNullable.group({
    displayName: ['Current User'],
    emailNotifications: [true],
  });

  save(): void {
    this.saved = true;
    setTimeout(() => (this.saved = false), 3000);
  }
}
