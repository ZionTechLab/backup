import axios, { axiosRequest } from '../../helpers/axiosMiddleware';
import config from '../../config/config';

class JobLogService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'job-registration-log';
  }

  async getAll(jobId) {
    // Assuming backend (or mock) returns all logs; filter client-side by jobId if needed
    const res = await axiosRequest(axios.get(`${this.apiBase}/get-all`));
    if (res.success && Array.isArray(res.data) && jobId) {
      return { ...res, data: res.data.filter(r => String(r.jobId) === String(jobId)) };
    }
    return res;
  }

  async get(id) {
    return await axiosRequest(axios.get(`${this.apiBase}/get`, { params: { id } }));
  }

  async update(param) {
    return await axiosRequest(axios.post(`${this.apiBase}/update`, param));
  }

  async delete(param) {
    return await axiosRequest(axios.post(`${this.apiBase}/delete`, param));
  }
}

const JobLogServiceInstance = new JobLogService();
export default JobLogServiceInstance;
