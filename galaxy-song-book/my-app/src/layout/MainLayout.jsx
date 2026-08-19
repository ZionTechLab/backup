import { useState, useEffect, useRef, Suspense } from "react";
import { Outlet } from "react-router-dom";
import { useSelector } from "react-redux";
import Navbar from "./Navbar";
import Drawer from "./Drawer";
import Footer from "./Footer";
import Overlay from "./Overlay";
import ErrorBoundary from "../components/ErrorBoundary";
import { selectSelectedCompanyId } from "../features/auth";
import "./MainPage.css";
import "./meridian-layout.css";

const MOBILE_BREAKPOINT = 992; // Bootstrap lg breakpoint

function MainLayout() {
  const [isDrawerOpen, setIsDrawerOpen] = useState(false);
  const [isDrawerMinimized, setIsDrawerMinimized] = useState(false);
  const [isMobile, setIsMobile] = useState(false);
  const drawerRef = useRef(null);
  const companyId = useSelector(selectSelectedCompanyId);

  useEffect(() => {
    const checkMobile = () => {
      const mobile = window.innerWidth < MOBILE_BREAKPOINT;
      setIsMobile(mobile);
      
      // Reset states when switching between mobile/desktop
      if (mobile) {
        setIsDrawerOpen(false);
        setIsDrawerMinimized(false);
      } else {
        setIsDrawerOpen(true); // Always open on desktop
      }
    };

    checkMobile();
    window.addEventListener('resize', checkMobile);
    return () => window.removeEventListener('resize', checkMobile);
  }, []);

  // Update body classes based on drawer state
  useEffect(() => {
    const body = document.body;
    if (isMobile) {
      body.classList.toggle('drawer-open', isDrawerOpen);
      body.classList.remove('drawer-expanded', 'drawer-minimized');
    } else {
      body.classList.toggle('drawer-expanded', !isDrawerMinimized);
      body.classList.toggle('drawer-minimized', isDrawerMinimized);
      body.classList.remove('drawer-open');
    }
    return () => {
      body.classList.remove('drawer-open', 'drawer-expanded', 'drawer-minimized');
    };
  }, [isMobile, isDrawerOpen, isDrawerMinimized]);

  const toggleDrawer = () => {
    if (isMobile) {
      setIsDrawerOpen(!isDrawerOpen);
    } else {
      setIsDrawerMinimized(!isDrawerMinimized);
    }
  };

  // FAB tooltips: mirror each floating button's own text into aria-label, which
  // the CSS tooltip reads. MutationObserver keeps it current as lazy routes and
  // conditional buttons mount. Single source of truth stays the button text.
  useEffect(() => {
    const root = document.querySelector("main.content");
    if (!root) return;
    const labelFabs = () => {
      root.querySelectorAll(".ml-fab, .ml-fab-1, .ml-fab-2").forEach((btn) => {
        const text = btn.textContent.trim();
        if (text && btn.getAttribute("aria-label") !== text) {
          btn.setAttribute("aria-label", text);
        }
      });
    };
    labelFabs();
    const observer = new MutationObserver(labelFabs);
    observer.observe(root, { childList: true, subtree: true });
    return () => observer.disconnect();
  }, []);

  useEffect(() => {
    function handleClickOutside(event) {
      if (
        isMobile &&
        isDrawerOpen &&
        drawerRef.current &&
        !drawerRef.current.contains(event.target)
      ) {
        const toggleButton = document.querySelector(".drawer-toggle-btn");
        if (toggleButton && toggleButton.contains(event.target)) {
          return;
        }
        setIsDrawerOpen(false);
      }
    }

    if (isMobile && isDrawerOpen) {
      document.addEventListener("mousedown", handleClickOutside);
    } else {
      document.removeEventListener("mousedown", handleClickOutside);
    }

    return () => {
      document.removeEventListener("mousedown", handleClickOutside);
    };
  }, [isDrawerOpen, isMobile]);

  return (
    <div className="main-page-layout">
      <Navbar onToggleDrawer={toggleDrawer} />
      <div className={`main-container ${!isMobile ? (isDrawerMinimized ? 'drawer-minimized' : 'drawer-expanded') : ''}`}>
        <Drawer 
          ref={drawerRef} 
          isOpen={isDrawerOpen} 
          onClose={() => setIsDrawerOpen(false)}
          isMinimized={isDrawerMinimized}
          isMobile={isMobile}
        />
        {isMobile && <Overlay isOpen={isDrawerOpen} onClick={() => setIsDrawerOpen(false)} />}
        <main className="content">
          <ErrorBoundary>
            <Suspense fallback={
              <div className="d-flex justify-content-center align-items-center py-5">
                <div className="spinner-border" role="status" aria-label="Loading" />
              </div>
            }>
              <Outlet key={companyId} />
            </Suspense>
          </ErrorBoundary>
        </main>
      </div>
      <Footer />
    </div>
  );
}

export default MainLayout;
