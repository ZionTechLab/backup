import React, { createContext, useState, useEffect, useContext } from 'react';
import { getUserData } from '../data/api'; // Assuming api.js is in ../data/

export const UserContext = createContext(null);

export const UserProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    // Simulate fetching user data
    const fetchUser = () => {
      try {
        const userData = getUserData(); // This is synchronous as it imports JSON
        setUser(userData);
      } catch (error) {
        console.error("Failed to fetch user data:", error);
        // Optionally set user to a default error state or null
      } finally {
        setLoading(false);
      }
    };

    fetchUser();
  }, []);

  // Could add login/logout functions here in a real app
  // For now, it just loads the static user.json

  return (
    <UserContext.Provider value={{ user, loading }}>
      {children}
    </UserContext.Provider>
  );
};

export const useUser = () => {
  const context = useContext(UserContext);
  if (context === undefined) {
    throw new Error('useUser must be used within a UserProvider');
  }
  return context;
};
