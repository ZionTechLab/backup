# User Menu

The top-right corner of every screen has your account controls and a few quick-access icons.

*Mock illustrations below — not real screenshots of your instance.*

## The Top-Right Cluster

![Top-right icon cluster](/help/images/topbar-cluster.svg)

| # | Item | What it does |
|---|---|---|
| ① | Search | Opens the command palette to jump to any screen. See [Search](search.md). |
| ② | Notifications | Shows a count of unread notifications. Click to open them. |
| ③ | Theme toggle | Switches between light and dark mode immediately, no page reload. |
| ④ | Fullscreen | Expands the browser to fullscreen — useful on smaller screens or when presenting. |
| ⑤ | User menu | Your avatar, first name, and a dropdown of account actions (below). |

## The User Dropdown

Click your avatar (or name, on wider screens) to open it:

![User dropdown menu](/help/images/user-dropdown.svg)

| # | Item | What it does |
|---|---|---|
| — | Header | Shows your full name and role, for confirming which account you're signed in as. |
| ① | [Profile](profile.md) | Your own account details — name, contact info, and (where enabled) password change. |
| ② | [API Settings](api-settings.md) | Manage API keys/tokens for integrating other systems with this account. |
| ③ | [Notifications](notifications.md) | Configure which events notify you and how (in-app, email, etc.). |
| ④ | [Theme](theme.md) | The same light/dark toggle as the top bar, plus any additional appearance options. |
| ⑤ | [Tenant Settings](tenant-settings.md) | Tenant-wide defaults — date format, default theme, table/list behavior. Affects every user in the tenant, not just you. |
| ⑥ | Help | This help section — reachable from anywhere in the app. |
| ⑦ | Sign out | Ends your session and returns you to the login screen. |

## My Wallet

Not part of this dropdown — **My Wallet** lives in the main left drawer, not the account menu. See [My Wallet](wallet.md) for what it shows.

## A Note on Sessions

Signing out (or closing the browser without "Keep me signed in" checked) clears your session. Your access token isn't kept anywhere persistent — only the refresh token is, so on a plain page reload the app quietly re-authenticates you in the background if you were still signed in.
