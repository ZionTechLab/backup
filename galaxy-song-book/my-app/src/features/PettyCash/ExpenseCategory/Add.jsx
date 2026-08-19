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

export default function AddExpenseCategory() {
  const { id } = useParams();
  const navigate = useNavigate();
  const menuLabel = useMenuLabel('/petty-cash/expense-category', 'Petty Cash Category');
  const [uiData, setUiData] = useState({ loading: true, accounts: [] });

  const fields = {
    name: {
      name: 'name', type: 'text', placeholder: 'Category Name', initialValue: '',
      validation: Yup.string().required('Name is required'), className: 'col-sm-6',
    },
    glAccountId: {
      name: 'glAccountId', type: 'select', placeholder: 'Expense Account', initialValue: '',
      dataBinding: { data: uiData.accounts, keyField: 'accountId', valueField: 'accountName' },
      validation: Yup.string().required('Expense account is required'), className: 'col-sm-6',
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
      categoryId: id || null,
      isUpdate: !!id,
    });
    if (success) {
      MessageBoxService.show({
        message: 'Petty cash category saved successfully!',
        type: 'success',
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate('/petty-cash/expense-category');
          } else if (!id && data?.categoryId) {
            navigate(`/petty-cash/expense-category/edit/${data.categoryId}`);
          } else if (!id) {
            resetForm();
          }
        },
      });
    }
  };

  const handleDelete = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Delete this petty cash category?',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await ApiService.delete({ id });
    if (success) {
      MessageBoxService.show({
        message: 'Petty cash category deleted.',
        type: 'success',
        onClose: () => navigate('/petty-cash/expense-category'),
      });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  return (
    <MeridianPage
      title={`${id ? 'Edit' : 'New'} ${menuLabel}`}
      backTo="/petty-cash/expense-category"
      cardClass="ml-form-card"
      actions={
        <>
          {id && (
            <PermissionGate codes="pc-expense-category-delete">
              <button type="button" className="ml-btn-ghost ml-btn-danger-ghost ml-fab-1" onClick={handleDelete}>
                <i className="bi bi-trash" aria-hidden="true" />
                Delete
              </button>
            </PermissionGate>
          )}
          <PermissionGate codes={id ? 'pc-expense-category-update' : 'pc-expense-category-save'}>
            <button type="submit" form="expense-category-form" className="ml-btn-action ml-fab" disabled={uiData.loading}>
              <i className="bi bi-check-lg" aria-hidden="true" />
              Save
            </button>
          </PermissionGate>
        </>
      }
    >
      <form id="expense-category-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="row g-2">
            <InputField {...fields.name} formik={formik} />
            <InputField {...fields.glAccountId} formik={formik} />
            <InputField {...fields.isActive} formik={formik} />
          </div>
        </div>
      </form>
    </MeridianPage>
  );
}
