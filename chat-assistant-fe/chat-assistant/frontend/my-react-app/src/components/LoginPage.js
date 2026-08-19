import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { loginSuccess } from '../features/auth/authSlice';
import './LoginPage.css'; // Import the new CSS file

function LoginPage() {
  const [email, setEmail] = useState(''); // Changed from username to email
  const [password, setPassword] = useState('');
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const handleLogin = (e) => {
    e.preventDefault();
    console.log('Attempting login with:', { email, password }); // Changed username to email
    // In a real app, userData would likely come from an API response
    // For now, using email as part of user data.
    const userData = { name: email.split('@')[0], id: '123', email: email };
    dispatch(loginSuccess(userData));
    navigate('/main', { replace: true });
  };

  // SVG for Back Arrow
  const BackArrowIcon = () => (
    <svg xmlns="http://www.w3.org/2000/svg" width="24px" height="24px" fill="currentColor" viewBox="0 0 256 256">
      <path d="M224,128a8,8,0,0,1-8,8H59.31l58.35,58.34a8,8,0,0,1-11.32,11.32l-72-72a8,8,0,0,1,0-11.32l72-72a8,8,0,0,1,11.32,11.32L59.31,120H216A8,8,0,0,1,224,128Z"></path>
    </svg>
  );

  return (
    <div className="login-page-container">
      <div className="login-content-wrapper">
        {/* Top Image Banner - style will give it background/height */}
        <div className="login-image-banner"></div>

        {/* Header Section */}
        <div className="login-header">
          <div className="login-back-arrow">
            <BackArrowIcon />
          </div>
          <h2 className="login-title">Login</h2>
        </div>

        {/* Form Inputs */}
        <form onSubmit={handleLogin} className="login-form">
          <div className="login-input-group">
            {/* <label htmlFor="email">Email</label> */} {/* Label is part of placeholder in design */}
            <input
              type="email" // Changed type to email
              id="email"
              className="login-input" // Apply new CSS class
              placeholder="Email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              required
              autoComplete="email"
            />
          </div>

          <div className="login-input-group">
            {/* <label htmlFor="password">Password</label> */} {/* Label is part of placeholder in design */}
            <input
              type="password"
              id="password"
              className="login-input" // Apply new CSS class
              placeholder="Password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
              autoComplete="current-password"
            />
          </div>

          <p className="forgot-password-link">Forgot Password?</p>
        </form>
      </div>

      <div className="login-actions-wrapper">
        <div className="login-button-container">
          <button type="submit" className="login-button" onClick={handleLogin}>
            Login
          </button>
        </div>
        <div className="login-bottom-spacer"></div> {/* For the h-5 equivalent */}
      </div>
    </div>
  );
}

export default LoginPage;
