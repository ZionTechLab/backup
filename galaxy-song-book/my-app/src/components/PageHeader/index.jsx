import React from 'react';
import { Link } from 'react-router-dom';

export default function PageHeader({ title, subtitle, breadcrumbs, actions, className = '' }) {
  return (
    <header className={`page-header ${className}`.trim()}>
      <div className="page-header__left">
        {Array.isArray(breadcrumbs) && breadcrumbs.length > 0 && (
          <nav className="page-header__crumbs" aria-label="Breadcrumb">
            {breadcrumbs.map((c, i) => {
              const isLast = i === breadcrumbs.length - 1;
              return (
                <React.Fragment key={`${c.label}-${i}`}>
                  {c.to && !isLast ? (
                    <Link to={c.to}>{c.label}</Link>
                  ) : (
                    <span aria-current={isLast ? 'page' : undefined}>{c.label}</span>
                  )}
                  {!isLast && <span className="sep">/</span>}
                </React.Fragment>
              );
            })}
          </nav>
        )}
        <h1 className="page-header__title">{title}</h1>
        {subtitle && <div className="page-header__subtitle">{subtitle}</div>}
      </div>
      {actions && <div className="page-header__actions">{actions}</div>}
    </header>
  );
}
