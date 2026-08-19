import axios, { axiosRequest } from '../../../helpers/axiosMiddleware';
import config from '../../../config/config';

const BASE = config.apiBaseUrl + 'petty-cash/reports';

class PcReportsService {
  async iouRegister(filters = {}) {
    return axiosRequest(axios.post(`${BASE}/iou-register`, filters));
  }

  async iouAging(filters = {}) {
    return axiosRequest(axios.post(`${BASE}/iou-aging`, filters));
  }

  async partyOutstanding() {
    return axiosRequest(axios.post(`${BASE}/party-outstanding`));
  }

  async cashBookBalances() {
    return axiosRequest(axios.post(`${BASE}/cashbook-balances`));
  }

  async managerDashboard(filters = {}) {
    return axiosRequest(axios.post(`${BASE}/manager-dashboard`, filters));
  }
}

export default new PcReportsService();
