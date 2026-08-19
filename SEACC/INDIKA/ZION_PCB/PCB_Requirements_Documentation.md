# Petty Cash Book (PCB) — Requirements Documentation

> **Purpose of this document:** Capture the complete functional behaviour of the
> existing ZION **Petty Cash Book** WPF desktop module so it can be re‑built as a
> modern **web application**. It describes *what the system does and why*, not the
> WPF implementation. Every workflow, business rule and screen layout below was
> reverse‑engineered from the source code in `c:\repo\SEACC\INDIKA\ZION_PCB`.

---

## 1. System Overview

### 1.1 What it is
The Petty Cash Book module manages **office petty cash floats**: the small cash
fund a branch/office holds to pay day‑to‑day expenses. It tracks money going out
(expenditures), cash advances to staff (IOUs), unused‑cash returns (IOU refunds),
and the periodic top‑up of the float back to its original amount (reimbursement),
which posts a double‑entry journal to the General Ledger.

It is one module (`PCB/025`) inside a larger ERP suite ("SEACC", by Digiteq).
It shares a common security/login framework, a custom UI control library, a
General Ledger (GL) module, and an Account Payable Note (APN) sub‑system with the
rest of the ERP.

### 1.2 Technology (current vs. target)
| Concern | Current (legacy) | Target (web rebuild) |
|---|---|---|
| UI | WPF / XAML desktop | Web SPA (e.g. React/Angular/Vue) |
| Logic | C# code‑behind in each form | API service layer |
| Data access | Hand‑written ADO.NET classes calling **SQL Server stored procedures** | API + ORM or retained stored procs |
| Auth | Encrypted user/password, 1‑sec session‑pool poll | Token/session auth |
| Reports | Crystal/RDLC `.rpt` + EPPlus Excel export | Server‑side PDF/Excel generation |
| Codes | Auto-generated prefix + counter | Same scheme |

### 1.3 Actors / Roles
There are no hard‑coded roles; access is **per‑user, per‑function, per‑branch**
through a permission matrix. Functional actors that emerge from the workflows:

- **Petty Cash Custodian / Holder** — the user *assigned* to a PC account. Only
  this person can create transactions (Expenditure, IOU, Refund, Reimbursement)
  on that account. Other users see the account in **read‑only / view mode**.
- **Requester** — any user who raises an IOU Request (a cash‑advance request).
- **Spender** — the user a given expenditure is recorded against ("Spent By").
- **Approver** — a user with *Approve* permission; approves Reimbursements.
- **Administrator** — manages master data and the user‑permission matrix.

### 1.4 Permission model (must be preserved)
Every screen ("function") checks a permission record keyed by
`(BranchID, UserID, FunctionID)`. Each grants a subset of:

`Read · Write · Update(Edit) · Cancel(Delete) · Check · Approve · Print · Re‑print · Export · View`

Rules enforced in the legacy code:
- No **Read** → screen refuses to open ("you don't have permission").
- Save in *new* mode requires **Write**; Save in *edit* mode requires **Update**.
- Cancel button requires **Cancel**; Approve requires **Approve**;
  Print requires **Print**; report visibility uses **View**.
- Every screen open/close/denied action is written to a **user‑activity audit log**.

---

## 2. Domain Model

All records use **soft delete** (`isCanceled` flag, never physically deleted)
and carry a full **audit trail**: `createUser/modifiedUser/canceledUser`,
`dateCreate/dateModified/dateCanceled`, and the originating terminal ID for each.
A literal string `"default"` is used as a "no value / not applicable" foreign key
(the web version should use proper NULLs).

### 2.1 Master / Reference entities

**Petty Cash Account** (`tbl_pcbMasAccount`) — one cash float.
| Field | Notes |
|---|---|
| PcbAccount_ID | PK, code |
| PcbAccountName | Unique name |
| AssignedUser_ID | The custodian. A user may hold **only one active account**. |
| Currency_ID | Default `CUR/048` if not chosen |
| FloatAmount | The fixed float size; must be **> 0** |
| Gl_ID | The GL ledger account this float maps to ("PCB Ledger Account") |
| Prefix | Used to build expenditure transaction codes |
| Counter | Auto‑increment seed for the next expenditure code |
| Remarks | |

**Expenditure Type** (`tbl_pcbRefExpenditureType`) — maps a category group to a
GL account. Fields: `PcbExpenditureType_ID`, `Gl_ID`. Auto‑generated ID.

**Expenditure Category** (`tbl_pcbRefExpenditureCategory`) — the selectable
expense bucket on an expenditure line. Belongs to an Expenditure Type.
Fields: `PcbExpenditureCategory_ID`, `PcbExpenditureType_ID`, `Name`.

**Income Type** (`tbl_pcbRefIncomeType`) — reference list of income categories.
Fields: `PcbIncomeType_ID`, `PcbIncomeTypeName`.

