import * as Yup from 'yup';
import { useParams, useNavigate } from 'react-router-dom';
import { useEffect, useState } from 'react';
import { useFormikBuilder, FieldsRenderer } from '../../helpers/formikBuilder';
import ApiService from './service';
import MessageBoxService from '../../services/MessageBoxService';
import MeridianPage from '../Meridian/MeridianPage';

const fields = {
  itemCode: {
    name: 'itemCode',
    type: 'text',
    placeholder: 'Item Code',
    initialValue: '<Auto>',
    disabled: true,
    className: 'col-sm-6',
  },
  itemName: {
    name: 'itemName',
    type: 'text',
    placeholder: 'Item Name',
    initialValue: '',
    validation: Yup.string().required('Item name is required'),
    className: 'col-sm-6',
  },
  brand: {
    name: 'brand',
    type: 'text',
    placeholder: 'Brand',
    initialValue: '',
    className: 'col-sm-6',
  },
  uom: {
    name: 'uom',
    type: 'text',
    placeholder: 'Unit of Measure',
    initialValue: '',
    validation: Yup.string().required('UOM is required'),
    className: 'col-sm-6',
  },
  costPrice: {
    name: 'costPrice',
    type: 'amount',
    placeholder: 'Cost Price',
    initialValue: 0,
    className: 'col-sm-6',
  },
  sellingPrice: {
    name: 'sellingPrice',
    type: 'amount',
    placeholder: 'Selling Price',
    initialValue: 0,
    className: 'col-sm-6',
  },
  reorderLevel: {
    name: 'reorderLevel',
    type: 'number',
    placeholder: 'Reorder Level',
    initialValue: 0,
    className: 'col-sm-6',
  },
  active: {
    name: 'active',
    type: 'switch',
    initialValue: true,
    validation: Yup.boolean(),
    placeholder: 'Active',
    className: 'col-sm-6',
  },
  description: {
    name: 'description',
    type: 'textarea',
    placeholder: 'Description',
    initialValue: '',
    className: 'col-12',
  },
};

export default function AddItem() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    if (id) {
      const fetch = async () => {
        const { success, data } = await ApiService.get(id);
        if (success && data) formik.setValues({ ...data });
      };
      fetch();
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id]);

  const handleSubmit = async (values, { resetForm }) => {
    setLoading(true);
    const { success } = await ApiService.update({
      header: { ...values, id: parseInt(id || 0) },
      isUpdate: !!id,
    });
    setLoading(false);
    if (success) {
      MessageBoxService.show({
        message: 'Item saved successfully!',
        type: 'success',
        onClose: () => navigate('/item-master'),
      });
      resetForm();
    }
  };

  const handleDelete = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Delete this item?',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await ApiService.delete({ id });
    if (success) {
      MessageBoxService.show({
        message: 'Item deleted.',
        type: 'success',
        onClose: () => navigate('/item-master'),
      });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  return (
    <MeridianPage
      title={`${id ? 'Edit' : 'New'} Item`}
      backTo="/item-master"
      cardClass="ml-form-card"
      actions={
        <>
          {id && (
            <button type="button" className="ml-btn-ghost ml-btn-danger-ghost ml-fab-1" onClick={handleDelete}>
              <i className="bi bi-trash" aria-hidden="true" />
              Delete
            </button>
          )}
          <button type="submit" form="item-form" className="ml-btn-action ml-fab" disabled={loading}>
            <i className="bi bi-check-lg" aria-hidden="true" />
            Save
          </button>
        </>
      }
    >
      <form id="item-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="row g-2">
            <FieldsRenderer fields={fields} formik={formik} />
          </div>
        </div>
      </form>
    </MeridianPage>
  );
}
