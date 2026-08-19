import React from "react";
import { useNavigate } from "react-router-dom";

const NotFound = () => {
  const navigate = useNavigate();

  const goHome = () => navigate("/");
  const goBack = () => navigate(-1);

  return (
    <div className="container py-5 page-narrow">
      <div className="text-center">
        <div className="mb-3 page-error-code">
          404
        </div>
        <h1 className="h3 fw-bold">Page Not Found</h1>
        <p className="text-muted mt-2">
          The page you're looking for doesn't exist or has been moved.
        </p>

        <div className="d-flex gap-2 justify-content-center mt-4">
          <button type="button" className="btn btn-primary" onClick={goHome}>
            Go Home
          </button>
          <button type="button" className="btn btn-outline-secondary" onClick={goBack}>
            Go Back
          </button>
        </div>
      </div>
    </div>
  );
};

export default NotFound;
