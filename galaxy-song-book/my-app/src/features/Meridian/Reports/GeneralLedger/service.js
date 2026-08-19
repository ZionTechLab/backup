import axios, { axiosRequest } from '../../../../helpers/axiosMiddleware';
import config from '../../../../config/config';

class GeneralLedgerService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'gl/general-ledger';
  }

  async getAccounts() {
    return axiosRequest(axios.get(`${config.apiBaseUrl}gl/reports/get-accounts`));
  }

  async getReport(accountId, fromDate, toDate) {
    return axiosRequest(axios.post(`${config.apiBaseUrl}gl/reports/get-report`, { accountId, fromDate, toDate }));
  }
}

const GeneralLedgerServiceInstance = new GeneralLedgerService();
export default GeneralLedgerServiceInstance;
