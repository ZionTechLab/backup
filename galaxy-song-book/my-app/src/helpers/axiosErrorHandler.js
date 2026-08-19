import MessageBoxService from "../services/MessageBoxService";

// Centralized axios error handler. Shows a MessageBox and returns a normalized message.
export function handleAxiosError(error) {
  let message;
  let type = "danger";

  if (error.response) {
    const { status, data, statusText } = error.response;

    if (status === 409) {
      type = "warning";
      message = ` ${
        data?.message ||
        data?.error     
      }`;
    } else if (status === 401) {
      type = "warning";
      message = ` ${
        data?.message ||
        data?.error
      }`;
    } else {
      message = ` ${data?.error || statusText || "API error occurred."}`;
    }
  } else if (error.request) {
    message = "Network error. Could not connect to the server.";
    try {
      const currentPath = window.location.pathname;
      const isLoginPage = currentPath === "/login";
      const alreadyOnError = currentPath === "/service-unavailable";
      if (!isLoginPage && !alreadyOnError) {
        window.location.href = "/service-unavailable";
        return message;
      }
    } catch {}
  } else {
    message = `Error: ${error.message}`;
  }

  MessageBoxService.show({
    message,
    type,
    onClose: null,
  });
  return message;
}
