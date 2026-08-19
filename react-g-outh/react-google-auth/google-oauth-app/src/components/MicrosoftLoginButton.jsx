import React from 'react';
import { useAuth } from '../contexts/AuthContext';

const MicrosoftLoginButton = () => {
  const { microsoftLogin } = useAuth();

  const handleMicrosoftLogin = async () => {
    try {
      await microsoftLogin();
      // Login process is handled within AuthContext, including redirect for MSAL
      // console.log("Microsoft login initiated");
    } catch (error) {
      console.error("Microsoft login initiation failed:", error);
      // Optionally, display an error message to the user
    }
  };

  return (
    <button onClick={handleMicrosoftLogin} className="microsoft-login-button">
      Sign in with Microsoft
    </button>
  );
};

export default MicrosoftLoginButton;
