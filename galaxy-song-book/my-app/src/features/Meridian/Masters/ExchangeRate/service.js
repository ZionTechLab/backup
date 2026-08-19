import axios, { axiosRequest } from '../../../../helpers/axiosMiddleware';
import config from '../../../../config/config';

class ExchangeRateService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'exchange-rate';
  }

  async getAll() {
    return axiosRequest(axios.get(`${this.apiBase}/get-all`));
  }

  async getUi() {
    return axiosRequest(axios.get(`${this.apiBase}/get-ui`));
  }

  async get(rateId) {
    return axiosRequest(axios.get(`${this.apiBase}/get`, { params: { rateId } }));
  }

  async update(param) {
    return axiosRequest(axios.post(`${this.apiBase}/update`, param));
  }

  async delete(rateId) {
    return axiosRequest(axios.post(`${this.apiBase}/delete`, { rateId }));
  }
}

const ExchangeRateServiceInstance = new ExchangeRateService();
export default ExchangeRateServiceInstance;
