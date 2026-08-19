import React, { useState, useEffect, useRef } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { useUser } from '../contexts/UserContext';
import './Navbar.css';

const Navbar = ({ toggleDrawer }) => {
  const { user, loading } = useUser();
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const dropdownRef = useRef(null);
  const navigate = useNavigate();

  const toggleDropdown = () => setDropdownOpen(!dropdownOpen);

  const handleLogout = () => {
    // In a real app, this would call a logout function from UserContext
    console.log("User logged out (simulation)");
    setDropdownOpen(false);
    navigate('/logout'); // Navigate to placeholder logout page
  };

  const handleSettings = () => {
    setDropdownOpen(false);
    navigate('/settings');
  }

  // Click outside to close dropdown
  useEffect(() => {
    const handleClickOutside = (event) => {
      if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
        setDropdownOpen(false);
      }
    };
    document.addEventListener('mousedown', handleClickOutside);
    return () => document.removeEventListener('mousedown', handleClickOutside);
  }, []);

  return (
    <nav className="navbar-custom">
      <button onClick={toggleDrawer} className="hamburger-btn">
        &#9776;
      </button>
      <div className="navbar-title-container">
        <h1>
          <Link to="/" className="navbar-title">
            Versus
          </Link>
        </h1>
      </div>
      <div className="navbar-user-display" ref={dropdownRef}>
        {loading ? (
          <span>Loading...</span>
        ) : user ? (
          <>
            <button onClick={toggleDropdown} className="user-name-button">
              {user.displayName} <span className={`dropdown-arrow ${dropdownOpen ? 'open' : ''}`}>&#9662;</span>
            </button>
            {dropdownOpen && (
              <div className="user-dropdown">
                <Link to="/profile" onClick={() => setDropdownOpen(false)}>Profile</Link> {/* Placeholder */}
                <button onClick={handleSettings}>Settings</button>
                <button onClick={handleLogout}>Logout</button>
              </div>
            )}
          </>
        ) : (
          <span className="user-name">Guest</span>
        )}
      </div>
    </nav>
  );
};

export default Navbar;
