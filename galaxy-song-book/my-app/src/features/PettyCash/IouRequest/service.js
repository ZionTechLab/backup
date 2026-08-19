import axios, { axiosRequest } from '../../../helpers/axiosMiddleware';
import config from '../../../config/config';

class IouRequestService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'petty-cash/iou-request';
  }

  async getAll() {
    return axiosRequest(axios.get(`${this.apiBase}/get-all`));
  }

  async get(id) {
    return axiosRequest(axios.get(`${this.apiBase}/get`, { params: { id } }));
  }

  async getApproved() {
    return axiosRequest(axios.get(`${this.apiBase}/get-approved`));
  }

  async getUi() {
    return axiosRequest(axios.get(`${this.apiBase}/get-ui`));
  }

  async update(param) {
    return axiosRequest(axios.post(`${this.apiBase}/update`, param));
  }

  async act(id, action, amount, comment) {
    return axiosRequest(axios.post(`${this.apiBase}/act`, { id, action, amount, comment }));
  }

  async close(id) {
    return axiosRequest(axios.post(`${this.apiBase}/close`, { id }));
  }

  async cancel(id) {
    return axiosRequest(axios.post(`${this.apiBase}/cancel`, { id }));
  }
}

export default new IouRequestService();
