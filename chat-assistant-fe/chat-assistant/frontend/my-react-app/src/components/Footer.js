import React from 'react';
import './Footer.css'; // We'll create this file for specific styles

function Footer() {
  const currentYear = new Date().getFullYear();
  return (
    <footer className="app-footer">
      <p>&copy; {currentYear} Tour Itinerary App. All rights reserved.</p>
      {/* You can add more links or information here if needed */}
      {/* <p>
        <a href="/about">About Us</a> | <a href="/contact">Contact</a> | <a href="/privacy">Privacy Policy</a>
      </p> */}
    </footer>
  );
}

export default Footer;
