import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navbar from './components/Navbar';
import Drawer from './components/Drawer';
import SongList from './pages/SongList';
import SongDetail from './pages/SongDetail';
import ChordVersion from './pages/ChordVersion';
import TeamsPage from './pages/TeamsPage';
import AddSongPage from './pages/AddSongPage';
import AddChordVersionPage from './pages/AddChordVersionPage';
import VersionDiffPage from './pages/VersionDiffPage'; // Import VersionDiffPage
import { UserProvider } from './contexts/UserContext';
import './App.css';
// Placeholder for other pages
const MySongsPage = () => <div className="container card"><h2>My Songs</h2><p>Feature to be implemented.</p></div>;
const SettingsPage = () => <div className="container card"><h2>Settings</h2><p>Feature to be implemented.</p></div>;
const LogoutPage = () => <div className="container card"><h2>Logged Out</h2><p>You have been logged out (simulation).</p></div>;
const ProfilePage = () => <div className="container card"><h2>Profile</h2><p>Feature to be implemented.</p></div>;




function App() {
  const [isDrawerOpen, setIsDrawerOpen] = useState(false);

  const toggleDrawer = () => {
    setIsDrawerOpen(!isDrawerOpen);
  };

  // Apply theme on initial load
  useEffect(() => {
    const savedTheme = localStorage.getItem('appTheme') || 'theme-dark';
    document.body.className = savedTheme;
  }, []);


  return (
    <UserProvider>
      <Router>
        <div className="App">
          <Navbar toggleDrawer={toggleDrawer} />
          <Drawer isOpen={isDrawerOpen} toggleDrawer={toggleDrawer} />
          <div className="container main-content">
            <Routes>
              <Route path="/" element={<SongList />} />
              <Route path="/add-song" element={<AddSongPage />} />
              <Route path="/add-chord-version/:songId" element={<AddChordVersionPage />} />
              <Route path="/songs/:songId" element={<SongDetail />} />
              <Route path="/songs/:songId/versions/:versionId" element={<ChordVersion />} />
              <Route path="/songs/:songId/diff/:versionId1/:versionId2" element={<VersionDiffPage />} /> {/* New Route */}
              <Route path="/teams" element={<TeamsPage />} />
              <Route path="/my-songs" element={<MySongsPage />} />
              <Route path="/settings" element={<SettingsPage />} />
              <Route path="/logout" element={<LogoutPage />} />
              <Route path="/profile" element={<ProfilePage />} />
            </Routes>
          </div>
        </div>
      </Router>
    </UserProvider>
  );
}

export default App;
