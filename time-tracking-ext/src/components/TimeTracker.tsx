import React, { useCallback, useEffect, useState } from 'react';
import * as SDK from 'azure-devops-extension-sdk';
import { IWorkItemFormService, WorkItemTrackingServiceIds } from 'azure-devops-extension-api/WorkItemTracking';
import { TimeEntry, TimeEntryFormValues, UserRef } from '../models/TimeEntry';
import * as TimeEntryService from '../services/TimeEntryService';
import { TimeEntryTable } from './TimeEntryTable';
import { TimeEntryForm } from './TimeEntryForm';
import { ConfirmDialog } from './ConfirmDialog';

interface Props {
  workItemId: number;
  isNew: boolean;
  currentUser: UserRef;
}

type FormMode = { kind: 'none' } | { kind: 'add' } | { kind: 'edit'; entry: TimeEntry };

export function TimeTracker({ workItemId, isNew, currentUser }: Props) {
  const [entries, setEntries] = useState<TimeEntry[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');
  const [formMode, setFormMode] = useState<FormMode>({ kind: 'none' });
  const [pendingDelete, setPendingDelete] = useState<TimeEntry | null>(null);
  const [deletebusy, setDeleteBusy] = useState(false);
  const [workItemContext, setWorkItemContext] = useState({ project: '', title: '' });

  const loadEntries = useCallback(async () => {
    if (isNew || workItemId === 0) {
      setLoading(false);
      return;
    }
    setLoading(true);
    setError('');
    try {
      const formService = await SDK.getService<IWorkItemFormService>(WorkItemTrackingServiceIds.WorkItemFormService);
      const [data, projectVal, titleVal] = await Promise.all([
        TimeEntryService.getActiveEntries(workItemId),
        formService.getFieldValue('System.TeamProject'),
        formService.getFieldValue('System.Title'),
      ]);
      setEntries(data);
      setWorkItemContext({
        project: String(projectVal ?? ''),
        title: String(titleVal ?? ''),
      });
    } catch (e: any) {
      setError(e?.message ?? 'Failed to load time entries.');
    } finally {
      setLoading(false);
    }
  }, [workItemId, isNew]);

  useEffect(() => {
    loadEntries();
  }, [loadEntries]);

  async function handleSave(values: TimeEntryFormValues) {
    const hours = parseFloat(values.hours);
    const payload = {
      date: values.date,
      hours,
      taskType: values.taskType,
      notes: values.notes,
      project: workItemContext.project,
      workItemTitle: workItemContext.title,
    };

    if (formMode.kind === 'add') {
      const created = await TimeEntryService.addEntry(workItemId, payload, currentUser);
      setEntries(prev => [...prev, created]);
    } else if (formMode.kind === 'edit') {
      const updated = await TimeEntryService.updateEntry(workItemId, formMode.entry.id, payload, currentUser);
      setEntries(prev => prev.map(e => (e.id === updated.id ? updated : e)));
    }
    setFormMode({ kind: 'none' });
  }

  async function handleDelete() {
    if (!pendingDelete) return;
    setDeleteBusy(true);
    try {
      await TimeEntryService.softDeleteEntry(workItemId, pendingDelete.id, currentUser);
      setEntries(prev => prev.filter(e => e.id !== pendingDelete.id));
      setPendingDelete(null);
    } catch (e: any) {
      setError(e?.message ?? 'Failed to delete entry.');
    } finally {
      setDeleteBusy(false);
    }
  }

  if (isNew || workItemId === 0) {
    return (
      <div className="tt-root">
        <p className="info-state">Save this work item before logging time.</p>
      </div>
    );
  }

  return (
    <div className="tt-root">
      {error && (
        <div className="error-banner" role="alert">
          {error}
          <button className="error-dismiss" onClick={() => setError('')} aria-label="Dismiss">×</button>
        </div>
      )}

      {loading ? (
        <div className="loading-state">Loading time entries…</div>
      ) : (
        <>
          <TimeEntryTable
            entries={entries}
            currentUserId={currentUser.id}
            onEdit={entry => setFormMode({ kind: 'edit', entry })}
            onDelete={entry => setPendingDelete(entry)}
          />

          {formMode.kind !== 'none' ? (
            <TimeEntryForm
              initial={formMode.kind === 'edit' ? formMode.entry : undefined}
              onSave={handleSave}
              onCancel={() => setFormMode({ kind: 'none' })}
            />
          ) : (
            <div className="toolbar">
              <button
                className="btn btn-primary"
                onClick={() => setFormMode({ kind: 'add' })}
              >
                + Log Time
              </button>
            </div>
          )}
        </>
      )}

      {pendingDelete && (
        <ConfirmDialog
          message={`Delete the ${pendingDelete.hours}h entry from ${pendingDelete.date}? This cannot be undone.`}
          onConfirm={handleDelete}
          onCancel={() => setPendingDelete(null)}
          busy={deletebusy}
        />
      )}
    </div>
  );
}
