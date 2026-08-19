import { useState } from 'react';
import MeridianPage from '../../Meridian/MeridianPage';
import MessageBoxService from '../../../services/MessageBoxService';
import { TRACKING_ROWS } from '../Reports/mockReportData';

// Demo-only: age buckets below are derived from the shared sample data, not
// real unsettled-days math, and the "Send" buttons are not wired to a real
// mailer — this app has no email-sending infrastructure yet.
const TIERS = [
  {
    key: 'accounts',
    title: 'Company / Accounts Dept',
    recipient: 'accounts@pps.lk',
    thresholdDays: 0,
    description: 'Every unsettled IOU, regardless of age.',
  },
  {
    key: 'gm',
    title: 'Company / GM',
    recipient: 'gm@pps.lk',
    thresholdDays: 5,
    description: 'Escalation: more than 5 days unsettled.',
  },
  {
    key: 'ceo',
    title: 'Company / CEO',
    recipient: 'ceo@pps.lk',
    thresholdDays: 7,
    description: 'Escalation: more than 7 days unsettled.',
  },
];

const unsettled = TRACKING_ROWS.filter((r) => r.status !== 'Fully Settled');

export default function AgeAnalysisAlert() {
  const [sending, setSending] = useState(null);

  const handleSend = async (tier) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: `Send the age-analysis alert to ${tier.recipient} now?`,
      type: 'primary', confirmText: 'Send', cancelText: 'Cancel',
    });
    if (!confirmed) return;
    setSending(tier.key);
    setTimeout(() => {
      setSending(null);
      MessageBoxService.show({
        message: 'Not wired up yet — this app has no email-sending set up. Nothing was actually sent.',
        type: 'warning',
      });
    }, 400);
  };

  return (
    <MeridianPage title="Age-Analysis Alerts" subtitle="Demo data — email sending is not wired up yet">
      <div className="ml-form-section">
        <div className="row g-3">
          {TIERS.map((tier) => {
            const count = unsettled.length; // demo: every tier looks at the same sample set
            return (
              <div className="col-md-4" key={tier.key}>
                <div className="card h-100">
                  <div className="card-body">
                    <h6 className="card-title">{tier.title}</h6>
                    <p className="text-muted small mb-2">{tier.description}</p>
                    <p className="mb-1"><strong>Recipient:</strong> {tier.recipient}</p>
                    <p className="mb-3">
                      <strong>Would notify:</strong>{' '}
                      <span className="badge bg-warning text-dark">{count} document{count === 1 ? '' : 's'}</span>
                    </p>
                    <button
                      type="button" className="btn btn-outline-primary btn-sm"
                      disabled={sending === tier.key}
                      onClick={() => handleSend(tier)}
                    >
                      <i className="bi bi-envelope me-1" />
                      {sending === tier.key ? 'Sending...' : 'Send Test Email'}
                    </button>
                  </div>
                </div>
              </div>
            );
          })}
        </div>

        <div className="mt-4">
          <h6 className="mb-2">Unsettled IOUs (sample)</h6>
          <div className="table-responsive">
            <table className="table table-sm mb-0">
              <thead className="table-light">
                <tr><th>Request No</th><th>Party</th><th>Requested</th><th>Status</th></tr>
              </thead>
              <tbody>
                {unsettled.map((r) => (
                  <tr key={r.requestNo}>
                    <td>{r.requestNo}</td>
                    <td>{r.party}</td>
                    <td className="text-end">{r.requested.toLocaleString(undefined, { minimumFractionDigits: 2 })}</td>
                    <td>{r.status}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </MeridianPage>
  );
}
