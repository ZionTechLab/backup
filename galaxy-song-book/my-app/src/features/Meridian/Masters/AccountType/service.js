import axios, { axiosRequest } from '../../../../helpers/axiosMiddleware';
import config from '../../../../config/config';

class AccountTypeService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'gl/account-type';
  }

  async getAll() {
    return axiosRequest(axios.get(`${this.apiBase}/get-all`));
  }

  async get(accountType) {
    return axiosRequest(axios.get(`${this.apiBase}/get`, { params: { accountType } }));
  }

  async update(param) {
    return axiosRequest(axios.post(`${this.apiBase}/update`, param));
  }

  async delete(accountType) {
    return axiosRequest(axios.post(`${this.apiBase}/delete`, { accountType }));
  }
}

const AccountTypeServiceInstance = new AccountTypeService();
export default AccountTypeServiceInstance;
