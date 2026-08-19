import axios, { axiosRequest } from '../../../../helpers/axiosMiddleware';
import config from '../../../../config/config';

class FxVarianceService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'gl/group/fx-variance';
  }

  async get(period) {
    return axiosRequest(axios.get(`${this.apiBase}/get`, { params: { period } }));
  }
}

const FxVarianceServiceInstance = new FxVarianceService();
export default FxVarianceServiceInstance;
