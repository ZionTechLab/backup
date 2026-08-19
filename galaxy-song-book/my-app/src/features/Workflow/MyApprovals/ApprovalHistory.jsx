import { useEffect, useState } from 'react';
import WorkflowService from '../service';
import { formatDateTime } from '../../../helpers/transformDateFields';

export default function ApprovalHistory({ docType, docId, label, onClose }) {
  const [loading, setLoading] = useState(true);
  const [rows, setRows] = useState([]);

  useEffect(() => {
    let cancelled = false;
    (async () => {
      setLoading(true);
      const { success, data } = await WorkflowService.getDoc(docType, docId);
      if (!cancelled) {
        setRows(success && data ? (data.history || []) : []);
        setLoading(false);
      }
    })();
    return () => { cancelled = true; };
  }, [docType, docId]);

  return (
    <div className="ml-form-section mt-3">
      <div className="d-flex justify-content-between align-items-center mb-2">
        <h6 className="mb-0">Approval history: {label}</h6>
        <button type="button" className="btn-close" aria-label="Close" onClick={onClose} />
      </div>
      {loading ? (
        <div className="text-muted">Loading...</div>
      ) : rows.length ? (
        <table className="table table-sm mb-0">
          <thead>
            <tr><th>Level</th><th>Action</th><th>By</th><th>Comment</th><th>When</th></tr>
          </thead>
          <tbody>
            {rows.map((h, i) => (
              <tr key={i}>
                <td>{h.levelNo}</td>
                <td>{h.action}</td>
                <td>{h.actorName || '-'}</td>
                <td>{h.comment || '-'}</td>
                <td>{h.actedAt ? formatDateTime(h.actedAt) : '-'}</td>
              </tr>
            ))}
          </tbody>
        </table>
      ) : (
        <div className="text-muted">No history yet.</div>
      )}
    </div>
  );
}
