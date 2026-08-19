# Functional Requirements Specification (FRS) – UserMaster Feature

Document Version: 1.0  
Last Updated: 2025-09-27  
Owner: Service-Plus Engineering

## 1. Introduction
### 1.1 Purpose
This FRS defines the functional and non-functional requirements for the UserMaster feature, which manages application user records (create, read, update, delete) and their associated roles.

### 1.2 Scope
In-scope:
- Displaying a list of users
- Creating a new user
- Editing an existing user
- Deleting a user (soft or hard, backend driven)
- Assigning a role to a user
- Activating/deactivating a user

Out-of-scope (future consideration):
- Password reset & change flows
- Role management (separate feature)
- Bulk import/export of users
- Audit trail display

### 1.3 Stakeholders
- System Administrators (primary users)
- Support / Helpdesk
- Compliance / Audit (indirect)
- Engineering & QA

### 1.4 References
- `TECHNICAL.md` (implementation overview)
- Backend API contract (OpenAPI / internal service spec)

## 2. Definitions / Abbreviations
| Term | Definition |
|------|------------|
| User | An application login identity with profile and role. |
| Role | Permission grouping returned via `get-ui`. |
| Active | Boolean flag indicating whether user is permitted to access system. |
| UI Metadata | Ancillary dataset (roles) required for form population. |

## 3. Assumptions & Dependencies
| ID | Assumption / Dependency |
|----|-------------------------|
| A1 | Backend endpoints exist and follow response shape `{ success, data?, error? }`. |
| A2 | Role data is always available (may be empty set). |
| A3 | Unique constraint on `userName` enforced server-side. |
| A4 | Empty password during update means "no password change". |
| A5 | Network failure handling & authentication handled globally. |
| A6 | User list volume is small enough for no pagination initially. |

## 4. Functional Requirements
### 4.1 User List
| Req ID | Description | Priority | Acceptance Criteria |
|--------|-------------|----------|--------------------|
| FR-UL-01 | System shall display all users in a table view. | High | Table renders rows equal to backend `get-all` response length. |
| FR-UL-02 | Table shall include columns: ID, Username, Email, Full Name, Phone, Phone 2, Actions. | High | All headers visible; each row shows mapped fields. |
| FR-UL-03 | Each row shall provide Edit and Delete actions. | High | Two icon buttons present per row. |
| FR-UL-04 | Clicking Edit navigates to edit screen for selected user. | High | URL updates to `/user-master/edit/{id}` and form pre-populates. |
| FR-UL-05 | New button navigates to create form. | High | Button produces route `/user-master/add`. |
| FR-UL-06 | On load failure, an error alert is displayed. | Medium | Simulate backend failure → error message visible. |

### 4.2 Create User
| Req ID | Description | Priority | Acceptance Criteria |
|--------|-------------|----------|--------------------|
| FR-CU-01 | System shall present an empty form (except auto id placeholder). | High | Fields are blank / default, `id` shows `<Auto>`. |
| FR-CU-02 | System shall require fields: Username, Password, Full Name, Email, Role. | High | Submitting with any missing triggers validation messages (Yup). |
| FR-CU-03 | System shall validate email format. | High | Invalid email triggers 'Invalid email'. |
| FR-CU-04 | System shall default Active to true. | Medium | Active switch is ON by default. |
| FR-CU-05 | On successful save, system shows success message and redirects to list. | High | After API success, message appears then navigation occurs. |

### 4.3 Edit User
| Req ID | Description | Priority | Acceptance Criteria |
|--------|-------------|----------|--------------------|
| FR-EU-01 | System shall load existing user data when accessed with an ID. | High | Backend `get` called with correct id. |
| FR-EU-02 | Username field shall be read-only in edit mode. | High | Input disabled attribute present. |
| FR-EU-03 | Password field shall not be required in edit mode. | High | Submit succeeds with blank password (no validation error). |
| FR-EU-04 | Password placeholder shall show masked text (e.g., **************). | Low | Placeholder visible. |
| FR-EU-05 | Form shall allow toggling Active state. | Medium | Switch reflects value from backend. |
| FR-EU-06 | Save updates record and redirects with success feedback. | High | Update API called; navigation occurs. |

