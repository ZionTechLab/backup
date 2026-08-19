import React from 'react';
import { MDBSwitch } from 'mdb-react-ui-kit';

const ThemeToggler = ({ theme, toggleTheme }) => {
  return (
    <MDBSwitch
      checked={theme === 'dark'}
      onChange={toggleTheme}
      label={theme === 'light' ? 'Light Mode' : 'Dark Mode'}
    />
  );
};

export default ThemeToggler;
