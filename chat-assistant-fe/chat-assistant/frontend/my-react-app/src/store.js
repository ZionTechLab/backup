import { configureStore } from '@reduxjs/toolkit';
import authReducer from './features/auth/authSlice';
// Import other reducers here if you have them

const store = configureStore({
  reducer: {
    auth: authReducer,
    // Add other reducers here
    // itineraries: itinerariesReducer, // Example
  },
});

export default store;
