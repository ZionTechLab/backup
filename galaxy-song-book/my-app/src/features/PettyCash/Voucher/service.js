import axios, { axiosRequest } from '../../../helpers/axiosMiddleware';
import config from '../../../config/config';

class VoucherService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'petty-cash/voucher';
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

  async pay(id) {
    return axiosRequest(axios.post(`${this.apiBase}/pay`, { id }));
  }

  async cancel(id) {
    return axiosRequest(axios.post(`${this.apiBase}/cancel`, { id }));
  }
}

export default new VoucherService();
