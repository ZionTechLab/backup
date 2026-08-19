# UserMaster Feature – Technical Documentation

## 1. Purpose & Scope
The `UserMaster` feature provides CRUD (Create, Read, Update, Delete) management for application users. It includes:
- A list view (`index.jsx`) that displays existing users in a reusable `DataTable` component.
- A form view (`AddUser.jsx`) used for both creating and editing users.
- A backend service abstraction (`UserService.js`) that encapsulates API calls.
- A test suite (`AddUser.test.jsx`) covering core UI logic and flows.
- A placeholder profile page (`Profile.jsx`).

This feature aligns with overall app conventions: React functional components, Formik abstraction via `useFormikBuilder`, Yup validation, axios + middleware for API interaction, and centralized UX feedback with `MessageBoxService`.

## 2. High-Level Architecture
```
UserMaster
 ├── index.jsx (List view)
 ├── AddUser.jsx (Create/Edit form)
 ├── UserService.js (API integration)
 ├── AddUser.test.jsx (Jest + RTL tests)
 ├── Profile.jsx (Stub page)
 └── TECHNICAL.md (This document)
```
Key external dependencies:
- `components/DataTable` – tabular display & action column rendering.
- `helpers/formikBuilder` – builds Formik instance & renders fields via `FieldsRenderer`.
- `services/MessageBoxService` – success, error, and confirmation dialogs.
- `helpers/axiosMiddleware` – wrapped axios instance + `axiosRequest` for unified error/spinner handling.

## 3. Data Model & Form Schema
The form in `AddUser.jsx` defines a `fields` map consumed by `useFormikBuilder` and `FieldsRenderer`.

| Field Key | Type | Validation | Notes |
|-----------|------|------------|-------|
| id | text (disabled) | none | Hidden (visible:false). Auto-generated on create. Parsed to int on submit. |
| userName | text | required | Disabled in edit mode (`!!id`). Serves as login/user identifier. |
| password | password | required only on create | Placeholder masked when editing ("**************"). Submitted empty on edit to imply no change. |
| fullName | text | required | Display / identification name. |
| email | email | required + format | Used for contact & potentially login recovery. |
| phone | phone | optional | Primary phone (format handled by custom input). |
| phone2 | phone | optional | Secondary phone. |
| roleId | select | required | Populated via `getUi()` → `data.Role[]` (fields: `id`, `roleName`). |
| active | switch | optional (boolean) | Defaults `true`. Represents enabled status. |

### Submit Payload
```
{
  header: {
    id: number,              // 0 or existing id
    userName: string,
    password: string,        // empty if unchanged during edit
    fullName: string,
    email: string,
    phone: string,
    phone2: string,
    roleId: string|number,   // as selected
    active: boolean
  },
  isUpdate: boolean          // true if editing
}
```

## 4. API Contract (Front-End Perspective)
Base URL: `config.apiBaseUrl + 'users'`

| Method | Endpoint | Params / Body | Purpose | Expected `res` shape |
|--------|----------|---------------|---------|----------------------|
| GET | `/get-ui` | — | Returns UI metadata (Roles). | `{ success, data: { Role: [{ id, roleName }, ...] } }` |
| POST | `/update` | `{ header, isUpdate }` | Create or update user. | `{ success, data? }` |
| GET | `/get` | `?id=<id>` | Retrieve single user for edit. | `{ success, data: { ...userFields } }` |
| GET | `/get-all` | — | List all users. | `{ success, data: [ user,... ] }` |
| POST | `/delete` | `{ id }` | Soft/hard delete (depends backend). | `{ success }` |

All calls are wrapped with `axiosRequest` for consistent error / spinner logic (spinner flags optional, not used here). Network failures are globally handled (redirect to service-unavailable if configured in middleware).

## 5. Component Responsibilities
### index.jsx (UserMaster list)
- Loads all users on mount (`getAll`).
- Renders a `DataTable` with an action column (Edit/Delete).
- Uses `MessageBoxService.confirmAsync` before deletion.
- On successful delete, reloads list and shows success toast/banner.

### AddUser.jsx (Form)
- Dual-mode: create (no `id` param) vs edit (`id` URL param present).
- Loads UI metadata (roles) always; if `id` present, fetches user and seeds Formik values.
- Form submission calls `update` with `isUpdate` flag.
- Post-save: success message and navigation to `/user-master`.
- Delete option visible only in edit mode.
- Leverages dynamic field disabling and conditional Yup rules.

### UserService.js
Simple wrapper class consolidating path prefix & endpoints. Exported singleton to avoid repeated instantiation.

### AddUser.test.jsx
Covers critical behaviors:
- Role loading
- Validation enforcement (no premature submit)
- Successful creation flow (including navigation on close)
- Edit mode prefill (password non-required state)
- Delete flow (confirmation + API call + navigation)

## 6. State Management & Side Effects
- Local component state only (`uiData`). Not persisted in Redux because data is transient & specific to feature.
- `uiData` shape (list view): `{ loading, success, error, data }`.
- `uiData` shape (form view): `{ loading, success, error, data }` where `data.Role` holds role options.
- Effects (`useEffect`) run once on mount; dependencies intentionally suppressed to prevent refetch loops after Formik initialization.

