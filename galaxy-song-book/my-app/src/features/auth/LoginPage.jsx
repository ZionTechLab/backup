import { useState } from "react";
import { Navigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { useFormik } from "formik";
import * as Yup from "yup";
import { loginAsync, selectIsLoggedIn, selectAuthError } from "../auth";
import config from "../../config/config";
import { brand } from "../../config/brand";
import "./meridian-login.css";

const GoogleIcon = () => (
  <svg width="16" height="16" viewBox="0 0 48 48" aria-hidden="true">
    <path fill="#FFC107" d="M43.6 20.5H42V20H24v8h11.3c-1.6 4.7-6.1 8-11.3 8-6.6 0-12-5.4-12-12s5.4-12 12-12c3.1 0 5.8 1.2 7.9 3.1l5.7-5.7C34 6.1 29.3 4 24 4 12.9 4 4 12.9 4 24s8.9 20 20 20 20-8.9 20-20c0-1.3-.1-2.4-.4-3.5z"/>
    <path fill="#FF3D00" d="M6.3 14.7l6.6 4.8C14.7 16 19 13 24 13c3.1 0 5.8 1.2 7.9 3.1l5.7-5.7C34 6.1 29.3 4 24 4 16.3 4 9.6 8.3 6.3 14.7z"/>
    <path fill="#4CAF50" d="M24 44c5.2 0 9.9-2 13.4-5.2l-6.2-5.2c-2 1.5-4.5 2.4-7.2 2.4-5.2 0-9.6-3.3-11.3-7.9l-6.5 5C9.5 39.6 16.2 44 24 44z"/>
    <path fill="#1976D2" d="M43.6 20.5H42V20H24v8h11.3c-.8 2.3-2.2 4.2-4.1 5.6l6.2 5.2c-.4.4 6.6-4.8 6.6-14.8 0-1.3-.1-2.4-.4-3.5z"/>
  </svg>
);

const MicrosoftIcon = () => (
  <svg width="16" height="16" viewBox="0 0 23 23" aria-hidden="true">
    <path fill="#F25022" d="M1 1h10v10H1z"/>
    <path fill="#7FBA00" d="M12 1h10v10H12z"/>
    <path fill="#00A4EF" d="M1 12h10v10H1z"/>
    <path fill="#FFB900" d="M12 12h10v10H12z"/>
  </svg>
);

const AppleIcon = () => (
  <svg width="16" height="16" viewBox="0 0 24 24" fill="currentColor" aria-hidden="true">
    <path d="M16.365 1.43c0 1.14-.493 2.27-1.177 3.08-.744.9-1.99 1.57-2.987 1.49-.12-1.17.486-2.4 1.158-3.18.756-.9 2.077-1.55 3.006-1.39zM20.5 17.04c-.55 1.27-.815 1.83-1.526 2.95-1.005 1.56-2.422 3.5-4.177 3.51-1.56.01-1.96-1.01-4.075-1-2.115.01-2.555 1.02-4.115 1.01-1.755-.02-3.098-1.77-4.103-3.33C-.197 16.41-.5 11.05 1.78 8.28c1.587-1.92 4.085-3.05 6.43-3.05 2.396 0 3.905 1.31 5.882 1.31 1.92 0 3.09-1.31 5.86-1.31 2.105 0 4.34 1.15 5.94 3.13-5.22 2.86-4.37 10.32-2.39 8.68z"/>
  </svg>
);

function handleSsoLogin(provider) {
  // Backend kicks off the OAuth dance and redirects back to /auth/callback?code=&provider=
  // Contract: GET {apiBaseUrl}auth/sso/{provider}?redirect={frontendOrigin}/auth/callback
  const redirect = encodeURIComponent(`${window.location.origin}/auth/callback`);
  window.location.href = `${config.apiBaseUrl}auth/sso/${provider}?redirect=${redirect}`;
}

const FX_ITEMS = [
  { pair: "EUR/USD", rate: "1.0842", delta: "+0.47%", up: true  },
  { pair: "GBP/USD", rate: "1.2731", delta: "+1.41%", up: true  },
  { pair: "SGD/USD", rate: "0.7384", delta: "+0.86%", up: true  },
  { pair: "USD/JPY", rate: "154.22", delta: "-0.21%", up: false },
  { pair: "EUR/GBP", rate: "0.8516", delta: "-0.94%", up: false },
  { pair: "AUD/USD", rate: "0.6582", delta: "+0.33%", up: true  },
  { pair: "CHF/USD", rate: "1.0944", delta: "+0.12%", up: true  },
  { pair: "CAD/USD", rate: "0.7281", delta: "-0.08%", up: false },
];

function FxTape() {
  const tape = [...FX_ITEMS, ...FX_ITEMS];
  return (
    <div className="ml-fx-tape">
      <div className="ml-fx-tape-inner">
        {tape.map((item, i) => (
          <span key={i} className="ml-fx-item">
            <span className="ml-fx-pair">{item.pair}</span>
            <span className="ml-fx-rate">{item.rate}</span>
            <span className={item.up ? "ml-fx-up" : "ml-fx-down"}>{item.delta}</span>
          </span>
        ))}
      </div>
    </div>
  );
}

function Pillar({ value, label, sublabel }) {
  return (
    <div className="ml-pillar">
      <div className="ml-pillar-value">{value}</div>
      <div className="ml-pillar-label">{label}</div>
      <div className="ml-pillar-sub">{sublabel}</div>
    </div>
  );
}

function BrandPanel() {
  return (
    <div className="ml-brand-panel">
      <div className="ml-dot-grid" />
      <div className="ml-glow" />

      <div className="ml-brand-logo">
        {brand.logo ? (
          <img className="ml-logo-img" src={brand.logo} alt={brand.name} />
        ) : (
          <div className="ml-logo-mark">{brand.logoMark}</div>
        )}
        <div>
          <div className="ml-logo-name">{brand.name}</div>
          <div className="ml-logo-sub">{brand.sub}</div>
        </div>
      </div>

      <div className="ml-brand-content">
        <div className="ml-eyebrow">{brand.login.eyebrow}</div>
        <h1 className="ml-headline">
          {brand.login.headline}<br />
          <span className="ml-headline-dim">{brand.login.headlineDim}</span>
        </h1>
        <p className="ml-subhead">
          {brand.login.subhead}
        </p>
        <div className="ml-pillars">
          <Pillar value="4"   label="Entities"       sublabel="USD · GBP · EUR · SGD" />
          <Pillar value="148" label="Posted entries"  sublabel="May 2026 · YTD" />
          <Pillar value="98%" label="Auto-reconciled" sublabel="Last 30 days" />
        </div>
      </div>

      <FxTape />

      <div className="ml-brand-footer">
        <span>{brand.footerText}</span>
        <div className="ml-brand-links">
          <a href="#security" onClick={(e) => e.preventDefault()}>Security</a>
          <a href="#soc2"     onClick={(e) => e.preventDefault()}>SOC 2</a>
          <a href="#status"   onClick={(e) => e.preventDefault()}>Status</a>
        </div>
      </div>
    </div>
  );
}

const EyeIcon = ({ open }) =>
  open ? (
    <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
      <path d="M17.94 17.94A10.07 10.07 0 0 1 12 20c-7 0-11-8-11-8a18.45 18.45 0 0 1 5.06-5.94M9.9 4.24A9.12 9.12 0 0 1 12 4c7 0 11 8 11 8a18.5 18.5 0 0 1-2.16 3.19m-6.72-1.07a3 3 0 1 1-4.24-4.24"/>
      <line x1="1" y1="1" x2="23" y2="23"/>
    </svg>
  ) : (
    <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
      <path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"/>
      <circle cx="12" cy="12" r="3"/>
    </svg>
  );

const validationSchema = Yup.object({
  userName: Yup.string()
    .min(2, "Must be at least 2 characters")
    .matches(/^[a-zA-Z\s]*$/, "Only letters and spaces are allowed")
    .required("Username is required"),
  password: Yup.string()
    .min(4, "Password must be at least 4 characters")
    .required("Password is required"),
});

function LoginPage() {
  const dispatch   = useDispatch();
  const isLoggedIn = useSelector(selectIsLoggedIn);
  const authError  = useSelector(selectAuthError);
  const [showPw, setShowPw] = useState(false);

  const formik = useFormik({
    initialValues: { userName: "", password: "" },
    validationSchema,
    onSubmit: async (values) => {
      await dispatch(loginAsync(values));
    },
  });

  if (isLoggedIn) {
    return <Navigate to="/" replace />;
  }

  const userNameError = formik.touched.userName && formik.errors.userName;
  const passwordError = formik.touched.password && formik.errors.password;

  return (
    <div className="ml-login-page">
      <BrandPanel />

      <div className="ml-form-panel">
        <div className="ml-form-inner">

          {/* Compact brand header — mobile only */}
          <div className="ml-mobile-brand">
            {brand.logo ? (
              <img className="ml-logo-img-sm" src={brand.logo} alt={brand.name} />
            ) : (
              <div className="ml-logo-mark-sm">{brand.logoMark}</div>
            )}
            <div className="ml-mobile-brand-name">{brand.name}</div>
          </div>

          <div className="ml-form-header">
            <h2 className="ml-form-title">Sign in</h2>
            <p className="ml-form-sub">
              Welcome back. Enter your credentials to continue to your portal.
            </p>
          </div>

          <form onSubmit={formik.handleSubmit} noValidate>
            {/* Username */}
            <div className="ml-field">
              <label className="ml-label" htmlFor="userName">Username</label>
              <input
                id="userName"
                type="text"
                className={`ml-input${userNameError ? " ml-input-error" : ""}`}
                placeholder="Your username"
                {...formik.getFieldProps("userName")}
              />
              {userNameError && <div className="ml-error-msg">{userNameError}</div>}
            </div>

            {/* Password */}
            <div className="ml-field">
              <div className="ml-label-row">
                <label className="ml-label" htmlFor="password">Password</label>
                <a href="#forgot" className="ml-forgot" onClick={(e) => e.preventDefault()}>
                  Forgot password?
                </a>
              </div>
              <div className="ml-input-wrap">
                <input
                  id="password"
                  type={showPw ? "text" : "password"}
                  className={`ml-input ml-input-pw${passwordError ? " ml-input-error" : ""}`}
                  placeholder="Your password"
                  {...formik.getFieldProps("password")}
                />
                <button
                  type="button"
                  className="ml-eye-btn"
                  onClick={() => setShowPw((v) => !v)}
                  aria-label={showPw ? "Hide password" : "Show password"}
                >
                  <EyeIcon open={showPw} />
                </button>
              </div>
              {passwordError && <div className="ml-error-msg">{passwordError}</div>}
            </div>

            {/* Remember me */}
            <label className="ml-checkbox-label">
              <input type="checkbox" className="ml-checkbox" defaultChecked />
              <span>Keep me signed in on this device</span>
            </label>

            {/* Auth error from Redux */}
            {authError && <div className="ml-auth-error">{authError}</div>}

            {/* Submit */}
            <button type="submit" className="ml-btn-primary" disabled={formik.isSubmitting}>
              {formik.isSubmitting ? (
                <>
                  <span className="ml-spinner" />
                  Signing in...
                </>
              ) : (
                <>Sign In <span className="ml-arrow">→</span></>
              )}
            </button>

            {/* OR / SSO */}
            {config.features.sso?.enabled && (
              <>
                <div className="ml-divider">
                  <span className="ml-divider-line" />
                  <span className="ml-divider-text">or continue with</span>
                  <span className="ml-divider-line" />
                </div>

                <div className="ml-sso-grid">
                  {config.features.sso.google && (
                    <button
                      type="button"
                      className="ml-btn-sso-icon"
                      onClick={() => handleSsoLogin("google")}
                      aria-label="Continue with Google"
                    >
                      <GoogleIcon />
                      <span>Google</span>
                    </button>
                  )}
                  {config.features.sso.microsoft && (
                    <button
                      type="button"
                      className="ml-btn-sso-icon"
                      onClick={() => handleSsoLogin("microsoft")}
                      aria-label="Continue with Microsoft"
                    >
                      <MicrosoftIcon />
                      <span>Microsoft</span>
                    </button>
                  )}
                  {config.features.sso.apple && (
                    <button
                      type="button"
                      className="ml-btn-sso-icon ml-btn-sso-apple"
                      onClick={() => handleSsoLogin("apple")}
                      aria-label="Continue with Apple"
                    >
                      <AppleIcon />
                      <span>Apple</span>
                    </button>
                  )}
                </div>
              </>
            )}
          </form>

          <div className="ml-status-footer">
            <span className="ml-status-ok">
              <span className="ml-status-dot" />
              All systems operational
            </span>
            <span>v4.2 · build 2026.05.22</span>
          </div>

        </div>
      </div>
    </div>
  );
}

export default LoginPage;
