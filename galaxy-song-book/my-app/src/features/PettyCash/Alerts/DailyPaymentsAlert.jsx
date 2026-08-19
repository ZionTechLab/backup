import { useState } from 'react';
import MeridianPage from '../../Meridian/MeridianPage';
import MessageBoxService from '../../../services/MessageBoxService';
import { YESTERDAYS_PAYMENTS } from '../Reports/mockReportData';

// Demo-only: sample data below, and "Send Now" is not wired to a real
// mailer — this app has no email-sending infrastructure yet.
export default function DailyPaymentsAlert() {
  const [sending, setSending] = useState(false);
  const total = YESTERDAYS_PAYMENTS.reduce((s, r) => s + r.amount, 0);

  const handleSend = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Send yesterday\'s petty cash payment summary now?',
      type: 'primary', confirmText: 'Send', cancelText: 'Cancel',
    });
    if (!confirmed) return;
    setSending(true);
    setTimeout(() => {
      setSending(false);
      MessageBoxService.show({
        message: 'Not wired up yet — this app has no email-sending set up. Nothing was actually sent.',
        type: 'warning',
      });
    }, 400);
  };

  return (
    <MeridianPage
      title="Daily Payments Alert"
      subtitle="Start-of-day preview — demo data, email sending is not wired up yet"
      actions={
        <button type="button" className="ml-btn-action ml-fab" disabled={sending} onClick={handleSend}>
          <i className="bi bi-envelope me-1" aria-hidden="true" />
          {sending ? 'Sending...' : 'Send Now'}
        </button>
      }
    >
      <div className="ml-form-section">
        <p className="text-muted">
          Every petty cash payment recorded yesterday, highest amount first — this is what the
          start-of-day email would contain.
        </p>
        <div className="table-responsive">
          <table className="table table-sm align-middle mb-0">
            <thead className="table-light">
              <tr>
                <th>Cashier</th>
                <th>Category</th>
                <th>Department</th>
                <th>Description</th>
                <th className="text-end">Amount</th>
              </tr>
            </thead>
            <tbody>
              {YESTERDAYS_PAYMENTS.map((r, i) => (
                <tr key={i}>
                  <td>{r.cashier}</td>
                  <td>{r.category}</td>
                  <td>{r.department}</td>
                  <td>{r.description}</td>
                  <td className="text-end">{r.amount.toLocaleString(undefined, { minimumFractionDigits: 2 })}</td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr className="table-light fw-bold">
                <td colSpan={4} className="text-end">Total</td>
                <td className="text-end">{total.toLocaleString(undefined, { minimumFractionDigits: 2 })}</td>
              </tr>
            </tfoot>
          </table>
        </div>
      </div>
    </MeridianPage>
  );
}
