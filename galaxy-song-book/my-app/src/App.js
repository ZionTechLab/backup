import { useEffect, useState } from "react";
import { MessageBoxProvider } from "./components/MessageBoxProvider";
import ErrorBoundary from "./components/ErrorBoundary";
import AppRoutes from "./AppRoutes";
import { useSelector, useDispatch } from "react-redux";
import { selectIsLoggedIn, selectToken, selectTenantSettings, refreshAccessToken, reloadInitData } from "./features/auth";
import { ModalProvider } from "./helpers/ModalService";
import { LoadingSpinnerProvider } from "./hooks/useLoadingSpinner";
import { ThemeProvider } from "./hooks/ThemeContext";
import runAppMigrations from "./helpers/runAppMigrations";
import applyTenantSettings from "./config/applyTenantSettings";

function App() {
  const dispatch = useDispatch();
  const isLoggedIn = useSelector(selectIsLoggedIn);
  const token = useSelector(selectToken);
  const tenantSettings = useSelector(selectTenantSettings);
  // Gate routing until the silent refresh resolves so protected pages don't
  // render (and fire unauthenticated requests) before the access token is restored.
  const [authReady, setAuthReady] = useState(() => !(isLoggedIn && !token));

  useEffect(() => {
    if (isLoggedIn && !token) {
      // Restore the access token, then refresh init (menu/companies) so a
      // DB-driven menu reflects server changes on reload, not just on re-login.
      dispatch(refreshAccessToken())
        .unwrap()
        .then(() => dispatch(reloadInitData()))
        .catch(() => {})
        .finally(() => setAuthReady(true));
    } else if (isLoggedIn) {
      dispatch(reloadInitData());
    }
  }, []); // eslint-disable-line react-hooks/exhaustive-deps

  useEffect(() => {
    runAppMigrations();
  }, []);

  useEffect(() => {
    applyTenantSettings(tenantSettings);
  }, [tenantSettings]);

  if (!authReady) {
    return (
      <div className="d-flex justify-content-center align-items-center app-loading-screen">
        <div className="spinner-border" />
      </div>
    );
  }

  return (
    <ThemeProvider>
    <ErrorBoundary>
      <LoadingSpinnerProvider>
        <ModalProvider>
          <MessageBoxProvider>
            <div className="App">
              <AppRoutes isLoggedIn={isLoggedIn} />
            </div>
          </MessageBoxProvider>
        </ModalProvider>
      </LoadingSpinnerProvider>
    </ErrorBoundary>
    </ThemeProvider>
  );
}

export default App;