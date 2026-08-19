import axios, { axiosRequest } from '../../helpers/axiosMiddleware';
import config from '../../config/config';

class PartnerService {
  constructor() {
    this.apiBase = config.apiBaseUrl+'business-partners';
  }

  async update(param) {
    const res = await axiosRequest(axios.post(`${this.apiBase}/update`, param));
    return res;
  }

  async get(id) {
    const res = await axiosRequest(axios.get(`${this.apiBase}/get`,{ params: { id } }));
    return res;
  }

  async getAll(type) {
    const res = await axiosRequest(axios.get(`${this.apiBase}/get-all`, { params: { type } }));
    return res;
  }

  async delete(param) {
    const res = await axiosRequest(axios.post(`${this.apiBase}/delete`, param));
    return res;
  }

  async uploadFile(file) {
    const form = new FormData();
    form.append('file', file);
    const res = await axiosRequest(axios.post(`${config.apiBaseUrl}files/upload`, form, {
      headers: { 'Content-Type': 'multipart/form-data' },
    }));
    return res;
  }
}

const partnerServiceInstance = new PartnerService();
export default partnerServiceInstance;