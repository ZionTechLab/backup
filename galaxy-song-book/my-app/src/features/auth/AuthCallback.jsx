import { useEffect, useRef, useState } from "react";
import { Navigate, useSearchParams } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { ssoCallbackAsync, selectIsLoggedIn, selectAuthError } from "../auth";
import "./meridian-login.css";

function AuthCallback() {
  const dispatch = useDispatch();
  const [params] = useSearchParams();
  const isLoggedIn = useSelector(selectIsLoggedIn);
  const authError = useSelector(selectAuthError);
  const [localError, setLocalError] = useState(null);
  const ran = useRef(false);

  const code = params.get("code");
  const provider = params.get("provider");
  const errorParam = params.get("error");

  useEffect(() => {
    if (ran.current) return;
    ran.current = true;

    if (errorParam) {
      setLocalError(decodeURIComponent(errorParam));
      return;
    }
    if (!code || !provider) {
      setLocalError("Missing SSO code or provider.");
      return;
    }
    dispatch(ssoCallbackAsync({ code, provider }));
  }, [dispatch, code, provider, errorParam]);

  if (isLoggedIn) {
    return <Navigate to="/" replace />;
  }

  const message = localError || authError;
  if (message) {
    return (
      <div className="ml-form-panel ml-min-vh-100">
        <div className="ml-form-inner">
          <div className="ml-form-header">
            <h2 className="ml-form-title">Sign-in failed</h2>
            <p className="ml-form-sub">{message}</p>
          </div>
          <a href="/login" className="ml-btn-primary text-decoration-none">
            Back to sign in
          </a>
        </div>
      </div>
    );
  }

  return (
    <div className="ml-form-panel ml-min-vh-100">
      <div className="ml-form-inner text-center">
        <span className="ml-spinner ml-spinner-block" />
        <div className="ml-form-title ml-auth-loading-title">Completing sign in...</div>
        <div className="ml-form-sub">Verifying your {provider || "SSO"} session.</div>
      </div>
    </div>
  );
}

export default AuthCallback;
