import * as Yup from 'yup';
import { useParams, useNavigate } from 'react-router-dom';
import { useEffect } from 'react';
import { useFormikBuilder, FieldsRenderer } from '../../helpers/formikBuilder';
import ApiService from './service';
import MessageBoxService from '../../services/MessageBoxService';
import MeridianPage from '../Meridian/MeridianPage';

const fields = {
  uomCode: {
    name: 'uomCode',
    type: 'text',
    placeholder: 'UOM Code',
    initialValue: '<Auto>',
    disabled: true,
    className: 'col-sm-6',
  },
  uomName: {
    name: 'uomName',
    type: 'text',
    placeholder: 'UOM Name',
    initialValue: '',
    validation: Yup.string().required('UOM name is required'),
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

export default function AddUom() {
  const { id } = useParams();
  const navigate = useNavigate();

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
    const { success } = await ApiService.update({
      header: { ...values, id: parseInt(id || 0) },
      isUpdate: !!id,
    });
    if (success) {
      MessageBoxService.show({
        message: 'UOM saved successfully!',
        type: 'success',
        onClose: () => navigate('/uom-master'),
      });
      resetForm();
    }
  };

  const handleDelete = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Delete this UOM?',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await ApiService.delete({ id });
    if (success) {
      MessageBoxService.show({
        message: 'UOM deleted.',
        type: 'success',
        onClose: () => navigate('/uom-master'),
      });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  return (
    <MeridianPage
      title={`${id ? 'Edit' : 'New'} UOM`}
      backTo="/uom-master"
      cardClass="ml-form-card"
      actions={
        <>
          {id && (
            <button type="button" className="ml-btn-ghost ml-btn-danger-ghost ml-fab-1" onClick={handleDelete}>
              <i className="bi bi-trash" aria-hidden="true" />
              Delete
            </button>
          )}
          <button type="submit" form="uom-form" className="ml-btn-action ml-fab">
            <i className="bi bi-check-lg" aria-hidden="true" />
            Save
          </button>
        </>
      }
    >
      <form id="uom-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="row g-2">
            <FieldsRenderer fields={fields} formik={formik} />
          </div>
        </div>
      </form>
    </MeridianPage>
  );
}
