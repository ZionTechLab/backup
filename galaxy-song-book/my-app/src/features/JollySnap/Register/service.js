import axios, { axiosRequest } from '../../../helpers/axiosMiddleware';
import config from '../../../config/config';

class RegisterService {
    constructor() {
        this.apiBase = config.apiBaseUrl + 'jolly-snap';
    }

    async update(data) {
        const res = await axiosRequest(axios.post(`${this.apiBase}/update`, data));
        return res;
    }
    async getUi(category) {
        const res = await axiosRequest(axios.get(`${this.apiBase}/get-ui`, { params: { ...category } }));
        return res;
    }
    async get(id) {
        const res = await axiosRequest(axios.get(`${this.apiBase}/get`, { params: { id } }));
        return res;
    }

    async getAll() {
        const res = await axiosRequest(axios.get(`${this.apiBase}/get-all`));
        return res;
    }

    async delete(param) {
        const res = await axiosRequest(axios.post(`${this.apiBase}/delete`, { param }));
        return res;
    }
}

const RegisterServiceInstance = new RegisterService();
export default RegisterServiceInstance;
