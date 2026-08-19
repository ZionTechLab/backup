# User Manual – UserMaster

Version: 1.0  
Last Updated: 2025-09-27  
Audience: System Administrators / Support Users

## 1. Overview
The UserMaster module lets administrators manage application user accounts: view, create, edit, and delete users, and assign roles that govern permissions elsewhere in the system.

## 2. Accessing the Module
1. Log in with an account that has administrative privileges.
2. Navigate through the side menu to “User Master” (exact placement depends on configured menu structure).
3. The User List page loads automatically.

## 3. User List Page
The list page displays all existing users in a table.

Columns:
- ID – System-generated identifier
- Username – User login name
- Email – Contact email
- Full Name – Display name
- Phone / Phone 2 – Contact numbers
- Actions – Edit (pencil) / Delete (trash)

Toolbar:
- New – Opens the Create User form

### 3.1 Editing a User
Click the pencil icon next to the desired row. You will be taken to the Edit User page with fields populated.

### 3.2 Deleting a User
1. Click the trash icon.
2. A confirmation dialog appears.
3. Choose “Delete” to proceed or “Cancel” to abort.
4. After deletion, the table refreshes automatically.

> Note: Deleted users cannot log in. Whether data is fully removed or just deactivated depends on backend configuration.

## 4. Creating a New User
1. Click the “New” button on the list page.
2. Fill in the form fields (see Field Reference below).
3. Click Save.
4. A success message appears; you are redirected back to the User List.

## 5. Editing an Existing User
1. Enter edit mode (see 3.1).
2. Adjust allowed fields.
3. Click Save.
4. A success message appears; you are redirected to the User List.

Password Notes:
- On create: Password is required.
- On edit: Password field shows a masked placeholder. Leaving it blank keeps the existing password.

## 6. Field Reference
| Field | Required (Create) | Required (Edit) | Description | Notes |
|-------|-------------------|-----------------|-------------|-------|
| User ID (Username) | Yes | Locked (read-only) | Unique login identifier. | Cannot be changed after creation. |
| Password | Yes | No (leave blank to keep) | Login secret. | Ensure secure complexity policy (enforced server-side if applicable). |
| Full Name | Yes | Yes | Display / legal name. | Appears in reports or UI contexts. |
| Email | Yes | Yes | Contact email address. | Must be valid email format. |
| Phone | No | No | Primary phone number. | Formatting auto-applied. |
| Phone 2 | No | No | Secondary phone. | Optional. |
| Role | Yes | Yes | Permission grouping. | Select from dropdown. |
| Active | Default: Yes | Editable | Enables or disables login access. | Toggle switch. |

## 7. Validation Messages
| Condition | Message |
|-----------|---------|
| Username blank | “User ID is required” |
| Password blank (create) | “Password is required” |
| Full Name blank | “Full name is required” |
| Email blank | “Email is required” |
| Email invalid | “Invalid email” |
| Role not selected | “Role is required” |

## 8. Typical Workflows
### 8.1 Add New User
1. Open User List → New.
2. Complete all required fields.
3. Click Save → Success message → Return to list.

### 8.2 Deactivate User (Soft Offboarding)
1. Edit the user.
2. Toggle Active off.
3. Save. User can no longer log in.

### 8.3 Delete User (Full Removal)
1. From list click Delete.
2. Confirm in dialog.
3. Ensure user no longer appears in list.

### 8.4 Update Role
1. Edit user.
2. Change Role dropdown.
3. Save.
4. Confirm permissions reflect after next login (may require sign-out sign-in cycle).

## 9. Messages & Dialogs
- Success (save): “User saved successfully!”
- Success (delete): “User deleted successfully!”
- Delete confirmation prompt: “Are you sure you want to delete this User?”

## 10. Troubleshooting
| Issue | Possible Cause | Resolution |
|-------|----------------|-----------|
| Cannot save – validation errors | Missing required fields | Fill highlighted fields & retry. |
| Role dropdown empty | Backend metadata unavailable | Refresh page; contact admin if persists. |
| User not redirected after save | Browser blocked navigation or script error | Refresh; verify backend response success. |
| Duplicate username error (server) | Username already exists | Choose a different username. |
| Deleted user still can log in | Backend using soft delete & session not expired | Invalidate session server-side / wait for token expiry. |

## 11. FAQ
**Q:** Can I change a username after creation?  
**A:** No; you must delete and recreate if a different username is required.

**Q:** How do I reset a user’s password?  
**A:** Not available in this module yet; use dedicated password reset (future feature) or backend admin tool.

**Q:** Why is the password field empty during edit?  
**A:** For security. Leaving it blank preserves the existing password.

**Q:** What defines available roles?  
**A:** Roles are provided by the backend `get-ui` endpoint.

## 12. Best Practices
- Always verify Role assignment before saving.
- Prefer deactivation (Active = off) over deletion if historical linkage matters.
- Ensure email accuracy for system notifications.
- Use strong password policies (enforced server-side).

## 13. Security Notes
- Do not share user credentials.
- Use deactivation to immediately revoke access.
- Role changes may require user logout/login to take effect.

## 14. Planned Enhancements (Roadmap)
- Password reset flow
- Search & filter on list
- Pagination for large user bases
- Audit & last login display
- Export to CSV

## 15. Support
For further assistance: contact the platform operations or submit a support ticket through the internal help desk system.

---
End of User Manual
