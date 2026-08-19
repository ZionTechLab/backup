# API Settings

*Mock illustration below — not a real screenshot of your instance.*

![API Settings page](/help/images/api-settings.svg)

## API Keys

Lists the keys issued to your account for integrating other systems (scripts, external tools) with this one.

- **Copy** — copies the full key to your clipboard. The key is shown partially masked on screen; copy gives you the real value.
- **Revoke** — permanently disables that key. Anything using it will start failing immediately. This cannot be undone — a fresh key has to be generated and every integration using the old one updated.
- **Generate New Key** — issues a new key. Update any integration that needs it.

Treat API keys like passwords: don't paste them into chat, tickets, or shared documents.

## Webhook Endpoints

The **Webhook URL** is where this account's events get POSTed as they happen (e.g. for wiring this system into another one). Enter the URL and click **Save Webhook**.

## Note

This screen is currently a prototype — the keys shown are sample data, and Revoke/Generate don't yet call a real backend.
