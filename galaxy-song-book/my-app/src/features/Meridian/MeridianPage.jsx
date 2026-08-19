import { useNavigate } from "react-router-dom";
import "./meridian-screens.css";

// Standard Galaxy screen chrome: page header + card shell.
// Screens supply a title and their content (table, form, etc).
// Optionally add a back button, action buttons, or use a different card class.
export default function MeridianPage({ title, subtitle, backTo, actions, cardClass = "ml-screen-card overflow-hidden", children }) {
  const navigate = useNavigate();

  return (
    <div className="ml-screen ml-screen-pad">
      <div className="ml-page-header">
        <div className="ml-page-header-left">
          {backTo && (
            <button
              className="ml-back-btn"
              onClick={() => navigate(backTo)}
              type="button"
            >
              <i className="bi bi-arrow-left" aria-hidden="true" />
              Back
            </button>
          )}
          <h1 className="ml-page-title" style={backTo ? { marginTop: "0.5rem" } : {}}>
            {title}
          </h1>
          {subtitle && <span className="ml-page-subtitle">{subtitle}</span>}
        </div>
        {actions && <div className="ml-page-actions">{actions}</div>}
      </div>

      <div className={cardClass}>{children}</div>
    </div>
  );
}
