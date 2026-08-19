import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import './index.css';
import App from './App.jsx';
import { GoogleOAuthProvider } from '@react-oauth/google';
import { AuthProvider } from './contexts/AuthContext.jsx';
import { PublicClientApplication } from "@azure/msal-browser";
import { MsalProvider } from "@azure/msal-react";
import { msalConfig } from "./authConfig";

const googleClientId = import.meta.env.VITE_GOOGLE_CLIENT_ID;
const msalInstance = new PublicClientApplication(msalConfig);


// Basic check for Google Client ID
if (!googleClientId || googleClientId === "YOUR_GOOGLE_CLIENT_ID_HERE") {
  console.warn("VITE_GOOGLE_CLIENT_ID is not set or is still the placeholder. Google Login may fail.");
  // Consider a more user-friendly notification or disabling the Google login button
}

// MSAL client ID and tenant ID are checked in authConfig.js, but we can add a startup check here too
if (!import.meta.env.VITE_MSAL_CLIENT_ID || import.meta.env.VITE_MSAL_CLIENT_ID === "YOUR_MSAL_CLIENT_ID_HERE" ||
    !import.meta.env.VITE_MSAL_TENANT_ID || import.meta.env.VITE_MSAL_TENANT_ID === "YOUR_MSAL_TENANT_ID_HERE") {
  console.warn("MSAL Client ID or Tenant ID is not set or is still the placeholder in .env. Microsoft Login may fail.");
}


createRoot(document.getElementById('root')).render(
  <StrictMode>
    <MsalProvider instance={msalInstance}>
      <GoogleOAuthProvider clientId={googleClientId || "INVALID_GOOGLE_CLIENT_ID_FALLBACK"}>
        <AuthProvider>
          <App />
        </AuthProvider>
      </GoogleOAuthProvider>
    </MsalProvider>
  </StrictMode>
);
