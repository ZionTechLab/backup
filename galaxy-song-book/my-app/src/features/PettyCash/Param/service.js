import axios, { axiosRequest } from '../../../helpers/axiosMiddleware';
import config from '../../../config/config';

class ParamService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'petty-cash/param';
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
}

export default new ParamService();
