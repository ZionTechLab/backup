import { useState } from 'react';
import MessageBoxService from '../../services/MessageBoxService';

function APISettings() {
  const [webhookUrl, setWebhookUrl] = useState('https://api.galaxy.lk/webhooks/id-events');
  const [saving, setSaving] = useState(false);

  const apiKeys = [
    {
      id: 1,
      type: 'Production Key',
      key: 'galaxy_live_pk_xxxxxxxxxxxxxxxxx8f2a',
      created: '2025-08-15',
    },
    {
      id: 2,
      type: 'Development Key',
      key: 'galaxy_dev_sk_xxxxxxxxxxxxxxxxxxxxx3b9d',
      created: '2025-09-01',
    },
  ];

  const handleCopyKey = (key) => {
    navigator.clipboard.writeText(key);
    MessageBoxService.show({ message: 'Key copied to clipboard', type: 'success' });
  };

  const handleRevokeKey = async (keyId, keyType) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: `Revoke ${keyType}? This cannot be undone.`,
      type: 'danger',
      confirmText: 'Revoke',
      cancelText: 'Cancel',
    });
    if (confirmed) {
      MessageBoxService.show({ message: `${keyType} revoked successfully`, type: 'success' });
    }
  };

  const handleSaveWebhook = async () => {
    setSaving(true);
    try {
      await new Promise((resolve) => setTimeout(resolve, 500));
      MessageBoxService.show({ message: 'Webhook URL saved successfully', type: 'success' });
    } catch (err) {
      MessageBoxService.show({ message: 'Failed to save webhook URL', type: 'danger' });
    } finally {
      setSaving(false);
    }
  };

  return (
    <div className="container-fluid p-4">
      <h4 className="mb-4">API Settings</h4>
      <p className="text-muted mb-4">Manage API keys and integrations</p>

      <div className="row g-4">
        {/* API Keys Card */}
        <div className="col-12">
          <div className="card">
            <div className="card-body">
              <h5 className="card-title mb-4">
                <i className="bi bi-key me-2" />
                API Keys
              </h5>

              <div className="space-y-3">
                {apiKeys.map((key) => (
                  <div
                    key={key.id}
                    className="p-3 border rounded d-flex justify-content-between align-items-center gap-3"
                  >
                    <div className="overflow-hidden">
                      <div className="fw-semibold">{key.type}</div>
                      <div className="text-muted small font-monospace text-break">{key.key}</div>
                      <div className="text-muted small">Created {key.created}</div>
                    </div>
                    <div className="d-flex gap-2 flex-shrink-0">
                      <button
                        className="btn btn-sm btn-outline-primary"
                        onClick={() => handleCopyKey(key.key)}
                        title="Copy"
                      >
                        <i className="bi bi-clipboard" />
                      </button>
                      <button
                        className="btn btn-sm btn-danger"
                        onClick={() => handleRevokeKey(key.id, key.type)}
                        title="Revoke"
                      >
                        <i className="bi bi-trash" />
                      </button>
                    </div>
                  </div>
                ))}
              </div>

              <button className="btn btn-primary mt-3">
                <i className="bi bi-plus me-1" />
                Generate New Key
              </button>
            </div>
          </div>
        </div>

        {/* Webhook Endpoints Card */}
        <div className="col-12">
          <div className="card">
            <div className="card-body">
              <h5 className="card-title mb-3">Webhook Endpoints</h5>

              <div className="mb-3">
                <label htmlFor="webhookUrl" className="form-label">
                  WEBHOOK URL
                </label>
                <input
                  id="webhookUrl"
                  type="url"
                  className="form-control"
                  value={webhookUrl}
                  onChange={(e) => setWebhookUrl(e.target.value)}
                  placeholder="https://api.example.com/webhooks/events"
                />
              </div>

              <button
                className="btn btn-primary"
                onClick={handleSaveWebhook}
                disabled={saving}
              >
                {saving ? (
                  <>
                    <span className="spinner-border spinner-border-sm me-1" aria-hidden="true" />
                    Saving...
                  </>
                ) : (
                  'Save Webhook'
                )}
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default APISettings;
