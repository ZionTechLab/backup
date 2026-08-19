import axios, { axiosRequest } from '../../../../helpers/axiosMiddleware';
import config from '../../../../config/config';

class FinancialMonthService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'gl/financial-month';
  }

  async getAll(companyId) {
    return axiosRequest(axios.get(`${this.apiBase}/get-all`));
  }

  async update(param) {
    return axiosRequest(axios.post(`${this.apiBase}/update`, param));
  }
}

const FinancialMonthServiceInstance = new FinancialMonthService();
export default FinancialMonthServiceInstance;
