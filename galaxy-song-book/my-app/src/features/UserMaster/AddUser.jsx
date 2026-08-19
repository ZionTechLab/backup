
import { useState, useEffect } from "react";
import { useParams, useNavigate } from 'react-router-dom';
import * as Yup from 'yup';
import { useFormikBuilder, FieldsRenderer } from '../../helpers/formikBuilder';
import { phoneYup } from '../../helpers/phoneValidation';
import ApiService from './UserService';
import MessageBoxService from "../../services/MessageBoxService";

import config from '../../config/config';

function AddUser() {
  const { userId } = useParams();
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({ loading: false, success: false, error: '', data: {} });
  const [selectedRoleIds, setSelectedRoleIds] = useState([]);
  const [allRoles, setAllRoles] = useState([]);
  const isEdit   = Boolean(userId);

  const fields = {
    userId: {
      name: "userId",
      type: "text",
      placeholder: "User Code",
      initialValue: "<Auto>",
      disabled: true,
      visible: false
    },
    userName: {
      name: "userName",
      type: "text",
      placeholder: "User ID",
      initialValue: "",
      disabled: !!userId,
      validation: Yup.string().required("User ID is required"),
      className: "col-sm-6 col-6"
    },
    password: {
      name: "password",
      type: "password",
      placeholder: userId ? "**************" : "Password",
      initialValue: "",
      validation: userId ? Yup.string() : Yup.string().required("Password is required"),
      className: "col-sm-6 col-6"
    },
    fullName: {
      name: "fullName",
      type: "text",
      placeholder: "Full Name",
      initialValue: "",
      validation: Yup.string().required("Full name is required"),
      // className: "col-md-6 col-sm-6 col-12"
    },
    email: {
      name: "email",
      type: "email",
      placeholder: "Email",
      initialValue: "",
      validation: Yup.string().email("Invalid email").required("Email is required"),
       className: "col-md-6 col-sm-6 col-12"
    },
    phone: {
      name: "phone",
      type: "phone",
      placeholder: "Phone",
      initialValue: "",
      validation: phoneYup({ required: true }),
      className: "col-md-3 col-sm-6 col-6"
    },
    phone2: {
      name: "phone2",
      type: "phone",
      placeholder: "Phone",
      initialValue: "",
      validation: phoneYup(),
      className: "col-md-3 col-sm-6 col-6"
    },
    roleId: {
      name: "roleId",
      type: "text",
      placeholder: "Role (legacy)",
      initialValue: "",
      visible: false
    },
    active: {
      name: "isActive",
      type: "switch",
      initialValue: true,
      validation: Yup.boolean(),
      placeholder: "Active",
    },
  };

  useEffect(() => {
    const fetchUi = async () => {
      setUiData(prev => ({ ...prev, loading: true, error: '', data: {} }));
      const data = await ApiService.getUi();
      if (data?.data?.Role) setAllRoles(data.data.Role);
      setUiData(prev => ({ ...prev, ...data, loading: false }));
    };
    fetchUi();

    if (userId) {
      const fetchTxn = async () => {
        const response = await ApiService.get(userId);
        if (response.success) {
          if (response.data) {
            formik.setValues({ ...response.data });
            if (response.data.roleIds) setSelectedRoleIds(response.data.roleIds);
          }
        }
      };
      fetchTxn();
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const handleSubmit = async (values, { resetForm }) => {
    const param = {
      header: { ...values, userId: userId || null, roleIds: selectedRoleIds },
      isUpdate: userId ? true : false
    };
    const response = await ApiService.update({ ...param });
    const { success, data } = response;

    if (success) {
      MessageBoxService.show({
        message: "User saved successfully!",
        type: "success",
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate("/user-master");
          } else if (!userId && data?.userId) {
            navigate(`/user-master/edit/${data.userId}`);
          } else if (!userId) {
            resetForm();
          }
        },
      });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  const handleDelete = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Are you sure you want to delete this User?',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });

    if (!confirmed) return;

    const response = await ApiService.delete({ userId });
    if (response.success) {
      MessageBoxService.show({
        message: "User deleted successfully!",
        type: "success",
        onClose: () => navigate("/user-master"),
      });
    }
  };

  const toggleRole = (roleId) => {
    setSelectedRoleIds(prev =>
      prev.includes(roleId) ? prev.filter(id => id !== roleId) : [...prev, roleId]
    );
  };


  return (
    <>
    <div className="ml-screen p-4">
      <div className="ml-page-header">
        <div className="ml-page-header-left">
          <button className="ml-back-btn" onClick={() => navigate("/settings/users")} type="button">
            <i className="bi bi-arrow-left" aria-hidden="true" />
            Users
          </button>
          <h1 className="ml-page-title mt-2">{isEdit ? "Edit User" : "New User"}</h1>
          {isEdit && (
            <button type="button" className="ml-btn-ghost ml-btn-danger-ghost ms-3" onClick={handleDelete}>
              <i className="bi bi-trash" aria-hidden="true" />
              Delete
            </button>
          )}
          <button type="submit" form="currency-form" className="ml-btn-action ms-2" disabled={formik.isSubmitting}>
            {formik.isSubmitting
              ? <span className="ml-spinner" aria-hidden="true" />
              : <i className="bi bi-check-lg" aria-hidden="true" />}
            {isEdit ? "Save Changes" : "Create User"}
          </button>
        </div>
      </div>

      <div className="ml-form-card">
        <form id="currency-form" onSubmit={formik.handleSubmit}>
          <div className="ml-form-section">
            <div className="ml-form-section-label">Details</div>
            <div className="row g-3">
              <FieldsRenderer fields={fields} formik={formik} />
            </div>
          </div>
          {allRoles.length > 0 && (
            <div className="ml-form-section mt-3">
              <div className="ml-form-section-label">Roles</div>
              <div className="row g-2">
                {allRoles.map(role => (
                  <div key={role.id} className="col-md-4 col-sm-6">
                    <div className="ml-checkbox-card">
                      <label className="ml-checkbox-label">
                        <input
                          type="checkbox"
                          checked={selectedRoleIds.includes(role.id)}
                          onChange={() => toggleRole(role.id)}
                          className="ml-checkbox"
                        />
                        <span className="ml-checkbox-text">{role.roleName}</span>
                      </label>
                    </div>
                  </div>
                ))}
              </div>
            </div>
          )}
        </form>
      </div>
    </div></>
  );
}

export default AddUser;