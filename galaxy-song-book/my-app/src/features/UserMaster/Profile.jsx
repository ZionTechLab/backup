import { useState } from 'react';
import { useSelector } from 'react-redux';
import { selectUser } from '../auth';
import AuthService from '../auth/authService';

function Profile() {
  const user = useSelector(selectUser);
  const [pwForm, setPwForm] = useState({ current: '', newPw: '', confirm: '' });
  const [pwMsg, setPwMsg] = useState(null);
  const [pwLoading, setPwLoading] = useState(false);
  const [visible, setVisible] = useState({ current: false, newPw: false, confirm: false });

  const toggleVisible = (field) => setVisible((v) => ({ ...v, [field]: !v[field] }));

  // PIN 2FA state (local — no backend yet)
  const [hasPin, setHasPin] = useState(false);
  const [pinPassword, setPinPassword] = useState('');
  const [pinValue, setPinValue] = useState('');
  const [pinVisible, setPinVisible] = useState(false);
  const [pinMsg, setPinMsg] = useState(null);
  const [pinLoading, setPinLoading] = useState(false);

  const handlePinSubmit = (e) => {
    e.preventDefault();
    setPinMsg(null);
    if (!pinPassword) {
      setPinMsg({ type: 'danger', text: 'Current password is required.' });
      return;
    }
    if (!/^[A-Za-z0-9]{6}$/.test(pinValue)) {
      setPinMsg({ type: 'danger', text: 'PIN must be exactly 6 alphanumeric characters.' });
      return;
    }
    setPinLoading(true);
    // POST /auth/set-pin would go here once backend is ready
    setTimeout(() => {
      setPinMsg({ type: 'success', text: 'PIN set successfully.' });
      setHasPin(true);
      setPinPassword('');
      setPinValue('');
      setPinLoading(false);
    }, 500);
  };

  const handleRemovePin = () => {
    setPinMsg(null);
    setPinLoading(true);
    // POST /auth/remove-pin would go here once backend is ready
    setTimeout(() => {
      setPinMsg({ type: 'success', text: 'PIN removed.' });
      setHasPin(false);
      setPinPassword('');
      setPinValue('');
      setPinLoading(false);
    }, 500);
  };

  const handleChangePassword = async (e) => {
    e.preventDefault();
    setPwMsg(null);
    if (pwForm.newPw !== pwForm.confirm) {
      setPwMsg({ type: 'danger', text: 'New passwords do not match.' });
      return;
    }
    if (pwForm.newPw.length < 6) {
      setPwMsg({ type: 'danger', text: 'Password must be at least 6 characters.' });
      return;
    }
    setPwLoading(true);
    try {
      const res = await AuthService.changePassword({
        currentPassword: pwForm.current,
        newPassword: pwForm.newPw,
      });
      if (res && res.success) {
        setPwMsg({ type: 'success', text: 'Password changed successfully.' });
        setPwForm({ current: '', newPw: '', confirm: '' });
      } else {
        setPwMsg({ type: 'danger', text: res?.error || 'Failed to change password.' });
      }
    } catch (err) {
      setPwMsg({ type: 'danger', text: err?.response?.data?.error || err?.message || 'Something went wrong.' });
    } finally {
      setPwLoading(false);
    }
  };

  const infoRows = [
    { label: 'Full Name', value: user?.fullName || user?.name || '—' },
    { label: 'Username', value: user?.userName || '—' },
    { label: 'Email', value: user?.email || '—' },
    { label: 'Phone', value: user?.phone || '—' },
    { label: 'Role', value: user?.roleName || user?.roleId || '—' },
    { label: 'Department', value: user?.department || '—' },
    { label: 'Employee ID', value: user?.employeeId || '—' },
    { label: 'Hire Date', value: user?.hireDate || '—' },
  ];

  return (
    <div className="container-fluid p-4">
      <h4 className="mb-4">Profile</h4>

      <div className="row g-4">
        {/* User Details Card */}
        <div className="col-12 col-lg-5">
          <div className="card h-100">
            <div className="card-body">
              <h5 className="card-title mb-3">Account Details</h5>
              <table className="table table-borderless mb-0">
                <tbody>
                  {infoRows.map((row) => (
                    <tr key={row.label}>
                      <td className="text-muted ps-0" style={{ width: '120px' }}>{row.label}</td>
                      <td className="pe-0">{row.value}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>
        </div>

        {/* Change Password Card */}
        <div className="col-12 col-lg-7">
          <div className="card h-100">
            <div className="card-body">
              <h5 className="card-title mb-3">Change Password</h5>
              <form onSubmit={handleChangePassword}>
                {pwMsg && (
                  <div className={`alert alert-${pwMsg.type} py-2`} role="alert">
                    {pwMsg.text}
                  </div>
                )}
                <div className="mb-3">
                  <label htmlFor="currentPassword" className="form-label">Current Password</label>
                  <div className="input-group">
                    <input
                      type={visible.current ? 'text' : 'password'}
                      id="currentPassword"
                      className="form-control"
                      value={pwForm.current}
                      onChange={(e) => setPwForm((p) => ({ ...p, current: e.target.value }))}
                      required
                      autoComplete="current-password"
                    />
                    <button
                      type="button" className="btn btn-outline-secondary"
                      onClick={() => toggleVisible('current')}
                      tabIndex={-1} aria-label={visible.current ? 'Hide password' : 'Show password'}
                    >
                      <i className={`bi ${visible.current ? 'bi-eye-slash' : 'bi-eye'}`} />
                    </button>
                  </div>
                </div>
                <div className="mb-3">
                  <label htmlFor="newPassword" className="form-label">New Password</label>
                  <div className="input-group">
                    <input
                      type={visible.newPw ? 'text' : 'password'}
                      id="newPassword"
                      className="form-control"
                      value={pwForm.newPw}
                      onChange={(e) => setPwForm((p) => ({ ...p, newPw: e.target.value }))}
                      required
                      minLength={6}
                      autoComplete="new-password"
                    />
                    <button
                      type="button" className="btn btn-outline-secondary"
                      onClick={() => toggleVisible('newPw')}
                      tabIndex={-1} aria-label={visible.newPw ? 'Hide password' : 'Show password'}
                    >
                      <i className={`bi ${visible.newPw ? 'bi-eye-slash' : 'bi-eye'}`} />
                    </button>
                  </div>
                </div>
                <div className="mb-3">
                  <label htmlFor="confirmPassword" className="form-label">Confirm New Password</label>
                  <div className="input-group">
                    <input
                      type={visible.confirm ? 'text' : 'password'}
                      id="confirmPassword"
                      className="form-control"
                      value={pwForm.confirm}
                      onChange={(e) => setPwForm((p) => ({ ...p, confirm: e.target.value }))}
                      required
                      minLength={6}
                      autoComplete="new-password"
                    />
                    <button
                      type="button" className="btn btn-outline-secondary"
                      onClick={() => toggleVisible('confirm')}
                      tabIndex={-1} aria-label={visible.confirm ? 'Hide password' : 'Show password'}
                    >
                      <i className={`bi ${visible.confirm ? 'bi-eye-slash' : 'bi-eye'}`} />
                    </button>
                  </div>
                </div>
                <button type="submit" className="btn btn-primary" disabled={pwLoading}>
                  {pwLoading ? (
                    <>
                      <span className="spinner-border spinner-border-sm me-1" aria-hidden="true" />
                      Changing...
                    </>
                  ) : (
                    'Change Password'
                  )}
                </button>
              </form>
            </div>
          </div>
        </div>
      </div>

      {/* PIN Security (2FA) Card */}
      <div className="row g-4 mt-2">
        <div className="col-12">
          <div className="card">
            <div className="card-body">
              <h5 className="card-title mb-3">
                <i className="bi bi-shield-lock me-2" />
                PIN Security (2FA)
              </h5>

              {pinMsg && (
                <div className={`alert alert-${pinMsg.type} py-2`} role="alert">
                  {pinMsg.text}
                </div>
              )}

              <div className="d-flex align-items-center justify-content-between p-3 border rounded bg-light mb-3">
                <div>
                  <div className="fw-semibold">Login PIN</div>
                  <div className="text-muted small">
                    {hasPin ? '6-character alphanumeric PIN is active' : 'Not configured'}
                  </div>
                </div>
                <div>
                  <span className={`badge ${hasPin ? 'bg-success' : 'bg-secondary'}`}>
                    {hasPin ? 'Active' : 'Inactive'}
                  </span>
                </div>
              </div>

              {hasPin ? (
                /* Change / Remove PIN */
                <form onSubmit={handlePinSubmit}>
                  <div className="row g-3 align-items-end">
                    <div className="col-md-5">
                      <label htmlFor="pinPassword" className="form-label">Current Password</label>
                      <input
                        type="password"
                        id="pinPassword"
                        className="form-control"
                        value={pinPassword}
                        onChange={(e) => setPinPassword(e.target.value)}
                        required
                        autoComplete="current-password"
                        placeholder="Enter current password"
                      />
                    </div>
                    <div className="col-md-5">
                      <label htmlFor="newPin" className="form-label">New PIN</label>
                      <div className="input-group">
                        <input
                          type={pinVisible ? 'text' : 'password'}
                          id="newPin"
                          className="form-control"
                          placeholder="6 alphanumeric chars"
                          maxLength={6}
                          value={pinValue}
                          onChange={(e) => setPinValue(e.target.value.toUpperCase())}
                          autoComplete="off"
                        />
                        <button
                          type="button" className="btn btn-outline-secondary"
                          onClick={() => setPinVisible((v) => !v)}
                          tabIndex={-1} aria-label={pinVisible ? 'Hide PIN' : 'Show PIN'}
                        >
                          <i className={`bi ${pinVisible ? 'bi-eye-slash' : 'bi-eye'}`} />
                        </button>
                      </div>
                    </div>
                    <div className="col-md-2 d-flex gap-2">
                      <button type="submit" className="btn btn-primary" disabled={pinLoading}>
                        {pinLoading ? 'Saving...' : 'Change'}
                      </button>
                      <button type="button" className="btn btn-outline-danger" onClick={handleRemovePin} disabled={pinLoading}>
                        Remove
                      </button>
                    </div>
                  </div>
                </form>
              ) : (
                /* Set PIN */
                <form onSubmit={handlePinSubmit}>
                  <div className="row g-3 align-items-end">
                    <div className="col-md-5">
                      <label htmlFor="pinPassword" className="form-label">Current Password</label>
                      <input
                        type="password"
                        id="pinPassword"
                        className="form-control"
                        value={pinPassword}
                        onChange={(e) => setPinPassword(e.target.value)}
                        required
                        autoComplete="current-password"
                        placeholder="Enter current password"
                      />
                    </div>
                    <div className="col-md-5">
                      <label htmlFor="newPin" className="form-label">Choose PIN</label>
                      <div className="input-group">
                        <input
                          type={pinVisible ? 'text' : 'password'}
                          id="newPin"
                          className="form-control"
                          placeholder="6 alphanumeric chars (e.g. A1B2C3)"
                          maxLength={6}
                          value={pinValue}
                          onChange={(e) => setPinValue(e.target.value.toUpperCase())}
                          autoComplete="off"
                        />
                        <button
                          type="button" className="btn btn-outline-secondary"
                          onClick={() => setPinVisible((v) => !v)}
                          tabIndex={-1} aria-label={pinVisible ? 'Hide PIN' : 'Show PIN'}
                        >
                          <i className={`bi ${pinVisible ? 'bi-eye-slash' : 'bi-eye'}`} />
                        </button>
                      </div>
                      <div className="form-text">Exactly 6 characters — letters A-Z and numbers 0-9.</div>
                    </div>
                    <div className="col-md-2">
                      <button type="submit" className="btn btn-primary" disabled={pinLoading}>
                        {pinLoading ? 'Saving...' : 'Set PIN'}
                      </button>
                    </div>
                  </div>
                </form>
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Profile;

