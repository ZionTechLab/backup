# Petty Cash

## The Flow

Petty cash money moves through a chain of documents:

1. **IOU Request** — someone asks for money ahead of spending it.
2. **IOU Issue** — the request is approved and cash is actually handed out.
3. **IOU Settlement** — bills are submitted against the issued cash, and any leftover balance is returned or paid out.

Each step can be partially settled — an IOU Request can be drawn down across several IOU Issues, and one Settlement can close out several open IOUs at once for the same person.

## Masters

Set these up before day-to-day transactions:

- **Petty Cash Account** — one per physical cash box, linked to a GL account.
- **Petty Cash Expense Categories** — the spend categories your bills get coded to.
- **Parameters** — limits and settings that govern petty cash behavior (e.g. approval thresholds).

## Approvals

Requests and Issues go through an approval workflow before the cash moves. If your document is stuck, check its status badge — it tells you which stage it's waiting on. Approvers see items needing action under **My Approvals**.

## Common Questions

**Why can't I create an IOU Issue directly?**
Some tenants require every Issue to trace back to an approved Request — check with your administrator if this applies to you.

**My Settlement's numbers don't balance — why?**
Bills + cash returned must equal what's allocated against open IOUs plus anything extra paid out. The screen shows a live running total as you enter lines.
