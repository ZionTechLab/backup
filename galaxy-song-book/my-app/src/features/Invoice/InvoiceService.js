import axios, { axiosRequest } from "../../helpers/axiosMiddleware";
import config from "../../config/config";

class InvoiceService {
  constructor() {
    this.apiBase = config.apiBaseUrl + "invoice";
  }

  async getUi() {
    const res = await axiosRequest(
      axios.get(`${this.apiBase}/get-ui`)
    );
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

  async delete(param) {
    const res = await axiosRequest(
      axios.post(`${this.apiBase}/delete`, param)
    );
    return res;
  }
  
  async deleteAdvance(param) {
    const res = await axiosRequest(
      axios.post(`${this.apiBase}/delete-advance`, param)
    );
    return res;
  }
  
  async getPrint(id, txnType) {
    const res = await axiosRequest(
      axios.get(`${this.apiBase}/get-print`, { params: { id, txnType } })
    );
    return res;
  }

  async update(param) {
    const res = await axiosRequest(
      axios.post(`${this.apiBase}/update`, param)
    );
    return res;
  }

  async update_advance(param) {
    const res = await axiosRequest(
      axios.post(`${this.apiBase}/update-advance`, param)
    );
    return res;
  }
}
const invoiceServiceInstance = new InvoiceService();
export default invoiceServiceInstance;
