import { forwardRef, useState, useEffect, useRef, useMemo, memo } from "react";
import { useSelector } from "react-redux";
import { Link, useLocation } from "react-router-dom";
import "./Drawer.css";
import { selectInitData } from "../features/auth";
import { brand } from "../config/brand";

// ---------------------------------------------------------------------------
// Recursive menu item — renders itself for children so depth is unlimited.
// ---------------------------------------------------------------------------
const MenuItem = memo(({ item, depth, isMinimized, isMobile, onClose, openGroups, toggleGroup }) => {
  const location = useLocation();
  const hasChildren = item.children && item.children.length > 0;
  const groupId = item.id ? String(item.id) : item.route || item.displayName;
  const isOpen = openGroups[groupId];
  const indent = "ms-3 border-start border-dark-subtle";

  const isActive = (route) => {
    if (!route || route === "#") return false;
    return location.pathname === route || location.pathname.startsWith(route + "/");
  };

  if (hasChildren) {
    const isGroupExpanded = isOpen;
    return (
      <li className="list-group-item" key={groupId}>
        <div
          type="button"
          className={`nav-link w-100 d-flex align-items-center justify-content-between text-decoration-none gap-2 fw-medium rounded`}
          onClick={() => toggleGroup(groupId)}
          aria-expanded={!!isGroupExpanded}
          aria-controls={`sub-${groupId}`}
          title={isMinimized ? item.displayName : undefined}
        >
          <span className="d-flex align-items-center">
            <i className={`${item.icon} ${!isMinimized ? "me-2" : ""}`} aria-hidden="true" />
            {!isMinimized && <span>{item.displayName}</span>}
          </span>
          {!isMinimized && (
            <i className={`bi ${isGroupExpanded ? "bi-chevron-up" : "bi-chevron-down"}`} aria-hidden="true" />
          )}
        </div>
        {isGroupExpanded && (
          <ul id={`sub-${groupId}`} className={`list-group list-group-flush ${indent}`}>
            {item.children.map((child) => (
              <MenuItem
                key={child.id || child.route || child.displayName}
                item={child}
                depth={depth + 1}
                isMinimized={isMinimized}
                isMobile={isMobile}
                onClose={onClose}
                openGroups={openGroups}
                toggleGroup={toggleGroup}
              />
            ))}
          </ul>
        )}
      </li>
    );
  }

  // Leaf node — no children
  return (
    <li className="list-group-item" key={item.route || item.displayName}>
      <Link
        to={item.route}
        state={item.route && item.route.startsWith('/song-book') ? { fromMenu: true } : undefined}
        onClick={isMobile ? onClose : undefined}
        className={`nav-link text-decoration-none d-flex align-items-center gap-2 fw-medium rounded${isActive(item.route) ? " active" : ""}`}
        title={isMinimized ? item.displayName : undefined}
      >
        <i className={`${item.icon} ${!isMinimized ? "me-2" : ""}`} aria-hidden="true" />
        {!isMinimized && <span>{item.displayName}</span>}
      </Link>
    </li>
  );
});

const Drawer = forwardRef(({ isOpen, onClose, isMinimized, isMobile }, ref) => {
  const drawerRef = useRef(null);
  const [openGroups, setOpenGroups] = useState({});

  // Always call useSelector
  const initData = useSelector(selectInitData);
  const menuData = useMemo(
    () => (initData?.menuItems || []),
    [initData]
  );

  useEffect(() => {
    if (!isMobile || !isOpen) return;
    const handleKeyDown = (e) => {
      if (e.key === "Escape") {
        onClose();
      }
    };
    document.addEventListener("keydown", handleKeyDown);
    return () => document.removeEventListener("keydown", handleKeyDown);
  }, [isOpen, onClose, isMobile]);

  useEffect(() => {
    if (isMobile && isOpen && drawerRef.current) {
      drawerRef.current.focus();
    }
  }, [isOpen, isMobile]);

  useEffect(() => {
    // Recursively collect all group ids so 3rd-level groups auto-expand too
    const collectGroups = (items, defaults = {}) => {
      items.forEach((it) => {
        if (it?.children && it.children.length) {
          const gid = it.id ? String(it.id) : it.route || it.displayName;
          defaults[gid] = false;
          collectGroups(it.children, defaults);
        }
      });
      return defaults;
    };
    const defaults = collectGroups(menuData);
    setOpenGroups((prev) => ({ ...defaults, ...prev }));
  }, [isMobile, menuData]);

  const toggleGroup = (id) => setOpenGroups((s) => ({ ...s, [id]: !s[id] }));
  // For mobile, don't render if not open
  if (isMobile && !isOpen) {
    return null;
  }

  return (
    <>
      {isMobile && (
        <div
          className="drawer-backdrop position-fixed top-0 start-0 w-100 vh-100"
          onClick={onClose}
          aria-label="Close menu"
        />
      )}

      <aside
        ref={drawerRef}
        className={`drawer position-fixed top-0 start-0 vh-100 d-flex flex-column overflow-hidden ${
          isMobile
            ? isOpen
              ? "open"
              : ""
            : isMinimized
            ? "minimized"
            : "expanded"
        }`}
        tabIndex={isMobile ? -1 : undefined}
        role={isMobile ? "dialog" : "navigation"}
        aria-modal={isMobile ? "true" : undefined}
        aria-label="Main menu"
      >
        <div className="drawer-content d-flex flex-column h-100">
          <div className="ml-drawer-brand" aria-label={`${brand.name} ${brand.sub}`}>
            {brand.logo ? (
              <img className="ml-drawer-logo-img" src={brand.logo} alt={brand.name} />
            ) : (
              <div className="ml-drawer-logo-mark" aria-hidden="true">{brand.logoMark}</div>
            )}
            <div className="ml-drawer-brand-text">
              <div className="ml-drawer-brand-name">{brand.name}</div>
              <div className="ml-drawer-brand-sub">{brand.sub}</div>
            </div>
            {isMobile && (
              <button
                onClick={onClose}
                className="drawer-close-btn rounded-circle d-flex align-items-center justify-content-center btn ms-auto"
                aria-label="Close menu"
              >
                <i className="bi bi-x-lg" aria-hidden="true" />
              </button>
            )}
          </div>
          <nav className="drawer-nav flex-grow-1 overflow-auto" aria-label="Main navigation">
            <ul className="list-group list-group-flush">
              {menuData.map((item) => (
                <MenuItem
                  key={item.id || item.route || item.displayName}
                  item={item}
                  depth={0}
                  isMinimized={isMinimized}
                  isMobile={isMobile}
                  onClose={onClose}
                  openGroups={openGroups}
                  toggleGroup={toggleGroup}
                />
              ))}
            </ul>
          </nav>
          {/* Sidebar footer — group context */}
          {!isMinimized && (
            <div className="ml-drawer-footer">
              <div className="ml-drawer-footer-label">Group</div>
              <div className="ml-drawer-footer-name">Galaxy</div>
              <div className="ml-drawer-footer-sub">USD · 4 companies</div>
            </div>
          )}
        </div>
      </aside>
    </>
  );
});

export default Drawer;
