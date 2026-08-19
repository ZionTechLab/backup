import axios, { axiosRequest } from '../../../../helpers/axiosMiddleware';
import config from '../../../../config/config';

class BalanceSheetService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'gl/reports';
  }

  async get(asOf) {
    return axiosRequest(axios.post(`${this.apiBase}/balance-sheet`, { asOf }));
  }
}

const BalanceSheetServiceInstance = new BalanceSheetService();
export default BalanceSheetServiceInstance;
