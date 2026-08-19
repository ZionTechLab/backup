import axios, { axiosRequest } from "../../helpers/axiosMiddleware";
import config from "../../config/config";

class AuditLogService {
  constructor() {
    this.apiBase = config.apiBaseUrl + "audit";
  }

  async getSummary(params) {
    return axiosRequest(axios.get(`${this.apiBase}/summary`, { params }));
  }

  async getAll(params) {
    return axiosRequest(axios.get(`${this.apiBase}/get-all`, { params }));
  }

  async getRecord(params) {
    return axiosRequest(axios.get(`${this.apiBase}/get-record`, { params }));
  }
}

const auditLogService = new AuditLogService();
export default auditLogService;
