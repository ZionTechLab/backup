import { useEffect, useState, useMemo } from 'react';
import MeridianPage from '../Meridian/MeridianPage';
import StatCard from '../../components/StatCard/StatCard';
import SimpleBarChart from '../../components/Charts/SimpleBarChart';
import Modal from '../../components/Modal';
import ApiService from './service';
import useMenuLabel from '../../helpers/useMenuLabel';

const formatCurrency = (val) =>
  val == null ? '...' : new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' }).format(val);

export default function WalletDashboard() {
  const [summary, setSummary] = useState(null);
  const [monthlyTopups, setMonthlyTopups] = useState([]);
  const [journal, setJournal] = useState({ loading: true, data: [] });
  const [showTopupModal, setShowTopupModal] = useState(false);
  const [topupAmount, setTopupAmount] = useState('');
  const [topupNarration, setTopupNarration] = useState('');
  const [topupSubmitting, setTopupSubmitting] = useState(false);
  const [topupMsg, setTopupMsg] = useState(null);
  const menuLabel = useMenuLabel('/wallet', 'My Wallet');

  useEffect(() => {
    Promise.all([fetchSummary(), fetchMonthlyTopups(), fetchJournal()]);
  }, []);

  const fetchSummary = async () => {
    const { success, data } = await ApiService.getSummary();
    if (success) setSummary(data);
  };

  const fetchMonthlyTopups = async () => {
    const { success, data } = await ApiService.getMonthlyTopups();
    if (success) setMonthlyTopups(data);
  };

  const fetchJournal = async () => {
    const { success, data } = await ApiService.getPaymentJournal();
    setJournal({ loading: false, data: success ? data : [] });
  };

  const handleTopupSubmit = async (e) => {
    e.preventDefault();
    setTopupMsg(null);
    const amt = parseFloat(topupAmount);
    if (isNaN(amt) || amt <= 0) {
      setTopupMsg({ type: 'danger', text: 'Please enter a valid positive amount.' });
      return;
    }
    setTopupSubmitting(true);
    const { success, error } = await ApiService.addTopup(amt, topupNarration.trim() || 'Top-up');
    setTopupSubmitting(false);
    if (success) {
      setTopupMsg({ type: 'success', text: `Successfully topped up ${formatCurrency(amt)}.` });
      setTopupAmount('');
      setTopupNarration('');
      fetchSummary();
      fetchMonthlyTopups();
      fetchJournal();
    } else {
      setTopupMsg({ type: 'danger', text: error || 'Top-up failed.' });
    }
  };

  const chartData = useMemo(
    () => monthlyTopups.map((d) => ({ label: d.month, value: d.amount })),
    [monthlyTopups],
  );

  const handleCloseModal = () => {
    setShowTopupModal(false);
    setTopupAmount('');
    setTopupNarration('');
    setTopupMsg(null);
  };

  return (
    <MeridianPage
      title={menuLabel}
      subtitle="Top up your Galaxy ERP wallet — no limits, no cap."
      actions={
        <button className="btn btn-primary" onClick={() => setShowTopupModal(true)}>
          <i className="bi bi-plus-lg me-1" />
          Top Up Now
        </button>
      }
    >
      {/* --- Summary Widgets --- */}
      <div className="row g-3 mb-4 px-3 pt-3">
        <div className="col-6 col-md-3">
          <StatCard
            title="Available Balance"
            value={summary ? formatCurrency(summary.availableBalance) : '...'}
            color="primary"
            size="md"
          />
        </div>
        <div className="col-6 col-md-3">
          <StatCard
            title="Total Top-ups"
            value={summary ? formatCurrency(summary.totalTopups) : '...'}
            color="success"
            size="md"
          />
        </div>
        <div className="col-6 col-md-3">
          <StatCard
            title="This Month"
            value={summary ? formatCurrency(summary.monthlyTopup) : '...'}
            color="info"
            size="md"
          />
        </div>
        <div className="col-6 col-md-3">
          <StatCard
            title="Top-ups YTD"
            value={summary ? formatCurrency(summary.ytdTopups) : '...'}
            color="warning"
            size="md"
          />
        </div>
      </div>

      {/* --- Chart --- */}
      <div className="px-3 mb-4">
        <div className="card">
          <div className="card-header">
            <h5 className="card-title mb-0">Last 12 Months Top-ups</h5>
          </div>
          <div className="card-body">
            {chartData.length > 0 ? (
              <SimpleBarChart data={chartData} height={220} color="#198754" />
            ) : (
              <p className="text-muted text-center py-4 mb-0">No top-up data yet.</p>
            )}
          </div>
        </div>
      </div>

      {/* --- My Payment Journal --- */}
      <div className="px-3 pb-3">
        <div className="card">
          <div className="card-header">
            <h5 className="card-title mb-0">My Payment Journal</h5>
          </div>
          <div className="card-body p-0">
            {journal.loading ? (
              <div className="text-center py-5">
                <div className="spinner-border text-primary" role="status" />
                <p className="text-muted mt-2 mb-0">Loading journal...</p>
              </div>
            ) : journal.data.length === 0 ? (
              <div className="text-center py-5">
                <i className="bi bi-journal-text fs-1 text-muted d-block mb-2" />
                <p className="text-muted mb-0">No transactions yet. Top up to get started.</p>
              </div>
            ) : (
              <div className="table-responsive">
                <table className="table table-hover mb-0">
                  <thead className="table-light">
                    <tr>
                      <th className="ps-3">Date</th>
                      <th>Txn Ref#</th>
                      <th>Txn Type</th>
                      <th>Narration</th>
                      <th className="text-end">Open.Bal</th>
                      <th className="text-end">Credit Amt.</th>
                      <th className="text-end">Debit Amt.</th>
                      <th className="text-end pe-3">Clos.Balance</th>
                    </tr>
                  </thead>
                  <tbody>
                    {journal.data.map((row, i) => (
                      <tr key={i}>
                        <td className="ps-3 text-nowrap">{row.date}</td>
                        <td>
                          {row.txnRef ? (
                            <a href={row.txnUrl || '#'} className="text-decoration-none">
                              {row.txnRef}
                            </a>
                          ) : (
                            <span className="text-muted">—</span>
                          )}
                        </td>
                        <td>
                          <span className={`badge ${row.type === 'Credit' ? 'bg-success' : 'bg-secondary'}`}>
                            {row.type}
                          </span>
                        </td>
                        <td>{row.narration || '—'}</td>
                        <td className="text-end">{formatCurrency(row.openBal)}</td>
                        <td className="text-end text-success">
                          {row.type === 'Credit' ? formatCurrency(row.amount) : '—'}
                        </td>
                        <td className="text-end text-danger">
                          {row.type === 'Debit' ? formatCurrency(Math.abs(row.amount)) : '—'}
                        </td>
                        <td className="text-end pe-3 fw-semibold">{formatCurrency(row.closeBal)}</td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            )}
          </div>
        </div>
      </div>

      {/* --- Top-up Modal --- */}
      <Modal show={showTopupModal} onClose={handleCloseModal} title="Top Up Wallet">
        <form onSubmit={handleTopupSubmit}>
          {topupMsg && (
            <div className={`alert alert-${topupMsg.type} py-2`} role="alert">
              {topupMsg.text}
            </div>
          )}
          <div className="mb-3">
            <label htmlFor="topupAmount" className="form-label">Amount</label>
            <div className="input-group">
              <span className="input-group-text">$</span>
              <input
                type="number"
                id="topupAmount"
                className="form-control"
                placeholder="0.00"
                min="0.01"
                step="0.01"
                value={topupAmount}
                onChange={(e) => setTopupAmount(e.target.value)}
                required
                autoFocus
              />
            </div>
            <div className="form-text">No limit — enter any amount.</div>
          </div>
          <div className="mb-3">
            <label htmlFor="topupNarration" className="form-label">Narration (optional)</label>
            <input
              type="text"
              id="topupNarration"
              className="form-control"
              placeholder="e.g. July top-up"
              value={topupNarration}
              onChange={(e) => setTopupNarration(e.target.value)}
              maxLength={200}
            />
          </div>
          <div className="d-flex justify-content-end gap-2">
            <button type="button" className="btn btn-outline-secondary" onClick={handleCloseModal}>
              Cancel
            </button>
            <button type="submit" className="btn btn-primary" disabled={topupSubmitting}>
              {topupSubmitting ? (
                <>
                  <span className="spinner-border spinner-border-sm me-1" aria-hidden="true" />
                  Processing...
                </>
              ) : (
                <>Confirm Top-up</>
              )}
            </button>
          </div>
        </form>
      </Modal>
    </MeridianPage>
  );
}