## 7. Validation Logic Nuances
- Password field conditional: required only if user is being created. Implemented with inline ternary returning `Yup.string()` vs `.required()`.
- Email uses Yup `.email()` and `.required()`.
- All other required fields have straightforward `.required()`.
- Optional fields use plain `Yup.string()` or `Yup.boolean()` to preserve types.

## 8. UX & Interaction Patterns
- All destructive actions require confirmation dialog.
- Success operations produce a success message then redirect (list refresh or navigation depending on context).
- The form uses minimal layout classes; responsive widths rely on Bootstrap grid classes defined per field.
- Action buttons (edit/delete) are icon-based with tooltips (via title attribute) to conserve column width.

## 9. Accessibility Considerations
- Buttons have `title` attributes for icon meaning (improves tooltips, but consider `aria-label`).
- Inputs rely on placeholders; labeling could be improved with explicit `<label>` or `aria-label` for better screen reader support.
- Confirmation dialogs depend on `MessageBoxService`—should ensure focus trapping & proper role semantics there (out of scope here).

## 10. Error Handling Strategy
- API layer centralizes network error redirection; component sets simple `error` message if returned.
- No per-field server-side validation feedback currently; could be extended by mapping backend validation errors to Formik `setErrors`.

## 11. Security & Privacy Notes
- Password transmitted only on creation (empty string on edit implies no change). Ensure backend ignores empty password rather than resetting.
- No client-side hashing—TLS transport assumed. If compliance requires, consider stronger client feedback (password strength meter).
- Role assignment trust is client-submitted; backend must enforce authorization to modify roles.

## 12. Performance Considerations
- Data set likely small (admin users). No pagination implemented; add server-side pagination if user list grows large.
- Form loads UI metadata and (optionally) a single user record—constant-time operations.
- Avoids unnecessary re-renders by fetching once.

## 13. Edge Cases & Potential Enhancements
| Scenario | Current Behavior | Enhancement Idea |
|----------|------------------|------------------|
| Duplicate username submit | Backend handles; no pre-check | Add debounced availability check. |
| Slow role load | Form renders with empty select | Add skeleton/loading state for select. |
| Delete of already removed user | Success toast may show erroneously | Distinguish 404 with warning message. |
| Password change on edit | Not supported | Add explicit "Reset Password" flow. |
| Large user list | All rows loaded at once | Implement pagination + search filter. |
| Role list empty | Validation fails | Provide fallback message/disable save. |
| Network retry | None | Add retry button on error state. |

## 14. Testing Strategy
Current coverage (AddUser.test.jsx): create path, validation, submit, edit path, delete path.
Recommended additional tests:
- Role select required enforcement (explicit assertion).
- Handling of backend error on submit (show message, no navigation).
- Conditional disabling of username in edit mode.
- Active switch default true and persisted value.
- Edge: empty Role list disables save.

## 15. Extension Guidelines
When adding related fields (e.g., department, locale):
1. Add to `fields` map with `initialValue` and proper Yup rule.
2. If options are needed, extend `get-ui` backend response and bind using `dataBinding` consistent with `roleId`.
3. Update table columns if display is required.
4. Extend test suite with new validation + render assertions.
5. Maintain consistent naming (camelCase) to match existing and backend DTO.

## 16. Migration / Refactor Opportunities
- Abstract repeated confirmation dialog text into a constants file.
- Extract field schema into a separate `userFields.js` for reuse & testability.
- Introduce a custom hook (e.g., `useUserForm`) to encapsulate `useEffect` fetching logic.
- Replace hardcoded navigation targets with route constants.
- Strengthen typing via TypeScript or JSDoc typedefs.

## 17. Observability & Logging
- No explicit logging. Consider adding instrumentation (e.g., counting failed vs successful updates) in `axiosMiddleware` layer.

## 18. Dependencies / Contracts Assumptions
- `MessageBoxService.confirmAsync` resolves boolean and never throws.
- `axiosRequest` returns an object with at least `{ success, data?, error? }`.
- `DataTable` accepts `data`, `columns`, `children` (toolbar) and supports action columns via `isAction` + `actionTemplate`.
- `FieldsRenderer` respects `disabled` and `visible:false` semantics.

## 19. Known Limitations
- No optimistic UI or cache invalidation logic—list always re-fetched post mutation.
- No server-driven validation messages surfaced.
- Lacks audit trail UI (who created/modified users, timestamps).

## 20. Quick Start (Developer)
1. Navigate to `/user-master` to view list (ensure backend running & `config.apiBaseUrl` configured).
2. Click New → fill required fields → Save.
3. Click pencil icon to edit; modify fields (password not required) → Save.
4. Click trash icon → confirm → record removed.

## 21. Glossary
- UI Metadata (`get-ui`): Ancillary reference data required to render the form (Roles, etc.).
- Formik Builder: Custom abstraction simplifying individual Formik setups via declarative `fields` map.

---
Maintainer Notes: Keep this document updated when altering endpoints, adding fields, or changing validation rules. Consider adding an OpenAPI spec synchronization step if backend evolves.
