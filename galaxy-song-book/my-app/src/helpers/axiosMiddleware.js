// Compatibility barrel for existing imports.
// The implementation is split into smaller modules:
// - ./axiosErrorHandler.js -> exports handleAxiosError
// - ./axiosInterceptors.js -> registers request interceptors and exports default axios
// - ./axiosRequest.js -> exports axiosRequest wrapper
// Existing code imports `axios, { axiosRequest } from '../helpers/axiosMiddleware'`.
// To avoid touching all consumers, re-export the same surface area here.

import axios from "./axiosInterceptors"; // already registers interceptors
export { default as axiosRequest } from "./axiosRequest";
export { handleAxiosError } from "./axiosErrorHandler";
export default axios;
