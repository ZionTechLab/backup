import axios, { axiosRequest } from '../../../helpers/axiosMiddleware';
import config from '../../../config/config';

class CashCountService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'petty-cash/cash-count';
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

  async sign(id) {
    return axiosRequest(axios.post(`${this.apiBase}/sign`, { id }));
  }

  async countersign(id) {
    return axiosRequest(axios.post(`${this.apiBase}/countersign`, { id }));
  }

  async audit(id) {
    return axiosRequest(axios.post(`${this.apiBase}/audit`, { id }));
  }

  async cancel(id) {
    return axiosRequest(axios.post(`${this.apiBase}/cancel`, { id }));
  }
}

export default new CashCountService();
