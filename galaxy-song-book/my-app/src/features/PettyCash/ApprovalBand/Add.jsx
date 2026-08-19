import * as Yup from 'yup';
import { useParams, useNavigate } from 'react-router-dom';
import { useEffect, useState } from 'react';
import InputField from '../../../components/InputField';
import { useFormikBuilder } from '../../../helpers/formikBuilder';
import ApiService from './service';
import MessageBoxService from '../../../services/MessageBoxService';
import PermissionGate from '../../../components/PermissionGate';
import MeridianPage from '../../Meridian/MeridianPage';
import useMenuLabel from '../../../helpers/useMenuLabel';

import config from '../../../config/config';

export default function AddApprovalBand() {
  const { id } = useParams();
  const navigate = useNavigate();
  const menuLabel = useMenuLabel('/petty-cash/approval-band', 'Approval Band');
  const [uiData, setUiData] = useState({ loading: true, docTypes: [], functions: [] });

  const fields = {
    docType: {
      name: 'docType', type: 'select', placeholder: 'Doc Type', initialValue: '',
      dataBinding: { data: uiData.docTypes, keyField: 'value', valueField: 'label' },
      validation: Yup.string().required('Doc type is required'), className: 'col-sm-6',
    },
    minAmount: {
      name: 'minAmount', type: 'amount', placeholder: 'Min Amount', initialValue: 0,
      validation: Yup.number().required('Min amount is required').min(0), className: 'col-sm-6',
    },
    maxAmount: {
      name: 'maxAmount', type: 'amount', placeholder: 'Max Amount (optional)', initialValue: null, className: 'col-sm-6',
    },
    approverFunction: {
      name: 'approverFunction', type: 'select', placeholder: 'Approver Function', initialValue: '',
      dataBinding: { data: uiData.functions, keyField: 'value', valueField: 'label' },
      validation: Yup.string().required('Approver function is required'), className: 'col-sm-6',
    },
    sortOrder: {
      name: 'sortOrder', type: 'number', placeholder: 'Sort Order', initialValue: 0,
      validation: Yup.number().required('Sort order is required').integer().min(0), className: 'col-sm-6',
    },
  };

  useEffect(() => {
    const init = async () => {
      const { success, data } = await ApiService.getUi();
      const mapToOptions = (arr) => (arr || []).map((v) => ({ value: v, label: v }));
      setUiData({
        loading: false,
        docTypes: success ? mapToOptions(data.docTypes) : [],
        functions: success ? mapToOptions(data.functions) : [],
      });
      if (id) {
        const res = await ApiService.get(id);
        if (res.success && res.data) formik.setValues({ ...res.data });
      }
    };
    init();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id]);

  const handleSubmit = async (values, { resetForm }) => {
    const { success, data } = await ApiService.update({
      ...values,
      bandId: id || null,
      isUpdate: !!id,
    });
    if (success) {
      MessageBoxService.show({
        message: 'Approval band saved successfully!',
        type: 'success',
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate('/petty-cash/approval-band');
          } else if (!id && data?.bandId) {
            navigate(`/petty-cash/approval-band/edit/${data.bandId}`);
          } else if (!id) {
            resetForm();
          }
        },
      });
    }
  };

  const handleDelete = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Delete this approval band?',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await ApiService.delete({ id });
    if (success) {
      MessageBoxService.show({
        message: 'Approval band deleted.',
        type: 'success',
        onClose: () => navigate('/petty-cash/approval-band'),
      });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  return (
    <MeridianPage
      title={`${id ? 'Edit' : 'New'} ${menuLabel}`}
      backTo="/petty-cash/approval-band"
      cardClass="ml-form-card"
      actions={
        <>
          {id && (
            <PermissionGate codes="pc-approval-band-delete">
              <button type="button" className="ml-btn-ghost ml-btn-danger-ghost ml-fab-1" onClick={handleDelete}>
                <i className="bi bi-trash" aria-hidden="true" />
                Delete
              </button>
            </PermissionGate>
          )}
          <PermissionGate codes={id ? 'pc-approval-band-update' : 'pc-approval-band-save'}>
            <button type="submit" form="approval-band-form" className="ml-btn-action ml-fab" disabled={uiData.loading}>
              <i className="bi bi-check-lg" aria-hidden="true" />
              Save
            </button>
          </PermissionGate>
        </>
      }
    >
      <form id="approval-band-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="row g-2">
            <InputField {...fields.docType} formik={formik} />
            <InputField {...fields.minAmount} formik={formik} />
            <InputField {...fields.maxAmount} formik={formik} />
            <InputField {...fields.approverFunction} formik={formik} />
            <InputField {...fields.sortOrder} formik={formik} />
          </div>
        </div>
      </form>
    </MeridianPage>
  );
}
