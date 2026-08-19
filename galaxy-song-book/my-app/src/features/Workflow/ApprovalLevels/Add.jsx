import * as Yup from 'yup';
import { useParams, useNavigate } from 'react-router-dom';
import { useEffect, useState } from 'react';
import InputField from '../../../components/InputField';
import { useFormikBuilder } from '../../../helpers/formikBuilder';
import ApiService from '../service';
import MessageBoxService from '../../../services/MessageBoxService';
import MeridianPage from '../../Meridian/MeridianPage';

export default function AddApprovalLevel() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, docTypes: [], functions: [] });

  const fields = {
    docType: {
      name: 'docType', type: 'select', placeholder: 'Transaction', initialValue: '',
      dataBinding: { data: uiData.docTypes.map((d) => ({ code: d, name: d })), keyField: 'code', valueField: 'name' },
      validation: Yup.string().required('Transaction is required'), className: 'col-sm-6',
    },
    levelNo: {
      name: 'levelNo', type: 'number', placeholder: 'Level No', initialValue: 1,
      validation: Yup.number().min(1).required('Level number is required'), className: 'col-sm-6',
    },
    levelName: {
      name: 'levelName', type: 'text', placeholder: 'Level Name', initialValue: '',
      validation: Yup.string().required('Level name is required'), className: 'col-sm-6',
    },
    approverFunction: {
      name: 'approverFunction', type: 'select', placeholder: 'Approver Permission', initialValue: '',
      dataBinding: { data: uiData.functions, keyField: 'permCode', valueField: 'permName' },
      validation: Yup.string().required('Approver permission is required'), className: 'col-sm-6',
    },
    minAmount: {
      name: 'minAmount', type: 'amount', placeholder: 'Min Amount (optional)', initialValue: '', className: 'col-sm-6',
    },
    maxAmount: {
      name: 'maxAmount', type: 'amount', placeholder: 'Max Amount (optional)', initialValue: '', className: 'col-sm-6',
    },
    isActive: {
      name: 'isActive', type: 'switch', placeholder: 'Active', initialValue: true,
      validation: Yup.boolean(), className: 'col-sm-6',
    },
  };

  useEffect(() => {
    const init = async () => {
      const { success, data } = await ApiService.getOptions();
      setUiData({ loading: false, docTypes: success ? data.docTypes || [] : [], functions: success ? data.functions || [] : [] });
      if (id) {
        const res = await ApiService.get(id);
        if (res.success && res.data) formik.setValues({ ...res.data, isActive: !!res.data.isActive });
      }
    };
    init();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id]);

  const handleSubmit = async (values, { resetForm }) => {
    const { success } = await ApiService.save({ ...values, levelId: id || null, isUpdate: !!id });
    if (success) {
      MessageBoxService.show({ message: 'Approval level saved.', type: 'success', onClose: () => navigate('/settings/approval-levels') });
      resetForm();
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  return (
    <MeridianPage
      title={`${id ? 'Edit' : 'New'} Approval Level`}
      backTo="/settings/approval-levels"
      cardClass="ml-form-card"
      actions={
        <button type="submit" form="level-form" className="ml-btn-action ml-fab" disabled={uiData.loading}>
          <i className="bi bi-check-lg" aria-hidden="true" />
          Save
        </button>
      }
    >
      <form id="level-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="row g-2">
            <InputField {...fields.docType} formik={formik} />
            <InputField {...fields.levelNo} formik={formik} />
            <InputField {...fields.levelName} formik={formik} />
            <InputField {...fields.approverFunction} formik={formik} />
            <InputField {...fields.minAmount} formik={formik} />
            <InputField {...fields.maxAmount} formik={formik} />
            <InputField {...fields.isActive} formik={formik} />
          </div>
        </div>
      </form>
    </MeridianPage>
  );
}
