import LoadingSpinnerService from "../services/LoadingSpinnerService";
import { handleAxiosError } from "./axiosErrorHandler";

export async function axiosRequest(requestPromise, options = {}) {
  const { showSpinner = true, message = "Loading..." } = options;

  try {
    if (showSpinner) LoadingSpinnerService.show(message);

    const res = await requestPromise;

    return {
      data: res.data,
      error: null,
      success: true,
    };
  } catch (error) {
    const errorMessage = handleAxiosError(error);
    return {
      data: null,
      error: errorMessage,
      success: false,
    };
  } finally {
    if (showSpinner) LoadingSpinnerService.hide();
  }
}

export default axiosRequest;