### 2.2 Transaction entities

**IOU Request** (`tbl_pcbTxIOURequest`) — a staff request for a cash advance.
`IouRequest_ID, IouRequestDate, IouRequestedUser_ID, RequestAmount, Remarks,
IsSettled`. *Settled* = an IOU has been issued for it.

**IOU** (`tbl_pcbTxIOU`) — cash actually advanced to a user from a PC account.
`Iou_ID, IouDate, PcbAccount_ID, IouRequest_ID, IouUser_ID, IouAmount,
SettledAmount, IsSettled, Remarks`. *Settled* when `SettledAmount == IouAmount`.

**Expenditure (header)** (`tbl_pcbTxExpenditure`) —
`Expenditure_ID, ExpenditureDate, PcbAccount_ID, SpentUser_ID, Cost_Center_ID,
TotalAmount, AllocatedAmount, Reimbursment_ID, IsReimburst, Remarks`.
`AllocatedAmount` = portion of this expenditure that settled IOUs.

**Expenditure Detail (line)** (`tbl_pcbTxExpenditure_Detail`) —
`Expenditure_ID, PcbExpenditureCategory_ID, Amount, Remarks`. The header
`TotalAmount` is the **sum of all line Amounts**.

**IOU Refund** (`tbl_pcbTxIOURefund`) — staff returns unused advance cash.
`Refund_ID, RefundDate, PcbAccount_ID, User_ID, Amount, SettledAmount,
IsSettled, Remarks`.

**IOU Settlement** (`tbl_pcbTxIOUSettlement`) — the join that records how an IOU
was cleared. Each row links **one IOU** to **either an Expenditure or a Refund**
(the unused side holds `"default"`) with an `AllocatedAmount`.

**Reimbursement** (`tbl_pcbTxReimbursment`) —
`Reimbursment_ID, ReimbursmentDate, PcbAccount_ID, ReimbursmentTo (cutoff date),
NoOfExpences, TotalAmount, IsApproved, IsCanceled`. Creating one also creates an
**Account Payable Note** (`tbl_accAccountPayableNote` + `_SubTotal`) and posts a
GL journal.

### 2.3 Entity relationships

```
                 ┌─────────────────────┐
                 │ Petty Cash Account  │ 1 ── assigned ── 1  User (custodian)
                 │  float, GL, prefix  │
                 └─────────┬───────────┘
                           │ 1
            ┌──────────────┼───────────────┬───────────────────┐
            │ N            │ N             │ N                  │ N
   ┌────────▼──────┐ ┌─────▼──────┐  ┌─────▼───────┐   ┌────────▼────────┐
   │ Expenditure   │ │   IOU      │  │ IOU Refund  │   │ Reimbursement   │
   │  (header)     │ │            │  │             │   │  → APN → GL     │
   └───────┬───────┘ └─────┬──────┘  └──────┬──────┘   └────────┬────────┘
        1  │ N         ▲   │  ▲              │                   │ links N
   ┌───────▼───────┐   │   │  │              │            ┌──────▼────────┐
   │ Exp. Detail   │   │   │  │              │            │ Expenditures  │
   │ (category ln) │   │   │  │              │            │ (IsReimburst) │
   └───────┬───────┘   │   │  │              │            └───────────────┘
        N  │           │   │  │              │
   ┌───────▼───────┐   │   │  │              │
   │ Exp. Category │   │   │  └── IOU Settlement ──┘   (IOU ↔ Exp | IOU ↔ Refund)
   └───────┬───────┘   │   │
        N  │           │   │ N
   ┌───────▼───────┐   │ ┌─▼────────────┐
   │ Exp. Type     │   └─│ IOU Request  │  (1 request → 1 IOU)
   │  → GL acct    │     └──────────────┘
   └───────────────┘
```

---

## 3. Functional Modules & Screens

| # | Screen | Type | Function key | Purpose |
|---|---|---|---|---|
| 1 | Login | Window | — | Authenticate user |
| 2 | Landing / Home | Shell | — | Module menu, function list, tabbed work area |
| 3 | Petty Cash Account Creation | Master | `PCB_PettyCashAccCreation` | Define cash floats |
| 4 | Expenditure Type & Category | Master | `PCB_ExpenditureType` / `…Category` | Expense buckets ↔ GL |
| 5 | Income Type | Master | `PCB_IncomeType` | Income reference list |
| 6 | IOU Request | Transaction | `PCB_IOURequest` | Raise cash‑advance requests |
| 7 | **Petty Cash Book** | Transaction (hub) | `PCB_PettyCashBook` | Ledger view + launch all txns |
| 7a | Add Expenditure | Dialog | `PCB_AddExpenditure` | Record an expense + settle IOUs |
| 7b | Add IOU | Dialog | `PCB_AddIOU` | Advance cash to a user |
| 7c | IOU Refund | Dialog | `PCB_IOURefund` | Take back unused advance cash |
| 7d | Reimbursement Request | Dialog | `PCB_ReimbursmentRequest` | Top‑up float, post to GL |
| — | IOU Settlement | Background | `PCB_IOUSettlement` | Auto‑created allocation rows |
| 8 | Reports | Reports | `pcb_Reports` | 5 reports + Excel export |
| 9 | User Permission | Admin | `UserPermission` | Per‑user function matrix |
| — | Search popup | Shared | — | Configurable lookup dialog |

