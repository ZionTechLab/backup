import axios, { axiosRequest } from "../../../../helpers/axiosMiddleware";
import config from "../../../../config/config";

class CurrencyService {
  constructor() {
    this.apiBase = config.apiBaseUrl + "currency";
  }

  async getAll() {
    return axiosRequest(axios.get(`${this.apiBase}/get-all`));
  }

  async get(id) {
    return axiosRequest(axios.get(`${this.apiBase}/get`, { params: { id } }));
  }

  async update(param) {
    return axiosRequest(axios.post(`${this.apiBase}/update`, param));
  }

  async delete(id) {
    return axiosRequest(axios.delete(`${this.apiBase}/delete`, { params: { id } }));
  }
}

const currencyService = new CurrencyService();
export default currencyService;
