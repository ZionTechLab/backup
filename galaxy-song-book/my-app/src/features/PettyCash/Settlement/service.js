import axios, { axiosRequest } from '../../../helpers/axiosMiddleware';
import config from '../../../config/config';

class SettlementService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'petty-cash/settlement';
  }

  async getUi() {
    return axiosRequest(axios.get(`${this.apiBase}/get-ui`));
  }

  async getAll() {
    return axiosRequest(axios.get(`${this.apiBase}/get-all`));
  }

  async get(id) {
    return axiosRequest(axios.get(`${this.apiBase}/get`, { params: { id } }));
  }

  async update(param) {
    return axiosRequest(axios.post(`${this.apiBase}/update`, param));
  }

  async act(id, action, comment) {
    return axiosRequest(axios.post(`${this.apiBase}/act`, { id, action, comment }));
  }

  async clear(id) {
    return axiosRequest(axios.post(`${this.apiBase}/clear`, { id }));
  }

  async cancel(id) {
    return axiosRequest(axios.post(`${this.apiBase}/cancel`, { id }));
  }
}

export default new SettlementService();