---

## 4. Workflow Processes

### 4.0 Login & session
1. User enters User ID + password on the Login window.
2. System looks up the user; compares **encrypted** password.
3. If `IsBlocked` → refuse with "contact administrator".
4. On success: load company info, enabled modules (only `ADM/000` and
   `PCB/025`), and the list of permitted functions; open the Landing page.
5. While running, a **session‑pool record** is polled every second; loss of the
   record means the session/network dropped (legacy only warns).

> **Web rebuild:** replace with standard session/JWT auth; the 1‑sec poll becomes
> a normal token‑expiry / heartbeat mechanism. Keep "account blocked" and the
> activity audit log.

### 4.1 Create / maintain a Petty Cash Account (Master)
**Goal:** define a cash float and who holds it.

1. Enter Account Name, pick **User** (custodian), **Currency**, **GL ledger
   account**, **Float Amount**, Remarks. Account code may be auto‑generated.
2. **Validation:** name not empty, GL not empty, user not empty, Float > 0,
   account name unique, **chosen user must not already hold an active account**.
3. Save → insert (Write permission) or update (Update permission).
4. Edit: select a row; only non‑cancelled accounts can be updated.
5. Cancel (soft delete): allowed **only if no expenditures exist** for the
   account ("Record Locked" otherwise). Sets `IsCanceled`.

### 4.2 Maintain Expenditure Types & Categories (Master)
1. **Add Type:** pick a GL account; an Expenditure Type code is auto‑generated
   and linked to that GL account.
2. **Add Category:** select a Type, type a category name in the grid; saved with
   an auto code, linked to the Type. Category name must be unique & non‑empty.
3. **Delete Type:** blocked if it has categories.
4. **Delete Category:** blocked if any expenditure detail uses it.
   Deletions are soft (`IsCanceled`).

### 4.3 Maintain Income Types (Master)
Simple CRUD list: ID (auto) + Name. Edit only if not cancelled; cancel = soft
delete. (No duplicate‑name check is currently enforced in code.)

### 4.4 IOU Request (cash‑advance request)
1. Requester (defaults to logged‑in user, can be changed via search) enters
   Request Date, Amount (> 0), Remarks.
2. Save creates the request (`IsSettled = false`).
3. Edit/Cancel allowed only while **not settled** and **not cancelled**.
4. The request becomes **Settled** automatically when an IOU is issued against it.
5. Grid lists only open (not settled, not cancelled) requests.

### 4.5 Petty Cash Book (the operational hub)
On open, the system finds the PC account **assigned to the logged‑in user**:
- If found → full edit mode for that account.
- If none → a message is shown and the screen falls back to **view mode**
  using the first available account (no transactions can be created).

It then displays, for a **From–To date range** (defaults: financial‑year start →
today):

- **Transaction ledger grid** (`sp_getPCB_TXN`): each expenditure/income row with
  running **Balance**; cancelled rows hidden unless "Show All" is ticked
  (then shown in red/orange).
- **Unsettled IOU grid**: open IOUs with running negative balance.
- Four headline figures:
  - **Float Amount** — from the account.
  - **Book Balance** — running balance of the ledger grid.
  - **Unsettled IOU Amount** — total open IOU (shown as a negative).
  - **Available Balance** = Book Balance + (negative) Unsettled IOU.

From here the custodian launches: **Add Expenditure**, **Add IOU**,
**IOU Refund**, **Refresh**, and **Reimbursement**. Double‑clicking a row's
Txn Code opens that expenditure/IOU for view/edit.

### 4.6 Add IOU (advance cash to a user)
1. Optionally pick an **IOU Request** (must be not‑cancelled & not‑settled). Its
   requester/amount/remarks are shown. If no request is chosen, request =
   `default` and the IOU user defaults to the logged‑in user.
2. Enter IOU Date, Amount (> 0), Remarks. Save (auto code).
3. On save with a request: the linked IOU Request is marked **Settled**.
4. Edit blocked if the IOU already has settlements (lists the offending
   Expenditure/Refund IDs) or is cancelled.
