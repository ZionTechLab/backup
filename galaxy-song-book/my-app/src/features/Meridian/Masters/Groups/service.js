import axios, { axiosRequest } from "../../../../helpers/axiosMiddleware";
import config from "../../../../config/config";

class GroupService {
  constructor() {
    this.apiBase = config.apiBaseUrl + "group";
  }

  async getAll() {
    return axiosRequest(axios.get(`${this.apiBase}/get-all`));
  }

  async get(groupId) {
    return axiosRequest(axios.get(`${this.apiBase}/get`, { params: { groupId } }));
  }

  async update(param) {
    return axiosRequest(axios.post(`${this.apiBase}/update`, param));
  }

  async delete(groupId) {
    return axiosRequest(axios.post(`${this.apiBase}/delete`, { groupId }));
  }
}

const groupService = new GroupService();
export default groupService;
