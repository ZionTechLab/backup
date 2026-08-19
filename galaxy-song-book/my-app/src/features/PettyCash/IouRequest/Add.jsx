import { useEffect, useState, useMemo } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import * as Yup from 'yup';
import { useFormikBuilder, FieldsRenderer } from '../../../helpers/formikBuilder';
import { todayISO } from '../../../helpers/transformDateFields';
import STATUS_CLASS from '../../../helpers/statusBadge';
import MessageBoxService from '../../../services/MessageBoxService';
import PermissionGate from '../../../components/PermissionGate';
import MeridianPage from '../../Meridian/MeridianPage';
import DocumentUploader from '../../../components/DocumentUploader';
import Modal from '../../../components/Modal';
import config from '../../../config/config';
import ApiService from './service';
import ApprovalHistory from '../../Workflow/MyApprovals/ApprovalHistory';
import IouRequisitionPrintView from './IouRequisitionPrintView';
import transformDateFields from "../../../helpers/transformDateFields";
import useMenuLabel from '../../../helpers/useMenuLabel';

const HISTORY_CLOSED = { open: false, docNo: '' };

const EMPTY_VALUES = {
  partyType: '', partyId: '', requestAmount: '',
  expectedSettlementDate: todayISO(new Date(Date.now() + 7 * 24 * 60 * 60 * 1000)),
  jobPoRef: '', purpose: '', remarks: '',
  branchOrgUnitId: '', departmentOrgUnitId: '', sectionOrgUnitId: '',
  currencyCode: '', requestDate: todayISO(),
};

