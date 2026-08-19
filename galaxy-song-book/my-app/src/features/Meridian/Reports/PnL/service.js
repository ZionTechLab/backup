import axios, { axiosRequest } from '../../../../helpers/axiosMiddleware';
import config from '../../../../config/config';

class PnLService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'gl/reports';
  }

  async get(fromDate, toDate) {
    return axiosRequest(axios.post(`${this.apiBase}/pnl`, { fromDate, toDate }));
  }
}

const PnLServiceInstance = new PnLService();
export default PnLServiceInstance;
