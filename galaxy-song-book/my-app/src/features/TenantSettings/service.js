import axios, { axiosRequest } from "../../helpers/axiosMiddleware";
import config from "../../config/config";

class TenantSettingsService {
  constructor() {
    this.apiBase = config.apiBaseUrl + "tenant";
  }

  async get(tenantId) {
    return axiosRequest(axios.get(`${this.apiBase}/settings`, { params: { tenantId } }));
  }

  async update(tenantId, settings) {
    return axiosRequest(axios.post(`${this.apiBase}/settings/update`, { tenantId, settings }));
  }
}

const tenantSettingsService = new TenantSettingsService();
export default tenantSettingsService;
