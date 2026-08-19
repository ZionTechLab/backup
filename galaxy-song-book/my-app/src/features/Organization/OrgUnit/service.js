import axios, { axiosRequest } from '../../../helpers/axiosMiddleware';
import config from '../../../config/config';

class OrgUnitService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'org-unit';
  }

  async getCompanies() {
    return axiosRequest(axios.get(`${this.apiBase}/get-companies`));
  }

  async getAll(unitType) {
    return axiosRequest(axios.get(`${this.apiBase}/get-all`, { params: { unitType } }));
  }

  async getParents(unitType, companyId) {
    return axiosRequest(axios.get(`${this.apiBase}/get-parents`, { params: { unitType, companyId } }));
  }

  async get(id) {
    return axiosRequest(axios.get(`${this.apiBase}/get`, { params: { id } }));
  }

  async save(param) {
    return axiosRequest(axios.post(`${this.apiBase}/save`, param));
  }

  async delete(param) {
    return axiosRequest(axios.post(`${this.apiBase}/delete`, param));
  }
}

export default new OrgUnitService();
