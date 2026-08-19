import { useEffect, useState } from 'react';
import ApiService from './service';
import { formatDate } from '../../../helpers/transformDateFields';
import formatAmount from '../../../helpers/formatAmount';
import './IouRequisition.css';

// Static document-control footer for the physical PPS/PPE form this mirrors.
// Update these three values only when the paper form itself is revised.
const FORM_DATE_OF_ISSUE = '27.06.2026';
const FORM_DATE_OF_REVISION = '27.06.2026';
const FORM_VERSION = '01';

function approverFor(approval, levelNo) {
  const row = (approval || []).find((a) => a.levelNo === levelNo && a.action === 'Approve');
  return row ? { name: row.actorName || '', date: formatDate(row.actedAt) } : { name: '', date: '' };
}

export default function IouRequisitionPrintView({ id }) {
  const [data, setData] = useState(null);

  useEffect(() => {
    if (!id) return;
    ApiService.get(id).then((res) => {
      if (res.success && res.data) setData(res.data);
    });
  }, [id]);

  const hod = approverFor(data?.approval, 1);
  const management = approverFor(data?.approval, 2);

  return (
    <div className="iou-print-layout">
      <header className="iou-print-header">
        {/* Placeholder until PPS/PPE letterhead logo is supplied */}
        <img src="/brand/galaxy-logo.png" alt="" className="iou-logo" onError={(e) => { e.target.style.visibility = 'hidden'; }} />
        <h1>IOU REQUISITION FORM</h1>
      </header>

      <table className="iou-outer">
        <thead>
          <tr>
            <th>IOU REQUISITION</th>
            <th>IOU SETTLEMENT</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td className="iou-panel">
              <table className="iou-inner">
                <tbody>
                  <tr><td className="key">Date</td><td className="value">{formatDate(data?.iouDate)}</td></tr>
                  <tr><td className="key">Request Amount</td><td className="value">Rs. {formatAmount(data?.requestAmount)}</td></tr>
                  <tr><td className="key">Purpose</td><td className="value">{data?.purpose || ''}</td></tr>
                  <tr><td className="key">Department</td><td className="value">{data?.departmentName || ''}</td></tr>
                  <tr><td className="key">Requester's Name</td><td className="value">{data?.partyName || ''}</td></tr>
                  <tr><td className="key">Requester's sig.</td><td className="value blank" /></tr>
                </tbody>
              </table>
            </td>
            <td className="iou-panel">
              <table className="iou-inner">
                <tbody>
                  <tr><td className="key">Date</td><td className="value blank" /></tr>
                  <tr><td className="key">Amount Received</td><td className="value">Rs.</td></tr>
                  <tr><td className="key">Value of Total bills</td><td className="value">Rs.</td></tr>
                  <tr><td className="key">Balance Returned</td><td className="value">Rs.</td></tr>
                  <tr><td className="key">Balance Claimed</td><td className="value">Rs.</td></tr>
                </tbody>
              </table>
            </td>
          </tr>

          <tr>
            <td className="iou-panel">
              <table className="iou-signbox">
                <tbody>
                  <tr>
                    <td className="key">Approved By</td>
                    <td className="signhead">HOD</td>
                    <td className="signhead">Management</td>
                  </tr>
                  <tr><td className="key">Name:</td><td>{hod.name}</td><td>{management.name}</td></tr>
                  <tr><td className="key">Signature:</td><td className="blank" /><td className="blank" /></tr>
                  <tr><td className="key">Date:</td><td>{hod.date}</td><td>{management.date}</td></tr>
                </tbody>
              </table>
            </td>
            <td className="iou-panel">
              <table className="iou-signbox">
                <tbody>
                  <tr><td className="key" colSpan={2}>Settled By</td></tr>
                  <tr><td className="key">Name:</td><td className="blank" /></tr>
                  <tr><td className="key">Signature:</td><td className="blank" /></tr>
                  <tr><td className="key">Date:</td><td className="blank" /></tr>
                </tbody>
              </table>
            </td>
          </tr>

          <tr>
            <td className="iou-panel">
              <table className="iou-signbox">
                <tbody>
                  <tr><td className="key" colSpan={2}>Issued By (cashier)</td></tr>
                  <tr><td className="key">Name:</td><td className="blank" /></tr>
                  <tr><td className="key">Signature:</td><td className="blank" /></tr>
                  <tr><td className="key">Date:</td><td className="blank" /></tr>
                </tbody>
              </table>
            </td>
            <td className="iou-panel">
              <table className="iou-signbox">
                <tbody>
                  <tr><td className="key" colSpan={2}>Returned/Claimed By</td></tr>
                  <tr><td className="key">Name:</td><td className="blank" /></tr>
                  <tr><td className="key">Signature:</td><td className="blank" /></tr>
                  <tr><td className="key">Date:</td><td className="blank" /></tr>
                </tbody>
              </table>
            </td>
          </tr>

          <tr>
            <td className="iou-panel">
              <table className="iou-signbox">
                <tbody>
                  <tr><td className="key" colSpan={2}>Received By</td></tr>
                  <tr><td className="key">Name:</td><td className="blank" /></tr>
                  <tr><td className="key">Signature:</td><td className="blank" /></tr>
                  <tr><td className="key">Date:</td><td className="blank" /></tr>
                </tbody>
              </table>
            </td>
            <td className="iou-panel">
              <table className="iou-signbox">
                <tbody>
                  <tr><td className="key" colSpan={2}>Approved By</td></tr>
                  <tr><td className="key">Name:</td><td className="blank" /></tr>
                  <tr><td className="key">Signature:</td><td className="blank" /></tr>
                  <tr><td className="key">Date:</td><td className="blank" /></tr>
                </tbody>
              </table>
            </td>
          </tr>

          <tr>
            <td className="iou-footer" colSpan={2}>
              <span>Date of Issue: {FORM_DATE_OF_ISSUE}</span>
              <span>Date Of Revision: {FORM_DATE_OF_REVISION}</span>
              <span>Version: {FORM_VERSION}</span>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  );
}
