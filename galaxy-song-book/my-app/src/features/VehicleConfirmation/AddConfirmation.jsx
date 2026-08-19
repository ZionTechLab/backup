import {  useState,useEffect } from "react";
import { useParams,useNavigate } from "react-router-dom";
import { useFormikBuilder } from "../../helpers/formikBuilder";
import MessageBoxService from "../../services/MessageBoxService";
import ApiService from "./ConfirmationService";
import config from '../../config/config';
import transformDateFields from "../../helpers/transformDateFields";
import { compressImageItems } from "../../helpers/imageCompression";
import { getFields } from "./config/fields";
import AddConfirmationForm from "./components/AddConfirmationForm";


const AddConfirmation = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [uiData, setUiData] = useState({loading: false, success: false, error: '', data: {} });
  const [uiDataFiltered, setuiDataFiltered] = useState({ Make: [], Model: [], Grade: [], Colour: [], FuelType: [], Transmission: [] });
  const [, setIsUpdate] = useState(false);

const fields = getFields(uiDataFiltered);

  useEffect(() => {
    const fetchUi = async () => {
      setUiData(prev => ({ ...prev, loading: true, error: '', data: {} }));
      const data = await ApiService.getUi();
      setUiData(prev => ({ ...prev, ...data , loading: false }));
      setuiDataFiltered(prev => ({ ...prev,  Make: data.data.Make || [],Colour: data.data.Colour || [], FuelType: data.data.FuelType || [], Transmission: data.data.Transmission || [] }));
    };
    fetchUi();

    if (id) {
      setIsUpdate(true);
      const fetchTxn = async () => {
        const response = await ApiService.get(id);
        if (response.success && response.data) {
          const data = { ...response.data };

          // Normalize to an array of File objects for the UI
          const toFile = async (imgNameOrUrl) => {
            try {
              const url = imgNameOrUrl.includes('http')
                ? imgNameOrUrl
                : config.apiBaseUrl+ 'uploads/' + imgNameOrUrl;
              const res = await fetch(url);
              const blob = await res.blob();
              const filename = (url.split('/').pop() || 'image').split('?')[0];
              return new File([blob], filename, { type: blob.type || 'image/jpeg' });
            } catch (e) {
              return null;
            }
          };

          let imageFiles = [];
          if (Array.isArray(data.images)) {
            const results = await Promise.all(data.images.map(toFile));
            imageFiles = results.filter(Boolean);
          } else if (typeof data.image === 'string' && data.image) {
            const f = await toFile(data.image);
            if (f) imageFiles = [f];
          }
          const normalized = transformDateFields(data, fields);
           
          formik.setValues({
            ...normalized,
            images: imageFiles,
          });
        }
      };
      fetchTxn();
    }
     // eslint-disable-next-line
  }, [id]);

  const handleSubmit = async (values, { resetForm }) => {
    // Compress only newly added images before submit
    if (Array.isArray(values.images) && values.images.length) {
      values.images = await compressImageItems(values.images, {
        maxWidth: 1600,
        maxHeight: 1600,
        quality: 0.8,
        maxSizeKB: 400, // target ~400KB per image
        mimeType: 'image/webp',
        fallbackType: 'image/jpeg',
      });
    }

    const param = { 
      header: { ...values , id: parseInt(id ? id : 0)}, 
      isUpdate:id ? true : false
    };
    const response = await ApiService.update({ ...param });
    const { success, data } = response;

    if (success) {
      MessageBoxService.show({
        message: "Invoice saved successfully!",
        type: "success",
        onClose: () => {
          if (config.features.returnToListAfterSave) {
            navigate("/vehicle-confirmation");
          } else if (!id && data?.id) {
            navigate(`/vehicle-confirmation/edit/${data.id}`);
          } else if (!id) {
            resetForm();
          }
        },
      });

    }
  };


  const formik = useFormikBuilder(fields, handleSubmit);

  useEffect(() => {
    const filteredModels = (uiData.data.Model || []).filter(
      // eslint-disable-next-line
      (m) => m.parentId == formik.values.make
    );
    setuiDataFiltered((prev) => ({
      ...prev,
      Model: filteredModels,
      Grade: [],
    }));
    filterGrade();
    // eslint-disable-next-line
  }, [formik.values.make]);

  useEffect(() => {
    const filteredData = (uiData.data.Grade || []).filter(
      // eslint-disable-next-line
      (m) => m.parentId == formik.values.model
    );
    setuiDataFiltered((prev) => ({ ...prev, Grade: filteredData }));
    // eslint-disable-next-line
  }, [formik.values.model]);

  const filterGrade = () => {};

  const handleDelete = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Are you sure you want to delete this Record?',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });

    if (!confirmed) return;

    const response = await ApiService.delete({ id});
    if (response.success) {
      MessageBoxService.show({
        message: "Record deleted successfully!",
        type: "success",
        onClose: () => navigate("/vehicle-confirmation"),
      });
    }
  };
  

  return (
    <AddConfirmationForm
      formik={formik}
      fields={fields}
      id={id}
      handleDelete={handleDelete}
    />
  );
};

export default AddConfirmation;