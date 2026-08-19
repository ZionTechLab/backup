import axios, { axiosRequest } from '../../helpers/axiosMiddleware';
import config from '../../config/config';

class WalletService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'wallet';
  }

  async getSummary() {
    return axiosRequest(axios.get(`${this.apiBase}/summary`));
  }

  async getMonthlyTopups() {
    return axiosRequest(axios.get(`${this.apiBase}/monthly-topups`));
  }

  async getPaymentJournal() {
    return axiosRequest(axios.get(`${this.apiBase}/payment-journal`));
  }

  async addTopup(amount, narration) {
    return axiosRequest(axios.post(`${this.apiBase}/topup`, { amount, narration }));
  }
}

// --- Mock data for prototyping ---
const mockSummary = {
  availableBalance: 12450.0,
  monthlyTopup: 3500.0,
  totalTopups: 45000.0,
  ytdTopups: 18500.0,
};

const mockMonthlyTopups = [
  { month: 'Jan', amount: 1200 },
  { month: 'Feb', amount: 1900 },
  { month: 'Mar', amount: 1500 },
  { month: 'Apr', amount: 2200 },
  { month: 'May', amount: 1800 },
  { month: 'Jun', amount: 2500 },
  { month: 'Jul', amount: 3500 },
  { month: 'Aug', amount: 2800 },
  { month: 'Sep', amount: 2400 },
  { month: 'Oct', amount: 3100 },
  { month: 'Nov', amount: 2900 },
  { month: 'Dec', amount: 3500 },
];

// Payment journal with running balance (openBal / closeBal)
// Only top-ups shown; deductions handled by other modules, not shown here
const mockJournal = [
  { date: '2026-07-18', txnRef: 'TXN-001045', txnUrl: '#', type: 'Credit', narration: 'July top-up', openBal: 10950.00, amount: 1500.00, closeBal: 12450.00 },
  { date: '2026-07-14', txnRef: 'TXN-001032', txnUrl: '#', type: 'Debit', narration: 'Monthly subscription', openBal: 12000.00, amount: -1050.00, closeBal: 10950.00 },
  { date: '2026-07-12', txnRef: 'TXN-001018', txnUrl: '#', type: 'Credit', narration: 'Top-up via bank transfer', openBal: 9500.00, amount: 2500.00, closeBal: 12000.00 },
  { date: '2026-07-05', txnRef: 'TXN-000997', txnUrl: '#', type: 'Debit', narration: 'API usage charges', openBal: 9750.00, amount: -250.00, closeBal: 9500.00 },
  { date: '2026-07-01', txnRef: 'TXN-000985', txnUrl: '#', type: 'Credit', narration: 'Opening top-up', openBal: 0.00, amount: 9750.00, closeBal: 9750.00 },
];

const useMock = true;

const delay = (ms) => new Promise((r) => setTimeout(r, ms));

class MockWalletService {
  async getSummary() {
    await delay(300);
    return { success: true, data: mockSummary };
  }
  async getMonthlyTopups() {
    await delay(300);
    return { success: true, data: mockMonthlyTopups };
  }
  async getPaymentJournal() {
    await delay(300);
    return { success: true, data: mockJournal };
  }
  async addTopup(amount, narration) {
    await delay(400);
    return { success: true, data: { amount, narration, balance: mockSummary.availableBalance + amount } };
  }
}

export default useMock ? new MockWalletService() : new WalletService();
