import axios, { axiosRequest } from '../../helpers/axiosMiddleware';
import config from '../../config/config';

class UomService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'uom';
  }

  async getUi() {
    // placeholder if UI data needed in future
    return { success: true, data: {} };
  }

  async update(param) {
    const res = await axiosRequest(axios.post(`${this.apiBase}/update`, param));
    return res;
  }

  async get(id) {
    const res = await axiosRequest(axios.get(`${this.apiBase}/get`, { params: { id } }));
    return res;
  }

  async getAll() {
    const res = await axiosRequest(axios.get(`${this.apiBase}/get-all`));
    return res;
  }

  async delete(param) {
    const res = await axiosRequest(axios.post(`${this.apiBase}/delete`, param));
    return res;
  }
}

const UomServiceInstance = new UomService();
export default UomServiceInstance;
