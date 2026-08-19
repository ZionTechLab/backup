import { useDispatch, useSelector } from "react-redux";
import {
  logoutAsync, setContext, reloadInitData,
  selectUser, selectInitData,
  selectUserCompanies, selectUserGroups, selectUserTenants,
  selectSelectedGroupId, selectSelectedCompanyId,
  selectTenantId,
} from "../features/auth";
import { useLocation, useNavigate } from "react-router-dom";
import { useTheme } from "../hooks/useTheme";
import { useState } from "react";
import MenuSearch from "./MenuSearch";
import Modal from "../components/Modal";
import tenantService from "../features/Meridian/Masters/Tenants/service";
import MessageBoxService from "../services/MessageBoxService";
import "./topbar.css";

function ContextDropdown({ label, value, options, onSelect }) {
  return (
    <div className="dropdown ml-ctx-dropdown">
      <button
        className="ml-ctx-btn"
        type="button"
        data-bs-toggle="dropdown"
        aria-expanded="false"
      >
        <span className="ml-ctx-label">{label}</span>
        <span className="ml-ctx-value">{value}</span>
        <i className="bi bi-chevron-down ml-ctx-chevron" aria-hidden="true" />
      </button>
      <ul className="dropdown-menu ml-ctx-menu">
        {options.map((opt) => (
          <li key={opt.id}>
            <button
              className="dropdown-item ml-ctx-item"
              onClick={() => onSelect(opt)}
            >
              {opt.name ?? opt.label}
              {opt.status === "locked" && (
                <span className="ml-ctx-locked">LOCKED</span>
              )}
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}

function MobileContextDropdown({ group, company, groups, companies, onSelectGroup, onSelectCompany }) {
  return (
    <div className="dropdown ml-ctx-dropdown d-lg-none">
      <button
        className="ml-ctx-btn ml-ctx-btn-mobile"
        type="button"
        data-bs-toggle="dropdown"
        data-bs-auto-close="outside"
        aria-expanded="false"
        aria-label="Context selectors"
      >
        <i className="bi bi-sliders ml-ctx-mobile-icon" aria-hidden="true" />
        <span className="ml-ctx-value">{company ?? group ?? "—"}</span>
        <i className="bi bi-chevron-down ml-ctx-chevron" aria-hidden="true" />
      </button>
      <ul className="dropdown-menu ml-ctx-menu ml-ctx-menu-mobile">
        <li className="ml-ctx-section">Group</li>
        {groups.map((g) => (
          <li key={`g-${g.id}`}>
            <button className="dropdown-item ml-ctx-item" onClick={() => onSelectGroup(g)}>
              {g.name}
            </button>
          </li>
        ))}
        <li><hr className="dropdown-divider" /></li>
        <li className="ml-ctx-section">Company</li>
        {companies.map((c) => (
          <li key={`c-${c.id}`}>
            <button className="dropdown-item ml-ctx-item" onClick={() => onSelectCompany(c)}>
              {c.name}
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}

function Navbar({ onToggleDrawer }) {
  const dispatch      = useDispatch();
  const navigate      = useNavigate();
  const user          = useSelector(selectUser);
  const initData      = useSelector(selectInitData);
  const location      = useLocation();
  const userGroups    = useSelector(selectUserGroups);
  const userCompanies = useSelector(selectUserCompanies);
  const userTenants   = useSelector(selectUserTenants);
  const storedGroupId   = useSelector(selectSelectedGroupId);
  const storedCompanyId = useSelector(selectSelectedCompanyId);
  const currentTenantId = useSelector(selectTenantId);

  const groups    = userGroups.map((g) => ({ id: g.groupId, name: g.groupName, companyId: g.companyId }));
  const companies = userCompanies.map((c) => ({ id: c.companyId, name: c.companyName }));

  const defaultGroup   = userGroups[0] ?? null;
  const defaultCompany = userCompanies.find((c) => c.isDefault === 1) ?? userCompanies[0] ?? null;

  const groupId   = storedGroupId   ?? defaultGroup?.groupId   ?? null;
  const companyId = storedCompanyId ?? defaultCompany?.companyId ?? null;
  const { isDark, toggleDark } = useTheme();

  const selectedGroup   = groups.find((g) => g.id === groupId);
  const selectedCompany = companies.find((c) => c.id === companyId);

  const handleCompanyChange = (companyId, groupId) => {
    dispatch(setContext({ companyId, groupId }));
    dispatch(reloadInitData());
  };

  const handleLogout = () => {
    dispatch(logoutAsync());
    navigate("/login", { replace: true });
  };

  const handleFullScreen = () => {
    if (document.fullscreenElement) document.exitFullscreen();
    else document.documentElement.requestFullscreen();
  };

  // --- Switch Tenant ---
  const [showTenantModal, setShowTenantModal] = useState(false);
  const [pickedTenantId, setPickedTenantId] = useState("");
  const [setAsDefaultCb, setSetAsDefaultCb] = useState(false);

  const openTenantModal = () => {
    setPickedTenantId(currentTenantId ?? "");
    setSetAsDefaultCb(false);
    setShowTenantModal(true);
  };

  const handleSwitchTenant = async () => {
    if (!pickedTenantId || pickedTenantId === currentTenantId) {
      setShowTenantModal(false);
      return;
    }

    const companiesForTenant = userCompanies.filter((c) => c.tenantId === pickedTenantId);

    if (companiesForTenant.length === 0) {
      MessageBoxService.show({
        message: "You don't have any company under this tenant yet — ask an administrator to add one.",
        type: "warning",
      });
      return;
    }

    if (setAsDefaultCb) {
      await tenantService.setMyDefault(pickedTenantId);
    }

    // Pick company: prefer isDefault, otherwise first
    const targetCompany = companiesForTenant.find((c) => c.isDefault) ?? companiesForTenant[0];
    dispatch(setContext({ companyId: targetCompany.companyId }));
    dispatch(reloadInitData());

    const tenant = userTenants.find((t) => t.tenantId === pickedTenantId);
    MessageBoxService.show({
      message: `Switched to ${tenant?.tenantName ?? pickedTenantId}.`,
      type: "success",
    });

    setShowTenantModal(false);
  };

  const slugify = (s) =>
    String(s || "")
      .toLowerCase()
      .trim()
      .replace(/[^a-z0-9\s-]/g, "")
      .replace(/\s+/g, "-")
      .replace(/-+/g, "-");

  const getPageTitle = () => {
    const path = location.pathname;
    if (path === "/") return "Dashboard";

    if (initData?.menuItems_Flat) {
      const found = initData.menuItems_Flat.find((item) => item.route === path);
      if (found) return found.displayName;

      const found2 = initData.menuItems_Flat.find(
        (item) => item.route === path.replace("/add", "")
      );
      if (found2) return found2.displayName + " (add)";

      const found3 = initData.menuItems_Flat.find(
        (item) => item.route === path.replace(/\/edit\/[^/]*$/, "")
      );
      if (found3) return found3.displayName + " (edit)";
    }

    const refMatch = path.match(/^\/reference\/([^/]+)(\/add|\/edit\/[^/]+)?$/);
    if (refMatch && initData?.meta) {
      const matched = initData.meta.find(
        (m) => slugify(m.categoryTypeName) === refMatch[1]
      );
      if (matched) {
        const suffix = refMatch[2]?.startsWith("/add")
          ? " (add)"
          : refMatch[2]?.startsWith("/edit")
          ? " (edit)"
          : "";
        return matched.categoryTypeName + suffix;
      }
    }
    return "Page";
  };

  const userName = user?.fullName || user?.name || user?.userName || "Guest";
  const initials = userName
    .split(" ")
    .map((w) => w[0])
    .join("")
    .toUpperCase()
    .slice(0, 2);

  return (
    <>
    <nav className="navbar-custom navbar-expand-lg sticky-top">
      <div className="container-fluid d-flex align-items-center gap-2 h-100 px-3">

        {/* Hamburger */}
        <button
          onClick={onToggleDrawer}
          className="btn drawer-toggle-btn flex-shrink-0 rounded-2"
          aria-label="Toggle navigation"
        >
          <i className="bi bi-list" aria-hidden="true" />
        </button>

        {/* Context selectors — hidden on mobile */}
        <div className="d-none d-lg-flex align-items-center gap-2 flex-shrink-0">
          <ContextDropdown
            label="GROUP"
            value={selectedGroup?.name ?? "—"}
            options={groups}
            onSelect={(g) => handleCompanyChange(g.companyId ?? null, g.id)}
          />
          <span className="ml-ctx-sep" aria-hidden="true">/</span>
          <ContextDropdown
            label="COMPANY"
            value={selectedCompany?.name ?? "—"}
            options={companies}
            onSelect={(c) => handleCompanyChange(c.id)}
          />
        </div>

        {/* Mobile context dropdown — replaces inline selectors on small screens */}
        <MobileContextDropdown
          group={selectedGroup?.name}
          company={selectedCompany?.name}
          groups={groups}
          companies={companies}
          onSelectGroup={(g) => handleCompanyChange(g.companyId ?? null, g.id)}
          onSelectCompany={(c) => handleCompanyChange(c.id)}
        />

        {/* Mobile page title */}
        <span className="d-none d-sm-inline d-lg-none ml-nav-title">{getPageTitle()}</span>

        <div className="flex-grow-1" />

        {/* Menu search — pill on desktop, icon on small screens */}
        <MenuSearch items={initData?.menuItems_Flat || []} />

        {/* Notifications */}
        <button className="ml-nav-icon-btn" aria-label="Notifications">
          <i className="bi bi-bell nav-icon-lg" />
          <span className="ml-nav-count" aria-label="4 unread">4</span>
        </button>

        {/* Theme toggle */}
        <button
          className="ml-nav-icon-btn d-none d-md-flex"
          onClick={toggleDark}
          aria-label="Toggle theme"
        >
          <i className={`bi bi-${isDark ? "moon" : "sun"} nav-icon-lg`} />
        </button>

        {/* Fullscreen */}
        <button className="ml-nav-icon-btn d-none d-md-flex" onClick={handleFullScreen} aria-label="Toggle fullscreen">
          <i className="bi bi-arrows-fullscreen nav-icon-sm" />
        </button>

        {/* User dropdown */}
        <div className="dropdown ml-nav-dropdown">
          <button
            className="ml-user-pill"
            type="button"
            data-bs-toggle="dropdown"
            aria-expanded="false"
            aria-label="User menu"
          >
            <span className="ml-user-initials" aria-hidden="true">{initials}</span>
            <span className="d-none d-md-inline">{userName.split(" ")[0]}</span>
            <i className="bi bi-chevron-down nav-chevron" aria-hidden="true" />
          </button>

          <ul className="dropdown-menu dropdown-menu-end">
            <li>
              <div className="ml-dropdown-header">
                <div className="ml-dropdown-user-name">{userName}</div>
                <div className="ml-dropdown-user-role">Admin</div>
              </div>
            </li>
            <li>
              <button className="dropdown-item" onClick={() => navigate("/profile")}>
                <i className="bi bi-person" aria-hidden="true" />
                Profile
              </button>
            </li>
            <li>
              <button className="dropdown-item" onClick={() => navigate("/wallet")}>
                <i className="bi bi-wallet2" aria-hidden="true" />
                My Wallet
              </button>
            </li>
            <li>
              <button className="dropdown-item" onClick={() => navigate("/api-settings")}>
                <i className="bi bi-key" aria-hidden="true" />
                API Settings
              </button>
            </li>
            <li>
              <button className="dropdown-item" onClick={() => navigate("/notification-settings")}>
                <i className="bi bi-bell" aria-hidden="true" />
                Notifications
              </button>
            </li>
            <li>
              <button className="dropdown-item" onClick={() => navigate("/theme")}>
                <i className="bi bi-palette" aria-hidden="true" />
                Theme
              </button>
            </li>
            <li>
              <button className="dropdown-item" onClick={openTenantModal}>
                <i className="bi bi-arrow-repeat" aria-hidden="true" />
                Switch Tenant
              </button>
            </li>
            <li>
              <button className="dropdown-item" onClick={() => navigate("/settings/tenant-preferences")}>
                <i className="bi bi-sliders" aria-hidden="true" />
                Tenant Settings
              </button>
            </li>
            <li>
              <button className="dropdown-item" onClick={() => navigate("/help")}>
                <i className="bi bi-question-circle" aria-hidden="true" />
                Help
              </button>
            </li>
            <li><hr className="dropdown-divider" /></li>
            <li>
              <button className="dropdown-item ml-danger" onClick={handleLogout}>
                <i className="bi bi-box-arrow-right" aria-hidden="true" />
                Sign out
              </button>
            </li>
          </ul>
        </div>

      </div>
    </nav>

    <Modal show={showTenantModal} onClose={() => setShowTenantModal(false)} title="Switch Tenant">
        <p className="text-muted small mb-3">Pick a tenant to switch your active context.</p>
        {userTenants.length === 0 ? (
          <p className="text-muted">You don't belong to any tenants.</p>
        ) : (
          <div className="list-group mb-3">
            {userTenants.map((t) => (
              <label
                key={t.tenantId}
                className={`list-group-item d-flex align-items-center gap-2 ${pickedTenantId === t.tenantId ? 'active' : ''}`}
                style={{ cursor: 'pointer' }}
              >
                <input
                  type="radio"
                  name="switch-tenant"
                  value={t.tenantId}
                  checked={pickedTenantId === t.tenantId}
                  onChange={(e) => setPickedTenantId(e.target.value)}
                />
                <div>
                  <div className="fw-semibold">{t.tenantName}</div>
                  {t.isDefault && <span className="badge bg-primary">Default</span>}
                </div>
              </label>
            ))}
          </div>
        )}
        <div className="form-check mb-3">
          <input
            id="set-default-cb"
            type="checkbox"
            className="form-check-input"
            checked={setAsDefaultCb}
            onChange={(e) => setSetAsDefaultCb(e.target.checked)}
          />
          <label htmlFor="set-default-cb" className="form-check-label">Set as my default tenant</label>
        </div>
        <div className="d-flex justify-content-end gap-2">
          <button type="button" className="btn btn-secondary" onClick={() => setShowTenantModal(false)}>Cancel</button>
          <button
            type="button"
            className="btn btn-primary"
            onClick={handleSwitchTenant}
            disabled={!pickedTenantId}
          >
            Switch
          </button>
        </div>
      </Modal>
    </>
  );
}

export default Navbar;
