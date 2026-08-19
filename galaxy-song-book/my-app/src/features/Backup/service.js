import axios, { axiosRequest } from '../../helpers/axiosMiddleware';
import config from '../../config/config';

class BackupService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'backup';
  }

  async getModules() {
    return axiosRequest(axios.get(`${this.apiBase}/modules`));
  }

  async exportBackup(scope, moduleCodes) {
    return axiosRequest(
      axios.post(`${this.apiBase}/export`, { scope, moduleCodes }, { responseType: 'blob' }),
      { message: 'Preparing export...' }
    );
  }

  async previewRestore(file, scope, moduleCodes) {
    const form = new FormData();
    form.append('file', file);
    form.append('scope', scope);
    form.append('moduleCodes', JSON.stringify(moduleCodes || []));
    return axiosRequest(
      axios.post(`${this.apiBase}/restore/preview`, form, { headers: { 'Content-Type': 'multipart/form-data' } }),
      { message: 'Reading backup...' }
    );
  }

  async applyRestore(token, scope, moduleCodes) {
    return axiosRequest(
      axios.post(`${this.apiBase}/restore/apply`, { token, scope, moduleCodes }),
      { message: 'Restoring...' }
    );
  }
}

export default new BackupService();