5. **Cancel:** reverses every settlement — for each settlement row it restores
   the linked Expenditure's `AllocatedAmount` or the Refund's `SettledAmount`
   (and clears their settled flag), deletes the settlement, then soft‑cancels
   the IOU.

### 4.7 Add Expenditure (record an expense; optionally settle IOUs)
1. Header: Expenditure Date (defaults today), **Spent By** user (required),
   Cost Centre, Remarks.
2. **Category lines grid:** add one or more rows — pick Expenditure Category,
   enter Amount and line Remarks. No duplicate category. **Total Amount =
   Σ line amounts** (recomputed on every edit).
3. **IOU Settlement grid (optional):** pick IOUs belonging to the same account &
   spent‑by user that are not cancelled/settled. (Used to clear advances the
   spender previously took.)
4. **Validation:** at least one category line; Spent By set; Total > 0.
   (Available‑balance and future‑date checks exist in code but are currently
   disabled.)
5. **Save — allocation algorithm** (run for new and edit):
   - Auto code = account **Prefix + Counter** (fails if account has no prefix).
   - Insert header + all detail lines.
   - For each selected IOU, let `unsettled = IouAmount − SettledAmount`:
     - if `remainingExpenditure < unsettled` → allocate `remainingExpenditure`,
       add to `IOU.SettledAmount`.
     - else → allocate the full `unsettled`, set `IOU.SettledAmount = IouAmount`,
       mark **IOU Settled**.
     - Create an **IOU Settlement** row (Expenditure ↔ IOU, allocated amount);
       decrement the running expenditure amount; accumulate `AllocatedAmount`.
   - Edit re‑does this: it first deletes old detail + settlement rows and rolls
     back the affected IOUs, then re‑inserts.
6. Edit/Cancel blocked if the expenditure is **already reimbursed** or already
   cancelled. Cancel also reverses IOU settlements before soft‑cancelling.
7. Print produces a Petty Cash Voucher.

### 4.8 IOU Refund (staff returns unused advance)
1. Pick the **User**, enter Refund Date, Amount (> 0), Remarks.
2. Add one or more of that user's open IOUs to the grid.
3. Save: same allocation algorithm as expenditure but the settlement links
   **Refund ↔ IOU**. The refund's `SettledAmount` accumulates; refund marked
   `IsSettled` when fully allocated.
4. Edit re‑computes (rollback then re‑allocate); Cancel reverses settlements and
   soft‑cancels. At least one IOU must be selected to save.

### 4.9 Reimbursement Request (replenish the float → GL posting)
**Goal:** reclaim the total of spent expenditures so the float returns to its
fixed size, and post the accounting journal.

1. On open it computes the account's current Book Balance and Unsettled IOU
   total (via `sp_getBookBalance`, `sp_getUnSettledIOUTotal`), and lists **all
   not‑cancelled, not‑reimbursed expenditures up to the "Reimbursment To" date**,
   all pre‑selected with checkboxes.
2. The user ticks/unticks expenditures to include. Live counters show
   *selected count/amount* vs *total count/amount*.
3. A **double‑entry preview** is built automatically:
   - **Debit:** each selected expenditure's category lines → the GL account of
     the category's Expenditure Type.
   - **Credit:** the PC account's GL account for the total.
   - If config `valueID = 704` ("post summarized APN") is on, debit lines are
     grouped by GL account.
4. **Save:**
   - Mark each selected expenditure `IsReimburst = true` and stamp the
     `Reimbursment_ID`.
   - Create the Reimbursement record (count + total).
   - Create an **Account Payable Note (APN)** header + subtotal lines from the
     double‑entry, then **post the GL transaction** (`PostTransaction_APN`).
   - Edit first rolls back (un‑reimburse expenditures, delete APN + GL posting)
     then re‑creates. Editing blocked once **Approved**.
5. **Approve** (separate permission): marks Reimbursement and its APN approved.
6. **Cancel** (only if not approved): un‑reimburses expenditures, marks the APN
   deleted, deletes the GL posting, soft‑cancels the reimbursement.

> This is the only place PCB writes into the shared GL/APN sub‑system. The web
> rebuild must either reuse those services or replicate: APN header + subtotal
> rows + a GL posting keyed to the reimbursement ID.

### 4.10 Reports
Report screen lists only reports the user has **View** permission for. Each
applies filters then renders via the report viewer (and one Excel export):

| Report | Filters |
|---|---|
| Expenditure Summary | PC Account*, User, date range |
| Expenditure Details | PC Account*, User, date range |
| IOU Summary | PC Account*, User, Status (All/Settled/Unsettled), dates |
| IOU Request Summary | User, date range |
| IOU Refund Summary | PC Account*, User, date range |
| Expenditure Summary (Account‑wise) | PC Account, dates → **Excel** |

`*` PC Account is mandatory for those reports. All show company header, date
range, and "Cancelled" watermark where relevant.

