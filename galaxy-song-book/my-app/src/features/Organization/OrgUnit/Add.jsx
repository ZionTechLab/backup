import * as Yup from 'yup';
import { useParams, useNavigate } from 'react-router-dom';
import { useEffect, useState, useMemo } from 'react';
import InputField from '../../../components/InputField';
import { useFormikBuilder } from '../../../helpers/formikBuilder';
import ApiService from './service';
import MessageBoxService from '../../../services/MessageBoxService';
import MeridianPage from '../../Meridian/MeridianPage';

const UNIT_RANK = { Branch: 1, Division: 2, Department: 3, Section: 4 };

const parentLabelOf = (unitType) => {
  const rank = UNIT_RANK[unitType];
  if (!rank || rank <= 1) return null;
  return Object.keys(UNIT_RANK).find((k) => UNIT_RANK[k] === rank - 1);
};

export default function AddOrgUnit({ unitType, title }) {
  const { id } = useParams();
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: true, parents: [], companies: [] });

  const isBranch = unitType === 'Branch';
  const parentType = useMemo(() => parentLabelOf(unitType), [unitType]);
  const parentPlaceholder = parentType ? `${parentType}` : 'Parent';

  const loadParents = async (companyId) => {
    const { success, data } = await ApiService.getParents(unitType, companyId || undefined);
    setUiData((prev) => ({ ...prev, parents: success ? data || [] : [] }));
  };

  const fields = useMemo(() => ({
    code: {
      name: 'code', type: 'text', placeholder: 'Code', initialValue: '',
      validation: Yup.string().required('Code is required').max(40), className: 'col-sm-6',
    },
    name: {
      name: 'name', type: 'text', placeholder: 'Name', initialValue: '',
      validation: Yup.string().required('Name is required').max(150), className: 'col-sm-6',
    },
    companyId: {
      name: 'companyId', type: 'select', placeholder: 'Company', initialValue: '',
      validation: isBranch ? Yup.string().required('Company is required') : Yup.string().nullable(),
      dataBinding: { data: uiData.companies, keyField: 'companyId', valueField: 'companyName' },
      className: 'col-sm-6',
      visible: isBranch,
    },
    parentId: {
      name: 'parentId', type: 'select', placeholder: parentPlaceholder, initialValue: '',
      dataBinding: { data: uiData.parents, keyField: 'orgUnitId', valueField: 'name' },
      className: 'col-sm-6',
    },
    isActive: {
      name: 'isActive', type: 'switch', placeholder: 'Active', initialValue: true,
      validation: Yup.boolean(), className: 'col-sm-6',
    },
  }), [uiData.companies, uiData.parents, parentPlaceholder, isBranch]);

  useEffect(() => {
    const init = async () => {
      if (isBranch) {
        const companiesRes = await ApiService.getCompanies();
        setUiData({
          loading: false,
          parents: [],
          companies: companiesRes.success ? companiesRes.data || [] : [],
        });
      } else {
        const parentsRes = await ApiService.getParents(unitType);
        setUiData({
          loading: false,
          parents: parentsRes.success ? parentsRes.data || [] : [],
          companies: [],
        });
      }
      if (id) {
        const res = await ApiService.get(id);
        if (res.success && res.data) {
          formik.setValues({ ...res.data });
        }
      }
    };
    init();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id, unitType]);

  const handleSubmit = async (values, { resetForm }) => {
    let companyId = values.companyId;

    // Derive company from parent for non-Branch
    if (!isBranch && values.parentId) {
      const parent = uiData.parents.find((p) => p.orgUnitId === values.parentId);
      if (parent) companyId = parent.companyId;
    }

    const { success } = await ApiService.save({
      ...values,
      companyId: companyId || null,
      orgUnitId: id || null,
      unitType,
    });
    if (success) {
      MessageBoxService.show({
        message: `${unitType} saved successfully!`,
        type: 'success',
        onClose: () => navigate(`/masters/${unitType.toLowerCase()}`),
      });
      resetForm();
    }
  };

  const handleDelete = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: `Delete this ${unitType.toLowerCase()}?`,
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });
    if (!confirmed) return;
    const { success } = await ApiService.delete({ id });
    if (success) {
      MessageBoxService.show({
        message: `${unitType} deleted.`,
        type: 'success',
        onClose: () => navigate(`/masters/${unitType.toLowerCase()}`),
      });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  // Branch: reload parents when companyId changes
  const watchedCompanyId = formik?.values?.companyId;
  useEffect(() => {
    if (!isBranch) return;
    formik?.setFieldValue?.('parentId', '');
    if (watchedCompanyId) loadParents(watchedCompanyId);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [watchedCompanyId, isBranch]);

  const routeBase = `/masters/${unitType.toLowerCase()}`;

  return (
    <MeridianPage
      title={`${id ? 'Edit' : 'New'} ${title || unitType}`}
      backTo={routeBase}
      cardClass="ml-form-card"
      actions={
        <>
          {id && (
            <button type="button" className="ml-btn-ghost ml-btn-danger-ghost ml-fab-1" onClick={handleDelete}>
              <i className="bi bi-trash" aria-hidden="true" />
              Delete
            </button>
          )}
          <button type="submit" form="orgunit-form" className="ml-btn-action ml-fab" disabled={uiData.loading}>
            <i className="bi bi-check-lg" aria-hidden="true" />
            Save
          </button>
        </>
      }
    >
      <form id="orgunit-form" onSubmit={formik.handleSubmit}>
        <div className="ml-form-section">
          <div className="row g-2">
            <InputField {...fields.code} formik={formik} />
            <InputField {...fields.name} formik={formik} />
            <InputField {...fields.companyId} formik={formik} />
            {uiData.parents.length > 0 && <InputField {...fields.parentId} formik={formik} />}
            <InputField {...fields.isActive} formik={formik} />
          </div>
        </div>
      </form>
    </MeridianPage>
  );
}
