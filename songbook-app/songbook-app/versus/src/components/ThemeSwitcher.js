import React, { useEffect, useState } from 'react';

const ThemeSwitcher = () => {
  const [theme, setTheme] = useState(localStorage.getItem('appTheme') || 'theme-dark');

  useEffect(() => {
    document.body.className = theme;
    localStorage.setItem('appTheme', theme);
  }, [theme]);

  const handleThemeChange = (event) => {
    setTheme(event.target.value);
  };

  return (
    <div className="theme-switcher-container">
      <label htmlFor="theme-select">Theme:</label>
      <select id="theme-select" value={theme} onChange={handleThemeChange}>
        <option value="theme-dark">Dark</option>
        <option value="theme-light">Light</option>
        <option value="theme-book">Book</option>
      </select>
    </div>
  );
};

export default ThemeSwitcher;
