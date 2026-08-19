import * as Yup from 'yup';
import { useParams, useNavigate } from 'react-router-dom';
import { useEffect, useState } from 'react';
import InputField from '../../components/InputField';
import { useFormikBuilder } from '../../helpers/formikBuilder';
import MessageBoxService from '../../services/MessageBoxService';
import SelectedBusinessPartnerBox from '../BusinessPartners/select-bp';
import InquiryService from './InquiryService';
import MeridianPage from '../Meridian/MeridianPage';
import transformDateFields, { todayISO } from '../../helpers/transformDateFields';

const staticFields = {
  txnNoDisplay: {
    name: 'txnNoDisplay',
    type: 'text',
    placeholder: 'Job No',
    initialValue: '<Auto>',
    disabled: true,
  },
  txnDate: {
    name: 'txnDate',
    type: 'date',
    placeholder: 'Job Date',
    initialValue: todayISO(),
    validation: Yup.string().required('Job Date is required'),
  },
  customer: {
    name: 'customer',
    type: 'partner-select',
    placeholder: 'Customer',
    initialValue: '',
    validation: Yup.string().required('Customer is required'),
    isOpen: false,
  },
  ref1: {
    name: 'ref1',
    type: 'text',
    placeholder: 'Item Name',
    initialValue: '',
    validation: Yup.string().required('Item Name is required'),
  },
  ref2: {
    name: 'ref2',
    type: 'text',
    placeholder: 'Serial No',
    initialValue: '',
  },
  ref3: {
    name: 'ref3',
    type: 'date',
    placeholder: 'Due Date',
    initialValue: todayISO(),
  },
  description: {
    name: 'description',
    type: 'textarea',
    placeholder: 'Nature of Faulty',
    initialValue: '',
    validation: Yup.string().required('Nature of Faulty is required'),
  },
  remarks: {
    name: 'remarks',
    type: 'textarea',
    placeholder: 'To Do',
    initialValue: '',
  },
};

export default function AddInquiry() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, JobStatus: [], JobTags: [] });
  const [jobTags, setJobTags] = useState([]);

  const fields = {
    ...staticFields,
    status: {
      name: 'status',
      type: 'select',
      placeholder: 'Status',
      initialValue: '',
      dataBinding: { data: uiData.JobStatus, keyField: 'id', valueField: 'value' },
      validation: Yup.number().required('Status is required'),
    },
  };

  useEffect(() => {
    const init = async () => {
      const { success, data } = await InquiryService.getUi();
      if (success) {
        const tags = (data.JobTags || []).map((t) => ({ ...t, checked: false }));
        setUiData({ loading: false, JobStatus: data.JobStatus || [], JobTags: data.JobTags || [] });
        setJobTags(tags);
      } else {
        setUiData((prev) => ({ ...prev, loading: false }));
      }

      if (id) {
        const res = await InquiryService.get(id);
        if (res.success && res.data) {
          const { jobTags: savedTags, ...formData } = res.data;
          const normalized = transformDateFields(formData, staticFields);
          formik.setValues({
            txnNoDisplay: formData.txnNoDisplay ?? '<Auto>',
            txnDate: normalized.txnDate ?? staticFields.txnDate.initialValue,
            customer: normalized.customer ?? normalized.partner ?? '',
            ref1: normalized.ref1 ?? '',
            ref2: normalized.ref2 ?? '',
            ref3: normalized.ref3 ?? '',
            description: normalized.description ?? '',
            remarks: normalized.remarks ?? '',
            status: normalized.status ?? '',
          });
          if (Array.isArray(savedTags)) {
            setJobTags((prev) =>
              prev.map((t) => ({ ...t, checked: savedTags.includes(t.id) }))
            );
          }
        }
      }
    };
    init();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id]);

  const handleSubmit = async (values) => {
    const param = {
      isUpdate: !!id,
      header: {
        id: id ? parseInt(id) : 0,
        txnDate: values.txnDate,
        partner: values.customer,
        status: values.status,
        ref1: values.ref1,
        ref2: values.ref2,
        ref3: values.ref3,
        description: values.description,
        remarks: values.remarks,
        jobTags: jobTags.map((t) => ({ id: t.id, value: t.checked })),
      },
    };

    const { success } = await InquiryService.save(param);
    if (success) {
      MessageBoxService.show({
        message: `Inquiry ${id ? 'updated' : 'saved'} successfully!`,
        type: 'success',
        onClose: () => navigate('/inquiry'),
      });
    }
  };

  const handleDelete = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Delete this inquiry?',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await InquiryService.delete(id);
    if (success) {
      MessageBoxService.show({
        message: 'Inquiry deleted.',
        type: 'success',
        onClose: () => navigate('/inquiry'),
      });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  return (
    <MeridianPage
      title={`${id ? 'Edit' : 'New'} Inquiry`}
      backTo="/inquiry"
      cardClass="ml-form-card"
      actions={
        <>
          {id && (
            <button type="button" className="ml-btn-ghost ml-btn-danger-ghost ml-fab-1" onClick={handleDelete}>
              <i className="bi bi-trash" aria-hidden="true" />
              Delete
            </button>
          )}
          <button type="submit" form="inquiry-form" className="ml-btn-action ml-fab" disabled={uiData.loading}>
            <i className="bi bi-check-lg" aria-hidden="true" />
            Save
          </button>
        </>
      }
    >
      <form id="inquiry-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="row g-2">
            <InputField {...fields.txnNoDisplay} formik={formik} className="col-sm-6" />
            <InputField {...fields.txnDate} formik={formik} className="col-sm-6" />
            <SelectedBusinessPartnerBox field={fields.customer} formik={formik} />
            <InputField {...fields.status} formik={formik} className="col-sm-6" />
            <InputField {...fields.ref1} formik={formik} className="col-sm-6" />
            <InputField {...fields.ref2} formik={formik} className="col-sm-6" />
            <InputField {...fields.ref3} formik={formik} className="col-sm-6" />
            <InputField {...fields.description} formik={formik} />
            <InputField {...fields.remarks} formik={formik} />

            {jobTags.length > 0 && (
              <div className="col-sm-12">
                <label className="form-label">Items / Accessories</label>
                <div className="card">
                  <div className="card-body">
                    <div className="row g-2">
                      {jobTags.map((tag) => (
                        <div key={tag.id} className="col-4 col-lg-3 col-xl-2">
                          <div className="form-check">
                            <input
                              className="form-check-input"
                              type="checkbox"
                              id={`tag-${tag.id}`}
                              checked={tag.checked}
                              onChange={(e) =>
                                setJobTags((prev) =>
                                  prev.map((t) => t.id === tag.id ? { ...t, checked: e.target.checked } : t)
                                )
                              }
                            />
                            <label className="form-check-label" htmlFor={`tag-${tag.id}`}>
                              {tag.value}
                            </label>
                          </div>
                        </div>
                      ))}
                    </div>
                  </div>
                </div>
              </div>
            )}
          </div>
        </div>
      </form>
    </MeridianPage>
  );
}
