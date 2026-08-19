import axios, { axiosRequest } from '../../helpers/axiosMiddleware';
import config from '../../config/config';

class JobRegistrationService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'job';
  }

  async getUi() {
    const res = await axiosRequest(
      axios.get(`${this.apiBase}/get-ui`)
    );
    return res;
  }

  async update(param) {
    return await axiosRequest(axios.post(`${this.apiBase}/update`, param));
  }

  async get(id) {
    return await axiosRequest(axios.get(`${this.apiBase}/get`, { params: { id } }));
  }
  async getPrint(id) {
    return await axiosRequest(axios.get(`${this.apiBase}/getPrint`, { params: { id } }));
  }
  async getAll() {
    return await axiosRequest(axios.get(`${this.apiBase}/get-all`, { params: { id: null } }));
  }

  async delete(param) {
    return await axiosRequest(axios.post(`${this.apiBase}/delete`, param));
  }
}

const JobRegistrationServiceInstance = new JobRegistrationService();
export default JobRegistrationServiceInstance;
