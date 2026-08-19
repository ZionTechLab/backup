import axios, { axiosRequest } from '../../../helpers/axiosMiddleware';
import config from '../../../config/config';

class ReplenishmentService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'petty-cash/replenishment';
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

  async verify(id) {
    return axiosRequest(axios.post(`${this.apiBase}/verify`, { id }));
  }

  async approve(id) {
    return axiosRequest(axios.post(`${this.apiBase}/approve`, { id }));
  }

  async post(id) {
    return axiosRequest(axios.post(`${this.apiBase}/post`, { id }));
  }

  async cancel(id) {
    return axiosRequest(axios.post(`${this.apiBase}/cancel`, { id }));
  }
}

export default new ReplenishmentService();
