import { useState } from 'react';

export function useSaveState() {
  const [saving, setSaving] = useState(false);
  const [error, setError] = useState('');
  const [success, setSuccess] = useState('');

  const withSaveState = async (saveFn: () => Promise<void>) => {
    setSaving(true);
    setError('');
    setSuccess('');
    try {
      await saveFn();
      setSuccess('Saved.');
      setTimeout(() => setSuccess(''), 2500);
    } catch (e: any) {
      setError(e?.message ?? 'Failed to save.');
    } finally {
      setSaving(false);
    }
  };

  return { saving, error, success, setError, withSaveState };
}
