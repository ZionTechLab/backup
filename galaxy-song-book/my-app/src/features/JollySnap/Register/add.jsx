import { useState, useEffect } from "react";
import QRCode from "react-qr-code";
import * as Yup from "yup";
import { useParams, useNavigate } from 'react-router-dom';
import { useFormikBuilder, FieldsRenderer } from '../../../helpers/formikBuilder';
import { phoneYup } from '../../../helpers/phoneValidation';
import ApiService from "./service";
import MessageBoxService from "../../../services/MessageBoxService";



function RegisterPage() {
    const { id } = useParams();
    const navigate = useNavigate();
    const [registrationSuccess, setRegistrationSuccess] = useState(false);
    const [registeredId, setRegisteredId] = useState(null);
    const [uiData, setUiData] = useState({
        loading: false,
        success: false,
        error: "",
        data: {},
    });
    const fields = {
        id: {
            name: "id",
            type: "text",
            placeholder: "Job ID",
            initialValue: "<Auto>",
            disabled: true,
            // className: "col-sm-4 col-12",
        },
        name: {
            name: "name",
            type: "text",
            placeholder: "Name",
            initialValue: "",
            validation: Yup.string()
                .min(2, "Must be at least 2 characters")
                .matches(/^[a-zA-Z\s]*$/, "Only letters and spaces are allowed")
                .required("Name is required"),
        },
        email: {
            name: "email",
            type: "email",
            placeholder: "Email",
            initialValue: "",
        },
        whatsAppNo: {
            name: "whatsAppNo",
            type: "phone",
            placeholder: "Whats App No",
            initialValue: "",
            validation: phoneYup({ required: true }),
        },
        jobTags: {
            name: "jobTags",
            type: "switch-group",
            placeholder: "Items / Accessories",
            initialValue: [],
            // className: "col-12",
            dataBinding: {
                data: uiData?.data?.JobTags,
            },
        },
    };
    useEffect(() => {
        const fetchUi = async () => {
            setUiData((prev) => ({ ...prev, loading: true, error: "", data: {} }));
            const data = await ApiService.getUi();
            setUiData((prev) => ({ ...prev, ...data, loading: false }));
            // setuiDataFiltered((prev) => ({ ...prev, ...data }));
        };
        fetchUi();

        if (id) {
            const fetchTxn = async () => {
                const response = await ApiService.get(id);
                if (response.success && response.data) {
                    formik.setValues({ ...response.data });
                }
            };
            fetchTxn();
        }
    }, [id]);





    const handleRegisterSubmit = async (values) => {
        const param = {
            header: { ...values, id: parseInt(id ? id : 0) },
            isUpdate: id ? true : false,
        };
        const res = await ApiService.update(param);
        if (res.success) {
            if (id) {
                MessageBoxService.show({
                    message: "Registration updated successfully!",
                    type: "success",
                    onClose: () => navigate("/jolly-snap/register"),
                });
            } else {
                setRegistrationSuccess(true);
                setRegisteredId(res.data.id);
            }
        } else {
            await MessageBoxService.show({
                message: res.error || "Registration failed. Please try again.",
                type: "error",
            });
        }
    };

    const handleDelete = async () => {
        const confirmed = await MessageBoxService.confirmAsync({
            message: 'Are you sure you want to delete this registration?',
            type: 'danger',
            confirmText: 'Delete',
            cancelText: 'Cancel',
        });

        if (!confirmed) return;

        const response = await ApiService.delete({ id });
        if (response.success) {
            MessageBoxService.show({
                message: "Registration deleted successfully!",
                type: "success",
                onClose: () => navigate("/jolly-snap/register"),
            });
        }
    };

    const formik = useFormikBuilder(fields, handleRegisterSubmit);

    return (<>
        <div className="container pt-3">
            <div className="row justify-content-center">
                <div className="col-md-6 col-lg-5 col-xl-4">
                    <div className="card shadow-lg border-0 rounded-3">
                        <div className="card-body p-5">
                            {registrationSuccess ? (
                                <div className="text-center">
                                    <h2 className="h4 fw-bold text-success mb-3">Registration Completed</h2>
                                    <p className="mb-4">Your next step is make payments.</p>
                                    <div className="mb-4 p-3 bg-light rounded d-inline-block">
                                        <QRCode value={String(registeredId || "")} size={180} />
                                    </div>
                                    <p className="fw-bold mb-0">ID: {registeredId}</p>
                                </div>
                            ) : (
                                <>
                                    <div className="text-center mb-4">
                                        <h1 className="h3 fw-bold text-primary mb-2">{id ? 'Edit Registration' : 'Register'}</h1>
                                    </div>
                                    <form onSubmit={formik.handleSubmit} noValidate>
                                        <div className="row g-3 mb-4">
                                            <FieldsRenderer fields={fields} formik={formik} inputProps={{ autocomplete: 'off' }} />
                                        </div>
                                        <div className="d-flex gap-2">
                                            {id && (
                                                <button
                                                    className="btn btn-outline-danger w-50 py-2 fw-semibold rounded-pill"
                                                    type="button"
                                                    onClick={handleDelete}
                                                >
                                                    DELETE
                                                </button>
                                            )}
                                            <button
                                                className={`btn btn-primary py-2 fw-semibold rounded-pill ${id ? 'w-50' : 'w-100'}`}
                                                type="submit"
                                                disabled={formik.isSubmitting}
                                            >
                                                {id ? 'UPDATE' : 'REGISTER'}
                                            </button>
                                        </div>
                                    </form>
                                </>
                            )}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </>
    );
}

export default RegisterPage;
