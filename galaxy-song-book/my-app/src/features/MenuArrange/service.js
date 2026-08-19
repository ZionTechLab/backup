import axios, { axiosRequest } from '../../helpers/axiosMiddleware';
import config from '../../config/config';

class MenuService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'menu';
  }

  async getAll() {
    return axiosRequest(axios.get(`${this.apiBase}/get-all`));
  }

  async save(param) {
    return axiosRequest(axios.post(`${this.apiBase}/save`, param));
  }

  async arrange(items) {
    return axiosRequest(axios.post(`${this.apiBase}/arrange`, { items }));
  }

  async setGrants(id, roleIds) {
    return axiosRequest(axios.post(`${this.apiBase}/grants`, { id, roleIds }));
  }
}

export default new MenuService();
