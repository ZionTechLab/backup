import axios, { axiosRequest } from '../../../../helpers/axiosMiddleware';
import config from '../../../../config/config';

class ConsolidatedPnLService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'gl/group/pnl';
  }

  async get(period) {
    return axiosRequest(axios.get(`${this.apiBase}/get`, { params: { period } }));
  }
}

const ConsolidatedPnLServiceInstance = new ConsolidatedPnLService();
export default ConsolidatedPnLServiceInstance;
