import React, { forwardRef } from 'react';
import './Drawer.css';

// Wrap Drawer with forwardRef to accept a ref from MainPage
const Drawer = forwardRef(({ isOpen, onClose }, ref) => {
  if (!isOpen) {
    return null;
  }

  return (
    // Attach the ref to the main aside element
    <aside ref={ref} className="drawer open">
      <div className="drawer-header">
        <h3>Menu</h3>
        <button onClick={onClose} className="close-drawer-btn">
          &times; {/* Close icon or any other icon/text */}
        </button>
      </div>
      <nav className="drawer-nav">
        <ul>
          <li>
            {/* These would ideally be NavLink from react-router-dom if they navigate */}
            <a href="#new-itinerary" onClick={onClose}>New Itinerary</a>
          </li>
          <li>
            <a href="#history" onClick={onClose}>History</a>
          </li>
          {/* Add other drawer items here */}
        </ul>
      </nav>
    </aside>
  );
}); // Correctly close forwardRef

export default Drawer;
