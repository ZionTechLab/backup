import axios, { axiosRequest } from "../../../../helpers/axiosMiddleware";
import config from "../../../../config/config";


class CompaniesService {
    constructor() {
    this.apiBase = config.apiBaseUrl + "company";
  }

  	async getUi() {
		const res = await axiosRequest(axios.get(`${this.apiBase}/get-ui`));
		return res;
	}
  
 async getAll(txnType) {
    const res = await axiosRequest(
      axios.get(`${this.apiBase}/get-all`, { params: { txnType } })
    );
    return res;
  }

  async get(id, txnType) {
    const res = await axiosRequest(
      axios.get(`${this.apiBase}/get`, { params: { id, txnType } })
    );
    return res;
  }

  async update(param) {
    return axiosRequest(axios.post(`${this.apiBase}/update`, param));
  }

  async delete(id) {
    return axiosRequest(axios.post(`${this.apiBase}/delete`, { companyId: id }));
  }

  async listUsers(companyId) {
    return axiosRequest(axios.get(`${this.apiBase}/users`, { params: { companyId } }));
  }

  async addUser(param) {
    return axiosRequest(axios.post(`${this.apiBase}/users/add`, param));
  }

  async removeUser(id) {
    return axiosRequest(axios.post(`${this.apiBase}/users/remove`, { id }));
  }

  async setDefaultUser(id) {
    return axiosRequest(axios.post(`${this.apiBase}/users/set-default`, { id }));
  }

  async countOtherCompanies(id) {
    return axiosRequest(axios.get(`${this.apiBase}/users/count-other`, { params: { id } }));
  }

  async setMyDefault(companyId) {
    return axiosRequest(axios.post(`${this.apiBase}/users/set-my-default`, { companyId }));
  }
}

const companiesService = new CompaniesService();
export default companiesService;
