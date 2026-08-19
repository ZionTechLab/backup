import { useEffect, useState } from 'react';
import * as Yup from 'yup';
import { useFormikBuilder, FieldsRenderer } from '../../helpers/formikBuilder';import { nowDatetimeLocal } from "../../helpers/transformDateFields";import JobLogService from './jobLogService';
import MessageBoxService from '../../services/MessageBoxService';

// Inline log management for a Job
// Shows existing logs + form to add/update a single log record
const JobLogSection = ({ jobId }) => {
  const [logs, setLogs] = useState([]);
  const [editingId, setEditingId] = useState(null);
  const [loading, setLoading] = useState(false);

  const fields = {
    id: { name: 'id', type: 'text', initialValue: '<Auto>', disabled: true, visible: false },
    logDateTime: { name: 'logDateTime', type: 'datetime-local', initialValue: nowDatetimeLocal(), validation: Yup.string().required('Date/Time required'), className: 'col-sm-3 col-12' },
    userName: { name: 'userName', type: 'text', placeholder: 'User', initialValue: 'admin', validation: Yup.string().required('User required'), className: 'col-sm-2 col-12' },
    note: { name: 'note', type: 'text', placeholder: 'Note', initialValue: '', validation: Yup.string().required('Note required'), className: 'col-sm-3 col-12' },
    utilizedTime: { name: 'utilizedTime', type: 'number', placeholder: 'Time (min)', initialValue: 0, validation: Yup.number().min(0).required('Time required'), className: 'col-sm-2 col-6' },
    cost: { name: 'cost', type: 'amount', placeholder: 'Cost', initialValue: 0, className: 'col-sm-2 col-6' },
    remarks: { name: 'remarks', type: 'text', placeholder: 'Remarks', initialValue: '', className: 'col-12' },
  };

  const formik = useFormikBuilder(fields, async (values, { resetForm }) => {
    const payload = {
      header: {
        id: editingId || 0,
        jobId,
        logDateTime: values.logDateTime,
        userName: values.userName,
        note: values.note,
        utilizedTime: parseInt(values.utilizedTime || 0, 10),
        cost: Number(values.cost || 0),
        remarks: values.remarks,
      }
    };
    const res = await JobLogService.update(payload);
    if (res.success) {
      MessageBoxService.show({ message: 'Log saved', type: 'success' });
      resetForm();
      setEditingId(null);
      loadLogs();
    }
  });

  const loadLogs = async () => {
    setLoading(true);
    const res = await JobLogService.getAll(jobId);
    if (res.success) setLogs(res.data || []);
    setLoading(false);
  };

  useEffect(() => { if (jobId) loadLogs(); // eslint-disable-next-line
  }, [jobId]);

  const handleEdit = (log) => {
    setEditingId(log.id);
    formik.setValues({ ...formik.values, ...log });
  };

  const handleDelete = async (id) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Delete this log entry?',
      type: 'danger', confirmText: 'Delete', cancelText: 'Cancel'
    });
    if (!confirmed) return;
    const res = await JobLogService.delete({ id });
    if (res.success) {
      MessageBoxService.show({ message: 'Log deleted', type: 'success' });
      if (editingId === id) { setEditingId(null); }
      loadLogs();
    }
  };

  const handleCancel = () => {
    formik.resetForm();
    setEditingId(null);
  };

  const totalTime = logs.reduce((sum, l) => sum + (parseInt(l.utilizedTime || 0, 10)), 0);
  const totalCost = logs.reduce((sum, l) => sum + (Number(l.cost || 0)), 0);

  return (
    <div className="card mt-4">
      <div className="card-header d-flex justify-content-between align-items-center">
        <h6 className="mb-0">Job Logs</h6>
        <small className="text-muted">Time: {totalTime} min | Cost: {totalCost}</small>
      </div>
      <div className="card-body">
        {loading && <div className="text-muted">Loading logs...</div>}
        {!loading && logs.length === 0 && <div className="text-muted">No logs yet.</div>}
        {!loading && logs.length > 0 && (
          <div className="table-responsive mb-3">
            <table className="table table-sm align-middle">
              <thead>
                <tr>
                  <th className="col-w-120">Date/Time</th>
                  <th>User</th>
                  <th>Note</th>
                  <th className="text-end">Time (min)</th>
                  <th className="text-end">Cost</th>
                  <th>Remarks</th>
                  <th className="col-w-80">Actions</th>
                </tr>
              </thead>
              <tbody>
                {logs.map(l => (
                  <tr key={l.id} className={editingId === l.id ? 'table-warning' : ''}>
                    <td className="text-nowrap small">{(l.logDateTime||'').replace('T',' ').substring(0,16)}</td>
                    <td className="small">{l.userName}</td>
                    <td className="small text-truncate cell-mw-160" title={l.note}>{l.note}</td>
                    <td className="text-end small">{l.utilizedTime}</td>
                    <td className="text-end small">{l.cost}</td>
                    <td className="small text-truncate cell-mw-140" title={l.remarks}>{l.remarks}</td>
                    <td>
                      <div className="btn-group btn-group-sm">
                        <button type="button" aria-label="Edit" className="btn btn-outline-primary" onClick={() => handleEdit(l)} title="Edit"><i className="bi bi-pencil"></i></button>
                        <button type="button" aria-label="Delete" className="btn btn-outline-danger" onClick={() => handleDelete(l.id)} title="Delete"><i className="bi bi-trash"></i></button>
                      </div>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}

        <form onSubmit={formik.handleSubmit} className="row g-2">
          <FieldsRenderer fields={fields} formik={formik} inputProps={{ autoComplete: 'off' }} />
          <div className="d-flex justify-content-end gap-2 mt-2">
            {editingId && <button type="button" className="btn btn-secondary" onClick={handleCancel}>Cancel</button>}
            <button type="submit" className="btn btn-primary">{editingId ? 'Update Log' : 'Add Log'}</button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default JobLogSection;
