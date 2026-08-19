import axios, { axiosRequest } from '../../helpers/axiosMiddleware';
import config from '../../config/config';

class UserService {
  constructor() {
         this.apiBase = config.apiBaseUrl+'users';
  }

  	async getUi() {
		const res = await axiosRequest(axios.get(`${this.apiBase}/get-ui`));
		return res;
	}
  
  async update(param) {
    const res = await axiosRequest(axios.post(`${this.apiBase}/update`, param));
    return res;
  }

  async get(userId) {
      const res = await axiosRequest(axios.get(`${this.apiBase}/get`, { params: { userId } }));
    return res;
  }

  async getAll() {
    const res = await axiosRequest(axios.get(`${this.apiBase}/get-all`));
    return res;
  }

  async delete(param) {
    const res = await axiosRequest(axios.post(`${this.apiBase}/delete`, param));
    return res;
  }
}

const UserServiceInstance = new UserService();
export default UserServiceInstance;