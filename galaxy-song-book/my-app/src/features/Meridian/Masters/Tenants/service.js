import axios, { axiosRequest } from "../../../../helpers/axiosMiddleware";
import config from "../../../../config/config";

class TenantService {
  constructor() {
    this.apiBase = config.apiBaseUrl + "tenant";
  }

  async getAll() {
    return axiosRequest(axios.get(`${this.apiBase}/get-all`));
  }

  async get(tenantId) {
    return axiosRequest(axios.get(`${this.apiBase}/get`, { params: { tenantId } }));
  }

  async update(param) {
    return axiosRequest(axios.post(`${this.apiBase}/update`, param));
  }

  async delete(tenantId) {
    return axiosRequest(axios.post(`${this.apiBase}/delete`, { tenantId }));
  }

  async listUsers(tenantId) {
    return axiosRequest(axios.get(`${this.apiBase}/users`, { params: { tenantId } }));
  }

  async addUser(param) {
    return axiosRequest(axios.post(`${this.apiBase}/users/add`, param));
  }

  async removeUser(id) {
    return axiosRequest(axios.post(`${this.apiBase}/users/remove`, { id }));
  }

  async setDefaultUser(id) {
    return axiosRequest(axios.post(`${this.apiBase}/users/set-default`, { id }));
  }

  async countOtherTenants(id) {
    return axiosRequest(axios.get(`${this.apiBase}/users/count-other`, { params: { id } }));
  }

  async setMyDefault(tenantId) {
    return axiosRequest(axios.post(`${this.apiBase}/users/set-my-default`, { tenantId }));
  }
}

const tenantService = new TenantService();
export default tenantService;