### 4.11 User Permission (Admin)
1. Pick a User; choose "UIs" or "Reports"; **Load** builds a grid of every PCB
   function with checkboxes for Read/Write/Edit/Cancel/Check/Approve/Print/
   Re‑print/Export/View. "Select‑all" toggles per column.
2. **Save** upserts a permission row per function for that user+branch.

### 4.12 Search popup (shared lookup) — cross‑cutting
Reusable modal lookup driven by config tables (`tbl_cfgSearch`,
`tbl_cfgSearchDetail`): columns, filters, base SQL and parameter substitution
are data‑defined per search type. Behaviour: type‑to‑filter, F9 cycles filter
field, ↑/↓ navigate, Enter/click selects, "Show All" includes cancelled rows.
By default it hides cancelled rows and, by search type, also hides
reimbursed/settled rows. Many fields across the app are "double‑click to search".

> **Web rebuild:** implement as a generic searchable picker/autocomplete
> component backed by a config‑driven lookup endpoint.

---

## 5. Business Rules (consolidated)

### 5.1 Petty Cash Account
- BR‑A1: Float Amount must be **> 0**.
- BR‑A2: Account Name must be **unique**.
- BR‑A3: A user can be the custodian of **at most one active account**.
- BR‑A4: Currency defaults to `CUR/048` when not specified.
- BR‑A5: An account **cannot be cancelled** if it has any expenditure.
- BR‑A6: A cancelled account cannot be edited.
- BR‑A7: Expenditure transaction codes = account **Prefix + Counter**; an
  account with no prefix cannot record expenditures.

### 5.2 Expenditure Type / Category
- BR‑T1: An Expenditure Type maps to exactly one GL account.
- BR‑T2: A Type cannot be deleted while it has categories.
- BR‑T3: A Category cannot be deleted while referenced by any expenditure line.
- BR‑T4: Category name must be non‑empty and unique.

### 5.3 IOU Request / IOU
- BR‑R1: Request amount must be **> 0**.
- BR‑R2: A Request can be edited/cancelled only while **not settled** and not
  cancelled.
- BR‑R3: Issuing an IOU against a Request marks that Request **Settled**.
- BR‑R4: IOU amount must be **> 0**.
- BR‑R5: An IOU is **Settled** when `SettledAmount == IouAmount`.
- BR‑R6: An IOU with existing settlements cannot be edited (must reverse first).
- BR‑R7: Cancelling an IOU reverses all its settlements (restoring the linked
  Expenditure/Refund amounts) before soft‑cancelling.
- BR‑R8: Only not‑cancelled, not‑settled IOUs of the matching account & user can
  be selected for settlement.

### 5.4 Expenditure
- BR‑E1: At least one category line is required.
- BR‑E2: "Spent By" user is required.
- BR‑E3: Total Amount = Σ line amounts, and must be **> 0**.
- BR‑E4: No duplicate category within one expenditure.
- BR‑E5: Editing/cancelling is blocked if the expenditure **IsReimburst** or
  **IsCanceled**.
- BR‑E6: IOU allocation: smaller‑of(remaining expenditure, IOU unsettled) per
  IOU, sequentially, until expenditure exhausted; full coverage marks the IOU
  settled. `AllocatedAmount` on the header = total allocated to IOUs.
- BR‑E7: Edit = full rollback (delete details + settlements, restore IOUs) then
  re‑insert.
- BR‑E8 *(present but disabled in code — confirm for web):* Expenditure amount
  ≤ Available Balance; Expenditure date not in the future.

### 5.5 IOU Refund
- BR‑F1: User and Amount (> 0) required; at least one IOU selected to save.
- BR‑F2: Same allocation algorithm as expenditure, linking Refund ↔ IOU.
- BR‑F3: Refund `IsSettled` when fully allocated; edit = rollback + re‑allocate;
  cancel reverses settlements.

### 5.6 Reimbursement
- BR‑M1: Only **not‑cancelled, not‑reimbursed** expenditures **dated ≤ the
  Reimbursment‑To date** are eligible.
- BR‑M2: At least one expenditure must be selected.
- BR‑M3: Saving marks the selected expenditures `IsReimburst` and links them.
- BR‑M4: Saving creates an APN + GL posting; double entry = debit category GL
  accounts, credit PC account GL; optionally summarized by GL (config 704).
- BR‑M5: An **Approved** reimbursement cannot be edited or cancelled.
- BR‑M6: Cancel reverses everything (un‑reimburse, delete APN, delete GL posting).

### 5.7 Cross‑cutting
- BR‑X1: Nothing is hard‑deleted; cancellation sets `IsCanceled` + audit fields.
- BR‑X2: Every create/modify/cancel stamps user, timestamp and terminal.
- BR‑X3: All access is gated by the per‑user/function/branch permission matrix;
  denials are audit‑logged.
