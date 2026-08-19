import React from 'react';
import { useAuth } from '../contexts/AuthContext'; // Use the custom hook

const LogoutButton = () => {
  const { logout } = useAuth(); // Get logout from context

  const handleLogout = async () => {
    await logout(); // AuthContext's logout is now async
    // console.log("Logout initiated from button");
  };

  return (
    <button onClick={handleLogout} className="logout-button">
      Logout
    </button>
  );
};

export default LogoutButton;
