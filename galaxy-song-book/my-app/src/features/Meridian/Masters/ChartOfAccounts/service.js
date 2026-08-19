import axios, { axiosRequest } from '../../../../helpers/axiosMiddleware';
import config from '../../../../config/config';

class ChartOfAccountsService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'gl/chart-of-accounts';
  }

  async getAll() {
    return axiosRequest(axios.get(`${this.apiBase}/get-all`));
  }

  async get(accountId) {
    return axiosRequest(axios.get(`${this.apiBase}/get`, { params: { accountId } }));
  }

  async update(param) {
    return axiosRequest(axios.post(`${this.apiBase}/update`, param));
  }

  async delete(accountId) {
    return axiosRequest(axios.post(`${this.apiBase}/delete`, { accountId }));
  }
}

const ChartOfAccountsServiceInstance = new ChartOfAccountsService();
export default ChartOfAccountsServiceInstance;
