# Permissions & Roles

## How Access Works

Every screen and action is gated by a permission code (e.g. "view", "create", "approve" on a given feature). Permissions are grouped into **Permission Groups**, and each group is assigned to one or more **Roles**. Your access is whatever your role's groups grant.

## If Something's Missing

- A menu item you expected isn't in your drawer — your role doesn't have view access to it yet.
- A button is missing or a screen shows "Access denied" — same thing, but for a specific action.

In both cases, ask your administrator to grant the relevant permission to your role.

## For Administrators

- **Permission Groups** — bundle permission codes together (e.g. "Petty Cash — Full Access").
- **Roles** — assign one or more permission groups to a role.
- **Menu Arrangement** — controls what appears in the drawer and in what order, and which roles can see each item. A menu entry existing isn't enough on its own — the underlying permission still gates the actual screen/actions.

Changes to permissions and roles take effect the next time the affected user logs in or refreshes their session.