- BR‑X4: Only the user's own assigned account is editable; everything else is
  view‑only.
- BR‑X5: Money is displayed with thousands separators; negatives shown in
  parentheses, e.g. `(1,000.00)`.
- BR‑X6: Codes are server‑generated (prefix + zero‑padded counter); the counter
  must increment atomically.

---

## 6. Wireframes (target web layouts)

ASCII sketches of the intended screens. Keep the *information* and *controls*;
modernise the styling.

### 6.1 Login
```
        ┌───────────────────────────────────┐
        │                SEACC              │
        │                                   │
        │   User ID   [____________________]│
        │   Password  [__________________] 👁│
        │                                   │
        │                     [  Sign In  ] │
        └───────────────────────────────────┘
```

### 6.2 Landing / Shell
```
┌──────────────────────────────────────────────────────────────────────┐
│ [Logo]  Company Name                         👤 User (Group)  [Logout]│
├───────────────┬──────────────────────────────────────────────────────┤
│ MODULES       │  ┌── Tab: Petty Cash Book ──┐ ┌── Tab: Reports ──┐    │
│  • Admin      │  │                           │ │                   │   │
│  • PCB        │  │   (active function opens  │ │                   │   │
│               │  │    here as a tab)         │ │                   │   │
│ FUNCTIONS     │  │                           │ │                   │   │
│  - PC Account │  │                           │ │                   │   │
│  - Exp Types  │  │                           │ │                   │   │
│  - Income Typ │  │                           │ │                   │   │
│  - IOU Request│  │                           │ │                   │   │
│  - Petty Cash │  │                           │ │                   │   │
│  - Reports    │  │                           │ │                   │   │
│  - User Perm. │  │                           │ │                   │   │
└───────────────┴───────────────────────────────────────────────────────┘
```

### 6.3 Master screen pattern (Account / Income Type)
Split view: list on the left, edit form on the right, action bar at the bottom.
```
┌──────────────────────────────────────────────────────────────────────┐
│  ┌─ List ───────────────┐ │  Edit Form                                │
│  │ Code  Name      User │ │   PC Account Code [<Auto Generate>]       │
│  │ ───────────────────  │ │   PC Account Name [__________________]    │
│  │ PCB01 Head Off  J.D. │ │   User            [____________] (search) │
│  │ PCB02 Branch A  S.M. │ │   Currency        [LKR_________] (search) │
│  │  ...                 │ │   Float Amount    [        0.00]          │
│  │                      │ │   Remarks         [__________________]    │
│  │                      │ │   ── Accounts Configuration ──            │
│  │                      │ │   PCB Ledger Acct [____________] (search) │
│  └──────────────────────┘ │                                           │
├──────────────────────────────────────────────────────────────────────┤
│                                   [ New ]  [ Save ]  [ Cancel ]       │
└──────────────────────────────────────────────────────────────────────┘
```

### 6.4 Expenditure Type & Category
```
┌──────────────────────────────────────────────────────────────────────┐
│ ┌ Combined view ──────────┐ │ Expenditure Types          [ + ] [ x ] │
│ │ TypeID  ExpDesc  CatID   │ │  TypeID   GL Account Description       │
│ │ ...     ...      ...     │ │  ET001    5101 Travel                  │
│ └──────────────────────────┘ │  ET002    5102 Stationery              │
│                              │ ───────────────────────────────────── │
│                              │ Expenditure Categories     [ + ] [ x ] │
│                              │  CatID    Description                  │
│                              │  EC001    Taxi                         │
│                              │  EC002    Bus / Train                  │
└──────────────────────────────────────────────────────────────────────┘
```

### 6.5 Petty Cash Book (hub)
```
┌──────────────────────────────────────────────────────────────────────┐
│ PCB — <Account Name>     Float 8,000.00  Book 3,500.00  IOU (1,000.00)│
│                                          Available 2,500.00  [Reimburs]│
├──────────────────────────────────────────────────────────────────────┤
│ Transactions From [01/04/2026] To [18/05/2026]  ☐ Show All      [ + ] │
│ ┌───────────────────────────────────────────────────────────────────┐ │
│ │ Date     Txn Code  Spent By  Remarks      Expenses Income Balance │ │
│ │ 02/04/26 PCB001     J. Doe   Taxi          1,000.—    —   7,000.— │ │
│ │ 05/04/26 PCB002     S. Mar.  Stationery      500.—    —   6,500.— │ │
│ └───────────────────────────────────────────────────────────────────┘ │
│ Unsettled IOU                                  [refund] [⟳] [ + ]      │
│ ┌───────────────────────────────────────────────────────────────────┐ │
│ │ Date   Txn Code  Remarks       IOU Amt  Unsettled  Balance        │ │
│ │ 03/04  IOU001     Advance J.D. 1,000.—   1,000.—   (1,000.—)      │ │
│ └───────────────────────────────────────────────────────────────────┘ │
└──────────────────────────────────────────────────────────────────────┘
```

