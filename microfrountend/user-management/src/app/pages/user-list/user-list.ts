import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { User } from '@org/shared-models';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [RouterModule],
  template: `
    <div class="page">
      <div class="page-header">
        <h2>Users</h2>
        <button class="btn-primary">+ Add User</button>
      </div>
      <table>
        <thead>
          <tr>
            <th>Name</th><th>Email</th><th>Role</th><th>Status</th><th>Actions</th>
          </tr>
        </thead>
        <tbody>
          @for (u of users; track u.id) {
            <tr>
              <td>{{ u.name }}</td>
              <td>{{ u.email }}</td>
              <td><span class="role">{{ u.role }}</span></td>
              <td><span class="badge" [class.active]="u.active" [class.inactive]="!u.active">{{ u.active ? 'Active' : 'Inactive' }}</span></td>
              <td><a [routerLink]="['/users', u.id]">View</a></td>
            </tr>
          }
        </tbody>
      </table>
    </div>
  `,
  styles: [`
    .page { padding: 2rem; }
    .page-header { display: flex; justify-content: space-between; align-items: center; margin-bottom: 1.5rem; }
    h2 { margin: 0; }
    .btn-primary { background: #6366f1; color: white; border: none; padding: 0.5rem 1rem; border-radius: 6px; cursor: pointer; font-size: 0.875rem; }
    table { width: 100%; border-collapse: collapse; background: white; border-radius: 8px; overflow: hidden; box-shadow: 0 1px 4px rgba(0,0,0,0.08); }
    th { background: #f9fafb; text-align: left; padding: 0.75rem 1rem; font-size: 0.875rem; color: #374151; }
    td { padding: 0.75rem 1rem; border-top: 1px solid #f3f4f6; font-size: 0.9rem; }
    a { color: #6366f1; text-decoration: none; }
    .role { text-transform: capitalize; }
    .badge { padding: 2px 10px; border-radius: 9999px; font-size: 0.75rem; font-weight: 500; }
    .active { background: #d1fae5; color: #065f46; }
    .inactive { background: #f3f4f6; color: #6b7280; }
  `],
})
export class UserListComponent {
  users: User[] = [
    { id: 1, name: 'Alice Johnson',  email: 'alice@example.com',  role: 'admin',  active: true  },
    { id: 2, name: 'Bob Martinez',   email: 'bob@example.com',    role: 'editor', active: true  },
    { id: 3, name: 'Carol Williams', email: 'carol@example.com',  role: 'viewer', active: false },
    { id: 4, name: 'David Lee',      email: 'david@example.com',  role: 'editor', active: true  },
    { id: 5, name: 'Eva Chen',       email: 'eva@example.com',    role: 'viewer', active: true  },
  ];
}
