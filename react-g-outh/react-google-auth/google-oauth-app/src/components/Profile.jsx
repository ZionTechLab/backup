import React from 'react';
import { useAuth } from '../contexts/AuthContext'; // Use the custom hook

const Profile = () => {
  const { user, authProvider } = useAuth(); // Get user and authProvider from context

  if (!user) {
    return <p>Please log in.</p>;
  }

  // Normalize user data - Microsoft user object might have different field names
  // Example: MSAL account object might have 'username' for email.
  // The AuthContext already tries to normalize to name, email, picture.
  const displayName = user.name;
  const displayEmail = user.email;
  const displayPicture = user.picture; // This might be undefined for MSAL without Graph call

  return (
    <div className="profile-container">
      <h2>User Profile</h2>
      {displayPicture && <img src={displayPicture} alt={displayName || 'Profile'} className="profile-picture" />}
      <p><strong>Name:</strong> {displayName || 'N/A'}</p>
      <p><strong>Email:</strong> {displayEmail || 'N/A'}</p>
      <p><small>Authenticated via: {authProvider}</small></p>
      {/*
        If you fetch more details from Microsoft Graph API for picture, etc.,
        you would update the user object in AuthContext and it would reflect here.
      */}
    </div>
  );
};

export default Profile;
