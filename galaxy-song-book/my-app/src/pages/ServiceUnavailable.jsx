import React from "react";

const ServiceUnavailable = () => {
  const handleRetry = () => {
    // Simple retry: reload the app so any transient network issues can recover
    window.location.reload();
  };

  const goHome = () => {
    window.location.href = "/";
  };

  return (
    <div className="container py-5 page-narrow">
      <div className="text-center">
        <div className="mb-3">
          <i className="bi bi-wifi-off page-error-icon"></i>
        </div>
        <h1 className="h3 fw-bold">Service Unavailable</h1>
        <p className="text-muted mt-2">
          We can't reach the server right now. This might be due to a network
          issue or the backend being temporarily unavailable.
        </p>

        <div className="d-flex gap-2 justify-content-center mt-4">
          <button type="button" className="btn btn-primary" onClick={handleRetry}>
            Retry
          </button>
          <button type="button" className="btn btn-outline-secondary" onClick={goHome}>
            Go Home
          </button>
        </div>

        <div className="mt-4 small text-muted">
          If the problem persists, please contact your administrator.
        </div>
      </div>
    </div>
  );
};

export default ServiceUnavailable;