### 6.6 Add Expenditure (modal)
```
┌──── Add Expenditure ─────────────────────────────────────────── [x] ──┐
│ Expenditure ID [<Auto>]          Category lines:        [ + ] [ – ]   │
│ Exp. Date      [18/05/2026]      ┌─────────────────────────────────┐  │
│ Spent By       [________](srch)  │ Category   Amount   Remarks     │  │
│ Cost Centre    [________](srch)  │ Taxi        600.00  airport     │  │
│ Remarks        [______________]  │ Meals       400.00  client      │  │
│                                  └─────────────────────────────────┘  │
│                                  Total Amount [      1,000.00]         │
│ ── IOU Settlement ──                                   [ + ] [ – ]    │
│ ┌───────────────────────────────────────────────────────────────────┐ │
│ │ IOU #   IOU Amount   Unsettled Amount   Allocated Amount          │ │
│ │ IOU001    1,000.00      1,000.00            1,000.00              │ │
│ └───────────────────────────────────────────────────────────────────┘ │
│                       [ New ]  [ Save ]  [ Print ]  [ Cancel ]        │
└──────────────────────────────────────────────────────────────────────┘
```

### 6.7 Add IOU (modal)
```
┌──── Add IOU ─────────────────────────────────────────────────── [x] ──┐
│ IOU ID       [<Auto>]            ── Linked IOU Request (optional) ──   │
│ Request ID   [________](search)  Date        : 10/05/2026             │
│ IOU Date     [18/05/2026]        Requested By: J. Doe                  │
│ Amount       [      0.00]        Req. Amount : 1,000.00               │
│ Remarks      [______________]    Remarks     : Site visit advance     │
│                       [ New ]  [ Save ]  [ Print ]  [ Cancel ]        │
└──────────────────────────────────────────────────────────────────────┘
```

### 6.8 IOU Refund (modal)
```
┌──── IOU Refund ──────────────────────────────────────────────── [x] ──┐
│ Refund ID [<Auto>]   User [________](search)                          │
│ Date      [18/05/2026]  Amount [0.00]  Remarks [________________]     │
│ Select IOUs to refund against:                          [ + ] [ – ]   │
│ ┌───────────────────────────────────────────────────────────────────┐ │
│ │ IOU #   IOU Amount   Unsettled Amount   Allocated Amount          │ │
│ └───────────────────────────────────────────────────────────────────┘ │
│                       [ New ]  [ Save ]  [ Print ]  [ Cancel ]        │
└──────────────────────────────────────────────────────────────────────┘
```

### 6.9 Reimbursement Request (modal)
```
┌──── Add Reimbursement Request ───────────────────────────────── [x] ──┐
│ Reimbursement Req # [<Auto>]     Reimbursement To [18/05/2026]        │
│ ┌ Eligible expenditures (tick to include) ────────────────────────┐  │
│ │ ☑ Line Date     Txn      Remarks       Spent By     Amount      │  │
│ │ ☑  1   02/04/26 PCB001   Taxi          J. Doe       1,000.00    │  │
│ │ ☑  2   05/04/26 PCB002   Stationery    S. Mar.        500.00    │  │
│ └─────────────────────────────────────────────────────────────────┘  │
│ ┌ Double entry preview ───────────────────────────────────────────┐  │
│ │ No AccountCode AccountName    Remarks   Debit     Credit         │  │
│ │  1  5101       Travel         …         1,000.00                 │  │
│ │  2  5102       Stationery     …           500.00                 │  │
│ │  3  1010       Petty Cash A/C …                    1,500.00      │  │
│ └─────────────────────────────────────────────────────────────────┘  │
│ Count 2/2   Amount 1,500.00/1,500.00                                  │
│           [ New ] [ Save ] [ Approve ] [ Print ] [ Cancel ]          │
└──────────────────────────────────────────────────────────────────────┘
```

### 6.10 Reports
```
┌──────────────────────────────────────────────────────────────────────┐
│ ┌ Reports (View‑permitted) ┐ │  Filters                              │
│ │ • Expenditure Summary    │ │  PC Account [<All>______](search)     │
│ │ • Expenditure Details    │ │  User       [<All>______](search)     │
│ │ • IOU Summary            │ │  Status     [All ▾]  (IOU Summary)    │
│ │ • IOU Request Summary    │ │  From [__/__/____]  To [__/__/____]   │
│ │ • IOU Refund Summary     │ │                                       │
│ │ • Exp. Summary Acc‑wise  │ │            [ Print ]   [ Clear ]      │
│ └──────────────────────────┘ │                                       │
└──────────────────────────────────────────────────────────────────────┘
```

