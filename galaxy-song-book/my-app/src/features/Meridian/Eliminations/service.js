import axios, { axiosRequest } from '../../../helpers/axiosMiddleware';
import config from '../../../config/config';

class EliminationsService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'gl/group/eliminations';
  }

  async getAll(period) {
    return axiosRequest(axios.get(`${this.apiBase}/get-all`, { params: { period } }));
  }

  async delete(id) {
    return axiosRequest(axios.post(`${this.apiBase}/delete`, { id }));
  }
}

const EliminationsServiceInstance = new EliminationsService();
export default EliminationsServiceInstance;
