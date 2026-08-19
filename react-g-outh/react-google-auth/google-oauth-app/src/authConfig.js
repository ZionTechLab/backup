import { LogLevel } from "@azure/msal-browser";

// Vite environment variables must be accessed via import.meta.env
const MSAL_CLIENT_ID = import.meta.env.VITE_MSAL_CLIENT_ID;
const MSAL_TENANT_ID = import.meta.env.VITE_MSAL_TENANT_ID;
const MSAL_REDIRECT_URI = import.meta.env.VITE_MSAL_REDIRECT_URI;

/**
 * Configuration object to be passed to MSAL instance on creation.
 * For a full list of MSAL.js configuration parameters, visit:
 * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/configuration.md
 */
export const msalConfig = {
  auth: {
    clientId: MSAL_CLIENT_ID || "YOUR_MSAL_CLIENT_ID_HERE", // Fallback if env var is not set
    authority: `https://login.microsoftonline.com/${MSAL_TENANT_ID || "YOUR_MSAL_TENANT_ID_HERE"}`, // Fallback
    redirectUri: MSAL_REDIRECT_URI || "http://localhost:5173", // Default redirect URI
    postLogoutRedirectUri: MSAL_REDIRECT_URI || "http://localhost:5173", // Redirect after logout
    navigateToLoginRequestUrl: true, // If "true", will navigate back to the original request location before processing the auth code response.
  },
  cache: {
    cacheLocation: "sessionStorage", // This configures where your cache will be stored
    storeAuthStateInCookie: false, // Set this to "true" if you are having issues on IE11 or Edge
  },
  system: {
    loggerOptions: {
      loggerCallback: (level, message, containsPii) => {
        if (containsPii) {
          return;
        }
        switch (level) {
          case LogLevel.Error:
            console.error(message);
            return;
          case LogLevel.Info:
            // console.info(message); // You can uncomment this for more verbose logging
            return;
          case LogLevel.Verbose:
            // console.debug(message); // You can uncomment this for very verbose logging
            return;
          case LogLevel.Warning:
            console.warn(message);
            return;
          default:
            return;
        }
      },
      logLevel: LogLevel.Info, // Set to Warning or Error for production
    }
  }
};

/**
 * Scopes you add here will be prompted for user consent during sign-in.
 * By default, MSAL.js will add OIDC scopes (openid, profile, email) to any login request.
 * For more information about OIDC scopes, visit:
 * https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-permissions-and-consent#openid-connect-scopes
 */
export const loginRequest = {
  scopes: ["User.Read", "email", "openid", "profile"] // Added "email", "openid", "profile" for more user info
};

/**
 * Add here the scopes to request when acquiring an access token for MS Graph API. For more information, see:
 * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/resources-and-scopes.md
 */
export const graphConfig = {
    graphMeEndpoint: "https://graph.microsoft.com/v1.0/me" // Basic user profile
};

// Check for placeholder values and log a warning if they are still present
if (MSAL_CLIENT_ID === "YOUR_MSAL_CLIENT_ID_HERE" || MSAL_TENANT_ID === "YOUR_MSAL_TENANT_ID_HERE") {
  console.warn("MSAL Configuration still contains placeholder Client ID or Tenant ID. Please update .env file.");
}
