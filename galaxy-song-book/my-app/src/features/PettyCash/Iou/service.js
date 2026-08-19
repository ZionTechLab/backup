import axios, { axiosRequest } from '../../../helpers/axiosMiddleware';
import config from '../../../config/config';

class IouService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'petty-cash/iou';
  }

  async getUi() {
    return axiosRequest(axios.get(`${this.apiBase}/get-ui`));
  }

  async getAll() {
    return axiosRequest(axios.get(`${this.apiBase}/get-all`));
  }

  async getApprovedRequests() {
    return axiosRequest(axios.get(`${this.apiBase}/get-approved-requests`));
  }

  async get(id) {
    return axiosRequest(axios.get(`${this.apiBase}/get`, { params: { id } }));
  }

  async update(param) {
    return axiosRequest(axios.post(`${this.apiBase}/update`, param));
  }

  async act(param) {
    return axiosRequest(axios.post(`${this.apiBase}/act`, param));
  }

  async pay(id) {
    return axiosRequest(axios.post(`${this.apiBase}/pay`, { id }));
  }

  async cancel(id) {
    return axiosRequest(axios.post(`${this.apiBase}/cancel`, { id }));
  }

  async addAudit(param) {
    return axiosRequest(axios.post(`${this.apiBase}/add-audit`, param));
  }

}

export default new IouService();
