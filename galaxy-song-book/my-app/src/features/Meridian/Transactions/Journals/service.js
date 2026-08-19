import axios, { axiosRequest } from '../../../../helpers/axiosMiddleware';
import config from '../../../../config/config';

class JournalsService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'gl/ledger';
  }

  async getAll() {
    return axiosRequest(axios.get(`${this.apiBase}/get-all`));
  }

  async get(transactionId) {
    return axiosRequest(axios.get(`${this.apiBase}/get`, { params: { transactionId } }));
  }

  async update(param) {
    return axiosRequest(axios.post(`${this.apiBase}/update`, param));
  }

  async delete(transactionId) {
    return axiosRequest(axios.post(`${this.apiBase}/delete`, { transactionId }));
  }
}

const JournalsServiceInstance = new JournalsService();
export default JournalsServiceInstance;