export default function AddIouRequest() {
  const { id } = useParams();
  const navigate = useNavigate();
  const menuLabel = useMenuLabel('/petty-cash/iou-request', 'IOU Request');
  const [status, setStatus] = useState(null);
  const [history, setHistory] = useState(HISTORY_CLOSED);
  const [showPreview, setShowPreview] = useState(false);
  const [docNo, setDocNo] = useState('');
  const [docs, setDocs] = useState([]);
  const [uiData, setUiData] = useState({loading: false, success: false, error: '', data: {} });
  const [allOrgUnits, setAllOrgUnits] = useState({ branches: [], departments: [], sections: [] });
  const [uiDataFiltered, setuiDataFiltered] = useState({ parties: [], partyTypes: [], branches: [], departments: [], sections: [], currencies: [] });

  const fields = useMemo(() => ({   
     requestDate: {
      name: 'requestDate', type: 'date', placeholder: 'Request Date',
      initialValue: '', className: 'col-sm-2',
    },    
    expectedSettlementDate: {
      name: 'expectedSettlementDate', type: 'date', placeholder: 'Expected Settlement',
      initialValue: todayISO(new Date(Date.now() + 7 * 24 * 60 * 60 * 1000)),
      className: 'col-sm-2',
    },
    partyType: {
      name: 'partyType', type: 'select', placeholder: 'Party Type', initialValue: '',
      dataBinding: { data: uiData.partyTypes, keyField: 'value', valueField: 'label' },
      validation: Yup.string().required('Party type is required'), className: 'col-sm-4',
    },
    partyId: {
      name: 'partyId', type: 'select', placeholder: 'Party', initialValue: '',
      dataBinding: { data: uiData.parties, keyField: 'businessPartnerId', valueField: 'partnerName' },
      validation: Yup.string().required('Party is required'), className: 'col-sm-4',
    },
    branchOrgUnitId: {
      name: 'branchOrgUnitId', type: 'select', placeholder: 'Branch', initialValue: '',
      dataBinding: { data: uiData.branches, keyField: 'orgUnitId', valueField: 'name' }, className: 'col-sm-4',
    },
    departmentOrgUnitId: {
      name: 'departmentOrgUnitId', type: 'select', placeholder: 'Department', initialValue: '',
      dataBinding: { data: uiData.departments, keyField: 'orgUnitId', valueField: 'name' }, className: 'col-sm-4',
    },
    sectionOrgUnitId: {
      name: 'sectionOrgUnitId', type: 'select', placeholder: 'Section', initialValue: '',
      dataBinding: { data: uiData.sections, keyField: 'orgUnitId', valueField: 'name' }, className: 'col-sm-4',
    },

    x: {
      type: 'br'
    },
     jobPoRef: {
      name: 'jobPoRef', type: 'text', placeholder: 'Job / PO Ref', initialValue: '',
      className: 'col-sm-7',
    },    requestAmount: {
      name: 'requestAmount', type: 'amount', placeholder: 'Request Amount', initialValue: '',
      validation: Yup.number().required('Amount is required').moreThan(0, 'Must be greater than zero'),
      className: 'col-sm-3',
    },
    currencyCode: {
      name: 'currencyCode', type: 'select', placeholder: 'Currency', initialValue: '',
      dataBinding: { data: uiData.currencies, keyField: 'currencyCode', valueField: 'currencyCode' },
      validation: Yup.string().required('Currency is required'), className: 'col-sm-2',
    },
    purpose: {
      name: 'purpose', type: 'textarea', placeholder: 'Purpose', initialValue: '',
      className: 'col-12',
    },
    remarks: {
      name: 'remarks', type: 'textarea', placeholder: 'Remarks', initialValue: '',
      className: 'col-12',
    },

  }), [uiData]);

  async function handleSubmit(values) {
    const payload = {
      iouRequestId: id || null,
      isUpdate: !!id,
      partyType: values.partyType,
      partyId: values.partyId,
      branchOrgUnitId: values.branchOrgUnitId || null,
      departmentOrgUnitId: values.departmentOrgUnitId || null,
      sectionOrgUnitId: values.sectionOrgUnitId || null,
      requestAmount: values.requestAmount,
      currencyCode: values.currencyCode,
      expectedSettlementDate: values.expectedSettlementDate || null,
      jobPoRef: values.jobPoRef || null,
      purpose: values.purpose || null,
      remarks: values.remarks || null,
      docs,
    };
    const { success, data } = await ApiService.update(payload);
    if (success) {
      MessageBoxService.show({
        message: 'IOU Request saved.',
        type: 'success',
        onClose: () => {
          // config.features.returnToListAfterSave controls post-save navigation.
          // true: go to the list. false: stay; on create open the new record.
          if (config.features.returnToListAfterSave) {
            navigate('/petty-cash/iou-request');
          } else if (!id && data?.iouRequestId) {
            navigate(`/petty-cash/iou-request/edit/${data.iouRequestId}`);
          }
        },
      });
    }
  }

  const formik = useFormikBuilder(fields, handleSubmit);

   const fetchUi = async () => {
      setUiData(prev => ({ ...prev, loading: true, error: '' }));
      const res = await ApiService.getUi();
      const branches = res.data.branches || [];
      const departments = res.data.departments || [];
      const sections = res.data.sections || [];
      const parties = res.data.parties || [];
      const partyTypes = res.data.partyTypes || [];
      const currencies = res.data.currencies || [];
      setUiData(prev => ({ ...prev, parties, partyTypes, branches, departments, sections, currencies, loading: false }));
      setAllOrgUnits({ branches, departments, sections });
      setuiDataFiltered(prev => ({ ...prev, parties, partyTypes, branches, departments, sections, currencies }));
    };

  useEffect(() => {

fetchUi();

    if (id) {
      const fetchTxn = async () => {
        const response = await ApiService.get(id);
        if (response.success && response.data) {
          const data = { ...response.data };
          const normalized = transformDateFields(data, fields);
           
          formik.setValues({
            ...normalized,
          });
        }
      };
      fetchTxn();
    }


    const init = async () => {
      // const { success, data } = await ApiService.getUi();
      // setUiData({
      //   loading: false,
      //   parties: success ? data.parties || [] : [],
      //   partyTypes: success ? data.partyTypes || [] : [],
      //   branches: success ? data.branches || [] : [],
      //   departments: success ? data.departments || [] : [],
      //   sections: success ? data.sections || [] : [],
      //   currencies: success ? data.currencies || [] : [],
      // });
      if (id) {
        const res = await ApiService.get(id);
        if (res.success && res.data) {
          formik.setValues({
            partyType: res.data.partyType ?? '',
            partyId: res.data.partyId ?? '',
            branchOrgUnitId: res.data.branchOrgUnitId ?? '',
            departmentOrgUnitId: res.data.departmentOrgUnitId ?? '',
            sectionOrgUnitId: res.data.sectionOrgUnitId ?? '',
            requestAmount: res.data.requestAmount ?? '',
            currencyCode: res.data.currencyCode ?? '',
            expectedSettlementDate: (res.data.expectedSettlementDate || '').split('T')[0],
            jobPoRef: res.data.jobPoRef ?? '',
            purpose: res.data.purpose ?? '',
            remarks: res.data.remarks ?? '',
          });
          setStatus(res.data.status);
          setDocNo(`PREQ/${res.data.docNo}`);
          formik.setFieldValue('requestDate', (res.data.iouDate || '').split('T')[0]);
          setDocs(res.data.docs || []);
        }
      } else {
        formik.setFieldValue('requestDate', todayISO());
      }
    };
    init();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id]);

  // Cascade: filter departments by selected branch
  const watchedBranch = formik?.values?.branchOrgUnitId;
  useEffect(() => {
    if (!watchedBranch) {
      setuiDataFiltered((prev) => ({ ...prev, departments: allOrgUnits.departments }));
    } else {
      setuiDataFiltered((prev) => ({
        ...prev,
        departments: allOrgUnits.departments.filter((d) => d.parentId === watchedBranch),
      }));
    }
    formik?.setFieldValue?.('departmentOrgUnitId', '');
    formik?.setFieldValue?.('sectionOrgUnitId', '');
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [watchedBranch, allOrgUnits]);

  // Cascade: filter sections by selected department
  const watchedDept = formik?.values?.departmentOrgUnitId;
  useEffect(() => {
    if (!watchedDept) {
      setuiDataFiltered((prev) => ({ ...prev, sections: allOrgUnits.sections }));
    } else {
      setuiDataFiltered((prev) => ({
        ...prev,
        sections: allOrgUnits.sections.filter((s) => s.parentId === watchedDept),
      }));
    }
    formik?.setFieldValue?.('sectionOrgUnitId', '');
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [watchedDept, allOrgUnits]);

  const isDraft = !id || status === 'Draft';
  const canCancel = id && !['Cancelled', 'Settled', 'Closed'].includes(status);

  const fieldInputProps = useMemo(() => {
    const base = {
      requestDate: { disabled: true, readOnly: true },
    };
    if (isDraft) return base;
    return {
      ...base,
      purpose: { disabled: false, readOnly: true },
      remarks: { disabled: false, readOnly: true },
    };
  }, [isDraft]);

  const handleHistory = () => {
    if (history.open) { setHistory(HISTORY_CLOSED); return; }
    setHistory({ open: true, docNo: docNo || `PREQ/${id}` });
  };

  const handleClear = () => {
    formik.resetForm({ values: EMPTY_VALUES });
    setDocs([]);
  };

  const handleCancel = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Cancel this IOU Request?',
      type: 'danger',
      confirmText: 'Cancel Request',
      cancelText: 'Back',
    });
    if (!confirmed) return;
    const { success } = await ApiService.cancel(id);
    if (success) {
      MessageBoxService.show({
        message: 'IOU Request cancelled.',
        type: 'success',
        onClose: () => navigate('/petty-cash/iou-request'),
      });
    }
  };

  return (
    <MeridianPage
      title={`${id ? 'Edit' : 'New'} ${menuLabel}`}
      subtitle={docNo || null}
      backTo="/petty-cash/iou-request"
      cardClass="ml-form-card"
      actions={
        <>
          {id && (
            <button type="button" className="ml-btn-ghost" onClick={() => setShowPreview(true)}>
              <i className="bi bi-printer" aria-hidden="true" />
              Print
            </button>
          )}
          {canCancel && (
            <PermissionGate codes="iou-request-delete">
              <button type="button" className="ml-btn-ghost ml-btn-danger-ghost ml-fab-1" onClick={handleCancel}>
                <i className="bi bi-x-circle" aria-hidden="true" />
                Cancel
              </button>
            </PermissionGate>
          )}
          {isDraft && (
            <button type="button" className="ml-btn-ghost ml-fab-2" onClick={handleClear}>
              <i className="bi bi-eraser" aria-hidden="true" />
              Clear
            </button>
          )}
          {isDraft && (
            <PermissionGate codes="iou-request-save">
              <button type="submit" form="iou-request-form" className="ml-btn-action ml-fab"
                disabled={uiData.loading || formik.isSubmitting}>
                <i className="bi bi-check-lg" aria-hidden="true" />
                Save
              </button>
            </PermissionGate>
          )}
        </>
      }
    >
      <form id="iou-request-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="row g-2">
            <FieldsRenderer fields={fields} formik={formik} inputProps={{ disabled: !isDraft }} fieldInputProps={fieldInputProps} />
          </div>
        </div>
      </form>

      <div className="ml-form-section mt-3">
        <DocumentUploader value={docs} onChange={setDocs} readOnly={!isDraft} max={5} />
      </div>

      {id && status && (
        <div className="ml-form-section mt-3">
          <div className="d-flex align-items-center gap-2 mb-2">
            <span className="text-muted">Status:</span>
            <span className={`ml-badge ${STATUS_CLASS[status] || 'ml-badge-locked'}`}>{status}</span>
            <button type="button" className="btn btn-outline-secondary btn-sm btn-borderless ms-2" onClick={handleHistory}
              title="Approval history">
              <i className="bi bi-clock-history" />
            </button>
          </div>
        </div>
      )}

      {history.open && (
        <ApprovalHistory docType="PREQ" docId={id} label={history.docNo}
          onClose={() => setHistory(HISTORY_CLOSED)} />
      )}

      <Modal show={showPreview} onClose={() => setShowPreview(false)} title="IOU Requisition Preview">
        <IouRequisitionPrintView id={id} />
        <div className="mt-3 d-flex justify-content-end">
          <button className="btn btn-secondary me-2" onClick={() => setShowPreview(false)}>Close</button>
          <button className="btn btn-primary" onClick={() => window.print()}>Print</button>
        </div>
      </Modal>
    </MeridianPage>
  );
}
