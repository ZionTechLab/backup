import { Component, inject } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { User } from '@org/shared-models';

@Component({
  selector: 'app-user-detail',
  standalone: true,
  imports: [RouterModule],
  template: `
    <div class="page">
      <a routerLink="/users" class="back">← Back to Users</a>
      @if (user) {
        <div class="card">
          <div class="avatar">{{ user.name[0] }}</div>
          <div class="info">
            <h2>{{ user.name }}</h2>
            <p>{{ user.email }}</p>
            <div class="meta">
              <span class="role">{{ user.role }}</span>
              <span class="badge" [class.active]="user.active" [class.inactive]="!user.active">
                {{ user.active ? 'Active' : 'Inactive' }}
              </span>
            </div>
          </div>
        </div>
      } @else {
        <p>User not found.</p>
      }
    </div>
  `,
  styles: [`
    .page { padding: 2rem; }
    .back { color: #6366f1; text-decoration: none; font-size: 0.875rem; }
    .card { display: flex; gap: 1.5rem; align-items: flex-start; background: white; border-radius: 8px; padding: 1.5rem; margin-top: 1.5rem; box-shadow: 0 1px 4px rgba(0,0,0,0.08); }
    .avatar { width: 60px; height: 60px; border-radius: 50%; background: #6366f1; color: white; display: flex; align-items: center; justify-content: center; font-size: 1.5rem; font-weight: 700; flex-shrink: 0; }
    .info h2 { margin: 0 0 0.25rem; }
    .info p { margin: 0 0 0.75rem; color: #6b7280; }
    .meta { display: flex; gap: 0.5rem; align-items: center; }
    .role { text-transform: capitalize; font-size: 0.875rem; color: #374151; }
    .badge { padding: 2px 10px; border-radius: 9999px; font-size: 0.75rem; font-weight: 500; }
    .active { background: #d1fae5; color: #065f46; }
    .inactive { background: #f3f4f6; color: #6b7280; }
  `],
})
export class UserDetailComponent {
  private route = inject(ActivatedRoute);

  private all: User[] = [
    { id: 1, name: 'Alice Johnson',  email: 'alice@example.com',  role: 'admin',  active: true  },
    { id: 2, name: 'Bob Martinez',   email: 'bob@example.com',    role: 'editor', active: true  },
    { id: 3, name: 'Carol Williams', email: 'carol@example.com',  role: 'viewer', active: false },
    { id: 4, name: 'David Lee',      email: 'david@example.com',  role: 'editor', active: true  },
    { id: 5, name: 'Eva Chen',       email: 'eva@example.com',    role: 'viewer', active: true  },
  ];

  user: User | undefined = this.all.find(
    (u) => u.id === Number(this.route.snapshot.paramMap.get('id'))
  );
}
