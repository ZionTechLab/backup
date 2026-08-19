import React, { useEffect, useState } from 'react';
import { TimeEntry, TimeEntryFormValues } from '../models/TimeEntry';
import * as TaskTypeService from '../services/TaskTypeService';

interface Props {
  initial?: TimeEntry;
  onSave: (values: TimeEntryFormValues) => Promise<void>;
  onCancel: () => void;
}

function today(): string {
  return new Date().toISOString().slice(0, 10);
}

export function TimeEntryForm({ initial, onSave, onCancel }: Props) {
  const [values, setValues] = useState<TimeEntryFormValues>({
    date: initial?.date ?? today(),
    hours: initial ? String(initial.hours) : '',
    taskType: initial?.taskType ?? '',
    notes: initial?.notes ?? '',
  });
  const [taskTypes, setTaskTypes] = useState<string[]>([]);
  const [error, setError] = useState('');
  const [saving, setSaving] = useState(false);

  useEffect(() => {
    TaskTypeService.getTaskTypes().then(setTaskTypes).catch(() => setTaskTypes([]));
  }, []);

  function set(field: keyof TimeEntryFormValues, value: string) {
    setValues(v => ({ ...v, [field]: value }));
  }

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault();
    setError('');

    if (!values.date) {
      setError('Date is required.');
      return;
    }
    const hours = parseFloat(values.hours);
    if (isNaN(hours) || hours <= 0) {
      setError('Hours must be a positive number.');
      return;
    }

    setSaving(true);
    try {
      await onSave(values);
    } catch (e: any) {
      setError(e?.message ?? 'Failed to save. Please try again.');
    } finally {
      setSaving(false);
    }
  }

  return (
    <form className="entry-form" onSubmit={handleSubmit} noValidate>
      <div className="form-row">
        <div className="form-field">
          <label htmlFor="tt-date">Date</label>
          <input
            id="tt-date"
            type="date"
            value={values.date}
            onChange={e => set('date', e.target.value)}
            disabled={saving}
            required
          />
        </div>

        <div className="form-field form-field--narrow">
          <label htmlFor="tt-hours">Hours</label>
          <input
            id="tt-hours"
            type="number"
            min="0.1"
            step="0.25"
            placeholder="0.00"
            value={values.hours}
            onChange={e => set('hours', e.target.value)}
            disabled={saving}
            required
          />
        </div>

        <div className="form-field form-field--medium">
          <label htmlFor="tt-type">Task Type</label>
          <select
            id="tt-type"
            value={values.taskType}
            onChange={e => set('taskType', e.target.value)}
            disabled={saving}
          >
            <option value="">— Select type —</option>
            {taskTypes.map(t => (
              <option key={t} value={t}>{t}</option>
            ))}
          </select>
        </div>

        <div className="form-field form-field--grow">
          <label htmlFor="tt-notes">Notes (optional)</label>
          <input
            id="tt-notes"
            type="text"
            placeholder="Brief description…"
            value={values.notes}
            onChange={e => set('notes', e.target.value)}
            disabled={saving}
          />
        </div>

        <div className="form-field form-field--actions">
          <label>&nbsp;</label>
          <div className="form-buttons">
            <button type="submit" className="btn btn-primary" disabled={saving}>
              {saving ? 'Saving…' : 'Save'}
            </button>
            <button type="button" className="btn btn-secondary" onClick={onCancel} disabled={saving}>
              Cancel
            </button>
          </div>
        </div>
      </div>
      {error && <p className="form-error">{error}</p>}
    </form>
  );
}