### 6.11 User Permission (Admin)
```
┌──────────────────────────────────────────────────────────────────────┐
│ User [__________](search)   ◉ UIs  ○ Reports        [ Load ]         │
│ ┌──────────────────────────────────────────────────────────────────┐  │
│ │ #  Function Name   Read Write Edit Cncl Chk Appr Prnt RePr Exp Vw│  │
│ │ 801 PC Account      ☑   ☑    ☑   ☑   ☐   ☐   ☑   ☐   ☐  ☐│  │
│ │ 804 Add Expenditure ☑   ☑    ☑   ☑   ☐   ☐   ☑   ☐   ☐  ☐│  │
│ │ … (select‑all per column in header)                               │  │
│ └──────────────────────────────────────────────────────────────────┘  │
│                                          [ New ]   [ Save ]          │
└──────────────────────────────────────────────────────────────────────┘
```

### 6.12 Search popup (shared)
```
┌──── <Lookup Title> ──────────────────────────────── [x] ──┐
│ Filter by [Name ▾]  [type to filter…]      ☐ Show All     │
│ ┌───────────────────────────────────────────────────────┐ │
│ │ Code    Name             …                            │ │
│ │ U001    John Doe                                      │ │
│ │ U002    Sara Marsh        (cancelled rows in red)     │ │
│ └───────────────────────────────────────────────────────┘ │
│   Enter / double‑click = select · F9 = next filter        │
└───────────────────────────────────────────────────────────┘
```

---

## 7. Non‑Functional & Rebuild Notes

1. **Soft delete everywhere** — keep the `IsCanceled` + full audit columns;
   never hard‑delete. "Show All" toggles visibility of cancelled rows.
2. **Atomic code generation** — prefix + counter must increment under a
   transaction/lock to avoid duplicate codes (legacy increments a counter row).
3. **Money formatting** — thousands separators, 2 decimals, negatives in
   parentheses; store as decimal, not float.
4. **Allocation algorithm is reused** in 3 places (Expenditure→IOU,
   Refund→IOU, and rollback‑on‑edit) — implement it once as a shared service.
5. **GL/APN integration** — Reimbursement must produce an APN (header + subtotal
   lines) and a GL posting; cancellation must reverse both. This crosses module
   boundaries — design the integration contract explicitly.
6. **Permission matrix** — model `(user, function, branch) → 10 boolean rights`;
   enforce server‑side on every action, not just by hiding buttons.
7. **One‑account‑per‑custodian** and **assigned‑account‑only editing** are core
   safety rules; the hub must clearly show view‑mode vs edit‑mode.
8. **Configurable lookups** — the search popup is metadata‑driven; reproduce
   with a generic lookup endpoint + reusable picker component.
9. **Server‑computed balances** — Book Balance / Unsettled IOU / ledger come from
   stored procedures (`sp_getPCB_TXN`, `sp_getBookBalance`,
   `sp_getUnSettledIOUTotal`); reproduce this logic carefully and centrally so
   the dashboard, reimbursement and reports stay consistent.
10. **Audit logging** — keep the per‑screen activity log (open/denied/save/etc.)
    for traceability.

### 7.1 Suggested REST endpoints (illustrative)
```
POST /auth/login                       GET  /pcb/accounts            CRUD
GET  /pcb/book?account&from&to         POST /pcb/expenditures        + lines + IOU alloc
GET  /pcb/book/iou-open?account        POST /pcb/ious
POST /pcb/iou-requests                 POST /pcb/iou-refunds
POST /pcb/reimbursements               POST /pcb/reimbursements/{id}/approve
GET  /pcb/exp-types  /exp-categories  /income-types
GET  /pcb/reports/{type}?filters       GET  /lookup/{searchType}?q
GET/PUT /admin/permissions?user&branch
```

---

## 8. Open Questions / Decisions for the Web Build
1. **Disabled validations** (BR‑E8: future‑date & available‑balance on
   expenditure) — were these intentionally turned off? Decide whether to enforce.
2. **Income Type** has a reference table and master screen but no transaction
   currently consumes it — confirm whether "income" rows in the ledger are
   planned/used, or if this is dormant.
3. **Multi‑branch / multi‑company** — IDs are carried everywhere; confirm the
   web app's tenancy scope.
4. **Reimbursement editing after GL posting** — legacy allows edit before
   approval by deleting & re‑posting GL. Confirm this is acceptable accounting
   behaviour or require reversal entries instead.
5. **Currency** — accounts carry a currency but no FX handling exists; confirm
   single‑currency assumption per account.
6. Confirm the exact **GL posting rules** with the finance team by reading the
   shared `clsMethods_GL.PostTransaction_APN` / APN sub‑system (outside this
   module's source) before re‑implementing section 4.9.
```
