import React from 'react';
import { GoogleLogin } from '@react-oauth/google';
import { useAuth } from '../contexts/AuthContext'; // Use the custom hook

const GoogleLoginButton = () => {
  const { googleLogin } = useAuth(); // Get googleLogin from context

  const handleSuccess = (credentialResponse) => {
    console.log('Google Login Success:', credentialResponse);
    googleLogin(credentialResponse); // Call the specific googleLogin function
  };

  const handleError = () => {
    console.log('Google Login Failed');
    // Optionally, inform the user that login failed
  };

  return (
    // The <h2> was removed as App.jsx now has a general "Choose Login Method" title
    <GoogleLogin
      onSuccess={handleSuccess}
      onError={handleError}
      useOneTap // You can keep or remove useOneTap based on preference
    />
  );
};

export default GoogleLoginButton;
