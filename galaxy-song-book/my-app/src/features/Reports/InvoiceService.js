import axios, { axiosRequest } from '../../helpers/axiosMiddleware';
import config from '../../config/config';

class InvoiceService {
  constructor() {
        this.apiBase = config.apiBaseUrl+'reports';
  }

  	async getUi() {
		const res = await axiosRequest(axios.get(`${this.apiBase}/get-ui`));
		return res;
	}
  
  async getReport(param) {
    const res = await axiosRequest(axios.post(`${this.apiBase}/getReport`, param));
    return res;
  }
}
const invoiceServiceInstance = new InvoiceService();
export default invoiceServiceInstance;
