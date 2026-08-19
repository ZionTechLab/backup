import axios, { axiosRequest } from '../../helpers/axiosMiddleware';
import config from '../../config/config';

class WorkflowService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'workflow';
  }

  async getOptions() {
    return axiosRequest(axios.get(`${this.apiBase}/config/options`));
  }

  async getAll() {
    return axiosRequest(axios.get(`${this.apiBase}/config/get-all`));
  }

  async get(id) {
    return axiosRequest(axios.get(`${this.apiBase}/config/get`, { params: { id } }));
  }

  async save(payload) {
    return axiosRequest(axios.post(`${this.apiBase}/config/save`, payload));
  }

  async delete(id) {
    return axiosRequest(axios.post(`${this.apiBase}/config/delete`, { id }));
  }

  async getInbox() {
    return axiosRequest(axios.get(`${this.apiBase}/inbox`));
  }

  async getDoc(docType, docId) {
    return axiosRequest(axios.get(`${this.apiBase}/doc`, { params: { docType, docId } }));
  }
}

export default new WorkflowService();
