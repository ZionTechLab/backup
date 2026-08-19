import React, { createContext, useState, useEffect, useContext } from 'react';
import { jwtDecode } from 'jwt-decode';
import { useMsal, useIsAuthenticated } from "@azure/msal-react";
import { loginRequest } from "../authConfig";

export const AuthContext = createContext(null);

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null); // Can be { type: 'google', data: {...} } or { type: 'microsoft', data: {...} }
  const [authProvider, setAuthProvider] = useState(null); // 'google' or 'microsoft'

  const { instance, accounts } = useMsal();
  const isAuthenticatedWithMsal = useIsAuthenticated();

  // Effect to load user from localStorage (for Google) or check MSAL state
  useEffect(() => {
    const storedGoogleToken = localStorage.getItem('googleUserToken');
    const storedAuthProvider = localStorage.getItem('authProvider');

    if (storedAuthProvider === 'google' && storedGoogleToken) {
      try {
        const decodedUser = jwtDecode(storedGoogleToken);
        if (decodedUser.exp * 1000 > Date.now()) {
          setUser({
            name: decodedUser.name,
            email: decodedUser.email,
            picture: decodedUser.picture,
            // Add other relevant fields from Google token
          });
          setAuthProvider('google');
        } else {
          localStorage.removeItem('googleUserToken');
          localStorage.removeItem('authProvider');
        }
      } catch (error) {
        console.error("Error decoding Google token from localStorage:", error);
        localStorage.removeItem('googleUserToken');
        localStorage.removeItem('authProvider');
      }
    } else if (isAuthenticatedWithMsal && accounts[0]) {
      // MSAL handles its own session management. If authenticated, set user.
      const msalAccount = accounts[0];
      setUser({
        name: msalAccount.name || msalAccount.username, // name might not always be present
        email: msalAccount.username, // username is typically the email for Azure AD
        // picture: undefined, // MS Graph API call needed for picture
        // Add other relevant fields from MSAL account
      });
      setAuthProvider('microsoft');
      localStorage.setItem('authProvider', 'microsoft'); // Keep track of active provider
    } else {
        // Clear any stale provider info if no active session
        localStorage.removeItem('authProvider');
    }
  }, [isAuthenticatedWithMsal, accounts]);


  const googleLogin = (credentialResponse) => {
    try {
      const decoded = jwtDecode(credentialResponse.credential);
      setUser({
        name: decoded.name,
        email: decoded.email,
        picture: decoded.picture,
      });
      setAuthProvider('google');
      localStorage.setItem('googleUserToken', credentialResponse.credential);
      localStorage.setItem('authProvider', 'google');
    } catch (error) {
      console.error("Google login failed:", error);
      setUser(null);
      setAuthProvider(null);
      localStorage.removeItem('googleUserToken');
      localStorage.removeItem('authProvider');
    }
  };

  const microsoftLogin = async () => {
    try {
      // For popup login
      // const loginResponse = await instance.loginPopup(loginRequest);
      // For redirect login
      await instance.loginRedirect(loginRequest).catch(e => {
          console.error("MSAL login redirect error:", e);
      });
      // Note: User state will be set by the useEffect hook when isAuthenticatedWithMsal becomes true
      // and accounts array is populated after redirect.
      // If using popup, can set user here from loginResponse.account
      // For now, we rely on the useEffect for redirect flow.
      // If login is successful, useEffect will handle setting the user.
      // We set the authProvider here to ensure it's tracked immediately.
      localStorage.setItem('authProvider', 'microsoft');
      setAuthProvider('microsoft'); // This might be set by useEffect anyway
    } catch (error) {
      console.error("Microsoft login failed:", error);
      setUser(null);
      setAuthProvider(null);
      localStorage.removeItem('authProvider');
    }
  };


  const logout = async () => {
    const currentProvider = localStorage.getItem('authProvider'); // Or use state `authProvider`

    if (currentProvider === 'google') {
      // Optional: googleLogout(); // If you were using explicit googleLogout
      localStorage.removeItem('googleUserToken');
    } else if (currentProvider === 'microsoft' && instance) {
      // For popup logout:
      // await instance.logoutPopup({ postLogoutRedirectUri: "/" });
      // For redirect logout:
      await instance.logoutRedirect({ postLogoutRedirectUri: import.meta.env.VITE_MSAL_REDIRECT_URI || "/" });
    }

    setUser(null);
    setAuthProvider(null);
    localStorage.removeItem('authProvider');
    localStorage.removeItem('googleUserToken'); // Ensure Google token is cleared regardless
    console.log("User logged out");
  };

  return (
    <AuthContext.Provider value={{ user, authProvider, googleLogin, microsoftLogin, logout, msalInstance: instance }}>
      {children}
    </AuthContext.Provider>
  );
};

// Custom hook to use auth context
export const useAuth = () => {
  return useContext(AuthContext);
};
