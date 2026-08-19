import axios, { axiosRequest } from "../../helpers/axiosMiddleware";
import config from "../../config/config";

class CompanyService {
  constructor() {
    this.apiBase = config.apiBaseUrl + "company";
  }

  async getPrint() {
    const res = await axiosRequest(axios.get(`${this.apiBase}/get-print`));
    return res;
  }
}

const companyServiceInstance = new CompanyService();
export default companyServiceInstance;
