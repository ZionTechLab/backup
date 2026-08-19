import axios, { axiosRequest } from '../../../helpers/axiosMiddleware';
import config from '../../../config/config';

class CashBookService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'petty-cash/cash-book';
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

  async delete(param) {
    return axiosRequest(axios.post(`${this.apiBase}/delete`, param));
  }

  async establishFloat(param) {
    return axiosRequest(axios.post(`${this.apiBase}/establish-float`, param));
  }

  async reverseFloat(id) {
    return axiosRequest(axios.post(`${this.apiBase}/reverse-float`, { id }));
  }
}

export default new CashBookService();