### 4.4 Delete User
| Req ID | Description | Priority | Acceptance Criteria |
|--------|-------------|----------|--------------------|
| FR-DU-01 | System shall prompt for confirmation before deleting a user. | High | Confirmation dialog appears; deletion only after confirm. |
| FR-DU-02 | On confirmed delete, system calls delete endpoint. | High | `delete` API invoked with user id. |
| FR-DU-03 | On successful delete, system refreshes list and shows success message. | High | List shows one fewer row. |
| FR-DU-04 | On cancel, system performs no action. | High | API not called. |

### 4.5 Roles Metadata
| Req ID | Description | Priority | Acceptance Criteria |
|--------|-------------|----------|--------------------|
| FR-RM-01 | System shall load role list via `get-ui`. | High | Roles request executed before form interaction. |
| FR-RM-02 | Role dropdown shall display `roleName` and submit `id`. | High | Inspect form value after change → numeric/string id stored. |
| FR-RM-03 | If no roles returned, form prevents save of new user. | Medium | Required validation fails (Role required). |

### 4.6 Navigation & Routing
| Req ID | Description | Priority | Acceptance Criteria |
|--------|-------------|----------|--------------------|
| FR-NR-01 | Create route: `/user-master/add` | High | Route resolves & form renders create mode. |
| FR-NR-02 | Edit route: `/user-master/edit/{id}` | High | Route resolves & loads editing form. |
| FR-NR-03 | List route: `/user-master` | High | Table renders. |

## 5. Non-Functional Requirements
| Req ID | Category | Requirement | Acceptance Criteria |
|--------|----------|-------------|--------------------|
| NFR-PERF-01 | Performance | List view initial load under 2s for <= 500 users. | Manual timing in normal environment. |
| NFR-USAB-01 | Usability | Validation messages displayed inline near offending fields. | Visual inspection. |
| NFR-SEC-01 | Security | Password not required nor shown in edit mode. | Visual & API payload inspection. |
| NFR-SEC-02 | Security | Only authenticated admins may access routes. | ProtectedRoute enforcement (global). |
| NFR-REL-01 | Reliability | Network failure triggers global handler (redirect or message). | Simulated offline test. |
| NFR-MAINT-01 | Maintainability | Field schema centralized in one object. | `fields` object present & modifiable. |
| NFR-ACC-01 | Accessibility | Action buttons have accessible names (title or aria). | DOM attributes present. |

## 6. Data Elements
| Name | Type | Source | Notes |
|------|------|--------|-------|
| id | number | Backend | Auto-generated. |
| userName | string | User input | Unique. |
| password | string | User input | Only on create. |
| fullName | string | User input | Required. |
| email | string | User input | Required valid format. |
| phone | string | User input | Optional. |
| phone2 | string | User input | Optional. |
| roleId | number/string | UI metadata | Required. |
| active | boolean | User input | Defaults true. |

## 7. User Interface Requirements (Summary)
- Table actions: pencil (edit), trash (delete)
- New button above table
- Form fields stacked with Bootstrap responsive grid classes
- Confirmation dialog on delete
- Success message after create/update/delete

## 8. Error Handling
| Scenario | Behavior |
|----------|----------|
| Validation fail | Inline messages; no API call. |
| Create/update API failure | (Future) Show error message (currently generic handling). |
| Delete API failure | (Future) Show error; retain row. |
| Roles load failure | (Future) Show fallback error & disable form. |

## 9. Traceability Matrix (Sample)
| Requirement | Implementation Reference |
|-------------|--------------------------|
| FR-UL-01 | `index.jsx` useEffect + ApiService.getAll |
| FR-CU-02 | `AddUser.jsx` Yup schema fields.userName/password/... |
| FR-EU-02 | `AddUser.jsx` `disabled: !!id` for username |
| FR-DU-01 | `index.jsx` & `AddUser.jsx` `MessageBoxService.confirmAsync` |
| FR-RM-01 | `AddUser.jsx` `getUi()` effect |
| NFR-SEC-01 | Conditional password validation logic |

## 10. Open Issues
| ID | Description | Target Resolution |
|----|------------|-------------------|
| OI-01 | Clarify soft vs hard delete semantics. | Backend spec review |
| OI-02 | Need standardized error messaging for update failures. | UX guidelines |
| OI-03 | Pagination requirement threshold? | Usage metrics |

## 11. Future Enhancements
- Password reset / temporary password issuance
- Search & filter in list view
- Column visibility toggle integration
- Audit log of user modifications
- Export (CSV/Excel) of user list
- Role-based filter

## 12. Approval
| Role | Name | Signature | Date |
|------|------|----------|------|
| Product Owner | | | |
| Tech Lead | | | |
| QA Lead | | | |

---
End of FRS
