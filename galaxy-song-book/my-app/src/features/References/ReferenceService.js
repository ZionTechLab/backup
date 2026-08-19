import axios, { axiosRequest } from '../../helpers/axiosMiddleware';
import config from '../../config/config';

class ReferenceService {
  constructor() {
         this.apiBase = config.apiBaseUrl+'ref-category';
  }

  	async getUi(category) {
		const res = await axiosRequest(axios.get(`${this.apiBase}/get-ui`, { params: { ...category } }));
		return res;
	}

  async update(param) {
    const res = await axiosRequest(axios.post(`${this.apiBase}/update`, { ...param }));
    return res;
  }

  async get(id, categoryType) {
      const res = await axiosRequest(axios.get(`${this.apiBase}/get`, { params: { id, categoryType } }));
    return res;
  }

  async getAll(category) {
    const res = await axiosRequest(axios.get(`${this.apiBase}/get-all`, { params: { ...category } }));
    return res;
  }

    async delete(id, categoryType) {
    const res = await axiosRequest(axios.post(`${this.apiBase}/delete`, { id, categoryType }));
    return res;
  }
}

const ReferenceServiceInstance = new ReferenceService();
export default ReferenceServiceInstance;