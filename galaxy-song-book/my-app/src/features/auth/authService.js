import axios, { axiosRequest } from '../../helpers/axiosMiddleware';
import config from '../../config/config';

class AuthService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'auth';
  }

  async login(credentials) {
    const res = await axiosRequest(
      axios.post(`${this.apiBase}/login`, credentials)
    );
    return res;
  }

  async logout() {
    const res = await axiosRequest(
      axios.post(`${this.apiBase}/logout`)
    );
    return res;
  }

  async getCurrentUser() {
    const res = await axiosRequest(
      axios.get(`${this.apiBase}/me`)
    );
    return res;
  }

  async refreshToken(refreshToken) {
    try {
      const res = await axios.post(
        `${this.apiBase}/refresh`,
        { refreshToken },
        { _skipAuth: true }
      );
      return { data: res.data, success: true };
    } catch (error) {
      return { data: null, success: false, error: error.message || "Refresh failed" };
    }
  }

  async changePassword(passwordData) {
    const res = await axiosRequest(
      axios.post(`${this.apiBase}/change-password`, passwordData)
    );
    return res;
  }

  async ssoExchange({ code, provider }) {
    const res = await axiosRequest(
      axios.post(`${this.apiBase}/sso/exchange`, { code, provider }, { _skipAuth: true })
    );
    return res;
  }

  async init(userID) {
    const res = await axiosRequest(
      axios.get(`${this.apiBase}/init`, { params: { userID } })
    );
    return res;
  }
}

const AuthServiceInstance = new AuthService();
export default AuthServiceInstance;
