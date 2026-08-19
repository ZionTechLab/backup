import React from 'react';
import { Link } from 'react-router-dom';
import ThemeSwitcher from './ThemeSwitcher';
import './Drawer.css';

const Drawer = ({ isOpen, toggleDrawer }) => {
  return (
    <>
      <div className={`drawer-overlay ${isOpen ? 'open' : ''}`} onClick={toggleDrawer}></div>
      <div className={`drawer ${isOpen ? 'open' : ''}`}>
        <button onClick={toggleDrawer} className="close-drawer-btn">&times;</button>
        <div className="drawer-content-wrapper">
          <nav className="drawer-nav">
            <Link to="/" onClick={toggleDrawer}>Home</Link>
            <Link to="/add-song" onClick={toggleDrawer}>Add New Song</Link> {/* New Link */}
            <Link to="/my-songs" onClick={toggleDrawer}>My Songs</Link>
            <Link to="/teams" onClick={toggleDrawer}>Teams</Link>
          </nav>
          <ThemeSwitcher />
        </div>
      </div>
    </>
  );
};

export default Drawer;
