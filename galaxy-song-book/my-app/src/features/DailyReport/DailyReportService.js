import axios, { axiosRequest } from "../../helpers/axiosMiddleware";
import config from "../../config/config";

class DailyReportService {
  constructor() {
    this.apiBase = config.apiBaseUrl + "activitylogs";
  }

  async getUi() {
    const res = await axiosRequest(axios.get(`${this.apiBase}/get-ui`));
    return res;
  }

  async getAll() {
    const res = await axiosRequest(
      axios.get(`${this.apiBase}/get-all`, { params: {} })
    );
    return res;
  }

  async get(id) {
    const res = await axiosRequest(
      axios.get(`${this.apiBase}/get`, { params: { id } })
    );
    return res;
  }

  async update(param) {
    const res = await axiosRequest(axios.post(`${this.apiBase}/update`, param));
    return res;
  }

  async delete(param) {
    const res = await axiosRequest(axios.post(`${this.apiBase}/delete`, param));
    return res;
  }
}

const dailyReportServiceInstance = new DailyReportService();
export default dailyReportServiceInstance;
