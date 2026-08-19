import React from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import { useSelector } from 'react-redux';
import { selectIsLoggedIn } from './features/auth/authSlice'; // Updated import
import LoginPage from './components/LoginPage';
import MainPage from './components/MainPage';
import './App.css';

function App() {
  const isLoggedIn = useSelector(selectIsLoggedIn); // Use the specific selector

  return (
    <Router>
      <div className="App">
        <Routes>
          {/* If logged in and trying to access /login, redirect to /main */}
          <Route
            path="/login"
            element={isLoggedIn ? <Navigate to="/main" replace /> : <LoginPage />}
          />
          {/* If not logged in and trying to access /main, redirect to /login */}
          <Route
            path="/main"
            element={isLoggedIn ? <MainPage /> : <Navigate to="/login" replace />}
          />
          {/* Default route: redirect to /main if logged in, otherwise to /login */}
          <Route
            path="/"
            element={isLoggedIn ? <Navigate to="/main" replace /> : <Navigate to="/login" replace />}
          />
          {/* You can add a 404 Not Found route here if needed */}
          {/* <Route path="*" element={<NotFoundComponent />} /> */}
        </Routes>
      </div>
    </Router>
  );
}

export default App;
