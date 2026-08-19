import axios, { axiosRequest } from '../helpers/axiosMiddleware';
import config from '../config/config';

// Shared single-file upload. Posts to the central files/upload endpoint and
// returns { success, data: { filename } }. Any feature that stores attachments
// uses this instead of copying an uploadFile method into its own service.
export async function uploadFile(file) {
  const form = new FormData();
  form.append('file', file);
  return axiosRequest(axios.post(`${config.apiBaseUrl}files/upload`, form, {
    headers: { 'Content-Type': 'multipart/form-data' },
  }));
}

// Public URL for a stored file name.
export const fileUrl = (name) => (name ? config.apiBaseUrl + 'uploads/' + name : '');
