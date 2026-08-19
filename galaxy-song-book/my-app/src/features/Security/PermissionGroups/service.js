import axios, { axiosRequest } from '../../../helpers/axiosMiddleware';
import config from '../../../config/config';

class PermissionGroupService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'permission-group';
  }

  async getAll() {
    return axiosRequest(axios.get(`${this.apiBase}/get-all`));
  }

  async get(id) {
    return axiosRequest(axios.get(`${this.apiBase}/get`, { params: { id } }));
  }

  async save(payload) {
    return axiosRequest(axios.post(`${this.apiBase}/save`, payload));
  }

  async delete(id) {
    return axiosRequest(axios.post(`${this.apiBase}/delete`, { id }));
  }
}

export default new PermissionGroupService();
