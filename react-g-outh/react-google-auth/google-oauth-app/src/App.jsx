import React from 'react';
import './App.css';
import { useAuth } from './contexts/AuthContext'; // Using the custom hook
import GoogleLoginButton from './components/GoogleLoginButton.jsx'; // Corrected import path
import MicrosoftLoginButton from './components/MicrosoftLoginButton';
import Profile from './components/Profile';
import LogoutButton from './components/LogoutButton';

function App() {
  const { user, authProvider } = useAuth();

  return (
    <div className="App">
      <header className="App-header">
        <h1>React Multi-Provider Auth App</h1>
      </header>
      <main>
        {user ? (
          <>
            <Profile />
            <p><small>Logged in with: {authProvider}</small></p>
            <LogoutButton />
          </>
        ) : (
          <div className="login-options">
            <h2>Choose Login Method</h2>
            <GoogleLoginButton />
            <div style={{ margin: '10px 0' }}>OR</div>
            <MicrosoftLoginButton />
          </div>
        )}
      </main>
      <footer>
        <p>
          Ensure <code>.env</code> is configured with your Google Client ID, MSAL Client ID, and MSAL Tenant ID.
        </p>
        {(import.meta.env.VITE_GOOGLE_CLIENT_ID === "YOUR_GOOGLE_CLIENT_ID_HERE" ||
          import.meta.env.VITE_MSAL_CLIENT_ID === "YOUR_MSAL_CLIENT_ID_HERE" ||
          import.meta.env.VITE_MSAL_TENANT_ID === "YOUR_MSAL_TENANT_ID_HERE") && (
          <p style={{ color: 'red', fontWeight: 'bold' }}>
            Warning: Placeholder credentials are still in use in your .env file. Authentication will likely fail.
          </p>
        )}
      </footer>
    </div>
  );
}

export default App;
