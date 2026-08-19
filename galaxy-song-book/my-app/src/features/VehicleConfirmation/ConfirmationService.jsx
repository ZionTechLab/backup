import axios, { axiosRequest } from '../../helpers/axiosMiddleware';
import config from '../../config/config';

class ConfirmationService {
  constructor() {
    this.apiBase = config.apiBaseUrl + "vehicle-confirmation";
  }

  async getUi() {
    const res = await axiosRequest(
      axios.get(`${this.apiBase}/get-ui`)
    );
    return res;
  }

  async getAll() {
    const res = await axiosRequest(
      axios.get(`${this.apiBase}/get-all`)
    );
    return res;
  }

  async get(id) {
    const res = await axiosRequest(
      axios.get(`${this.apiBase}/get`, { params: { id } })
    );
    return res;
  }

  async delete(param) {
    const res = await axiosRequest(
      axios.post(`${this.apiBase}/delete`, param)
    );
    return res;
  }

  async update(param) {
    const { images, ...headerWithoutImages } = param.header;
    const updatedParam = { ...param, header: headerWithoutImages };
    const res = await axiosRequest(
      axios.post(`${this.apiBase}/update`, updatedParam)
    );
    if (res && res.success) {
      if (images && images.length > 0) {
        const formData = new FormData();
        images.forEach((img, idx) => {
          if (img.status === 'new') {
            try {
              formData.append("image", img.file, img.file.name || `image_${idx}`);
            } catch (err) {
              formData.append("image", img.file);
            }
          }
        });
        formData.append("id", res.data);

        // Build upload headers: in browser let axios set Content-Type (do not set multipart boundary),
        // in Node (form-data package) forward getHeaders()
        let uploadHeaders = {};
        if (
          typeof window === "undefined" &&
          typeof formData.getHeaders === "function"
        ) {
          uploadHeaders = formData.getHeaders();
        }

        const res2 = await axiosRequest(
          axios.post(`${this.apiBase}/images`, formData, {
            headers: uploadHeaders,
          })
        );
        return res2;
      } else {
       return res;
      }
    } else {
      console.error("Update failed:", res);
    }

    return null;
  }




}

const confirmationServiceInstance = new ConfirmationService();
export default confirmationServiceInstance;
