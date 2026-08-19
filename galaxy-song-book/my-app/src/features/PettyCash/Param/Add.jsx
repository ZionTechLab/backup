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

export default function AddParam() {
  const { id } = useParams();
  const navigate = useNavigate();
  const menuLabel = useMenuLabel('/petty-cash/param', 'Parameter');
  const [uiData, setUiData] = useState({ loading: true, accounts: [] });

  const fields = {
    paramGroup: {
      name: 'paramGroup', type: 'text', placeholder: 'Group', initialValue: '',
      validation: Yup.string().required('Group is required'), className: 'col-sm-6',
    },
    paramKey: {
      name: 'paramKey', type: 'text', placeholder: 'Key', initialValue: '',
      validation: Yup.string().required('Key is required'), className: 'col-sm-6',
    },
    numValue: {
      name: 'numValue', type: 'amount', placeholder: 'Num Value', initialValue: 0, className: 'col-sm-6',
    },
    textValue: {
      name: 'textValue', type: 'text', placeholder: 'Text Value', initialValue: '', className: 'col-sm-6',
    },
    glAccountId: {
      name: 'glAccountId', type: 'select', placeholder: 'GL Account', initialValue: '',
      dataBinding: { data: uiData.accounts, keyField: 'accountId', valueField: 'accountName' },
      className: 'col-sm-6',
    },
    isActive: {
      name: 'isActive', type: 'switch', placeholder: 'Active', initialValue: true,
      validation: Yup.boolean(), className: 'col-sm-6',
    },
  };

  useEffect(() => {
    const init = async () => {
      const { success, data } = await ApiService.getUi();
      setUiData({
        loading: false,
        accounts: success ? data.accounts || [] : [],
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
      paramId: id || null,
      isUpdate: !!id,
    });
    if (success) {
      MessageBoxService.show({
        message: 'Parameter saved successfully!',
        type: 'success',
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate('/petty-cash/param');
          } else if (!id && data?.paramId) {
            navigate(`/petty-cash/param/edit/${data.paramId}`);
          } else if (!id) {
            resetForm();
          }
        },
      });
    }
  };

  const handleDelete = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Delete this parameter?',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await ApiService.delete({ id });
    if (success) {
      MessageBoxService.show({
        message: 'Parameter deleted.',
        type: 'success',
        onClose: () => navigate('/petty-cash/param'),
      });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  return (
    <MeridianPage
      title={`${id ? 'Edit' : 'New'} ${menuLabel}`}
      backTo="/petty-cash/param"
      cardClass="ml-form-card"
      actions={
        <>
          {id && (
            <PermissionGate codes="pc-param-delete">
              <button type="button" className="ml-btn-ghost ml-btn-danger-ghost ml-fab-1" onClick={handleDelete}>
                <i className="bi bi-trash" aria-hidden="true" />
                Delete
              </button>
            </PermissionGate>
          )}
          <PermissionGate codes={id ? 'pc-param-update' : 'pc-param-save'}>
            <button type="submit" form="param-form" className="ml-btn-action ml-fab" disabled={uiData.loading}>
              <i className="bi bi-check-lg" aria-hidden="true" />
              Save
            </button>
          </PermissionGate>
        </>
      }
    >
      <form id="param-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="row g-2">
            <InputField {...fields.paramGroup} formik={formik} />
            <InputField {...fields.paramKey} formik={formik} />
            <InputField {...fields.numValue} formik={formik} />
            <InputField {...fields.textValue} formik={formik} />
            <InputField {...fields.glAccountId} formik={formik} />
            <InputField {...fields.isActive} formik={formik} />
          </div>
        </div>
      </form>
    </MeridianPage>
  );
}
