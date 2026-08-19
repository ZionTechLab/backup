import axios, { axiosRequest } from '../../../../helpers/axiosMiddleware';
import config from '../../../../config/config';

class TrialBalanceService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'gl/trial-balance';
  }

  async getTrialBalance(fromDate, toDate) {
    return axiosRequest(axios.post(`${config.apiBaseUrl}gl/reports/trial-balance`, { fromDate, toDate }));
  }
}

const TrialBalanceServiceInstance = new TrialBalanceService();
export default TrialBalanceServiceInstance;
