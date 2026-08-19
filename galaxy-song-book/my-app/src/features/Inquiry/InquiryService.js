import axios, { axiosRequest } from '../../helpers/axiosMiddleware';

class InquiryService {
  constructor() {
    this.apiBase = '/api/job';
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

  async save(data) {
    return axiosRequest(axios.post(`${this.apiBase}/update`, data));
  }

  async delete(id) {
    return axiosRequest(axios.post(`${this.apiBase}/delete`, { id }));
  }
}

export default new InquiryService();
