import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { logoutSuccess, selectUser } from '../features/auth/authSlice'; // Updated imports
import { useNavigate } from 'react-router-dom';
import './TopNavBar.css';

function TopNavBar({ onToggleDrawer }) {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const user = useSelector(selectUser); // Use the specific selector

  const handleLogout = () => {
    dispatch(logoutSuccess()); // Dispatch the new action
    navigate('/login', { replace: true });
  };

  return (
    <nav className="top-nav-bar">
      <div className="nav-left">
        <button onClick={onToggleDrawer} className="drawer-toggle-btn">
          ☰ {/* Hamburger icon or any other icon/text */}
        </button>
        <span className="nav-title">Tour Itinerary App</span>
      </div>
      <div className="nav-right">
        {user && <span className="user-greeting">Hello, {user.name}!</span>}
        <button onClick={handleLogout} className="logout-btn">
          Logout
        </button>
      </div>
    </nav>
  );
}

export default TopNavBar;
