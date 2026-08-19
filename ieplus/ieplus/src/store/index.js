import { configureStore } from "@reduxjs/toolkit";
import { songsReducer, addSong, removeSong } from "./slices/songsSlice";
import { sakeReducer, addSake, removeSake } from "./slices/sakeSlice";
import {
  authReducer,
  setAuthStatus,
  loggin,
  init,
  setActiveForm,
} from "./slices/authSlice";
import { inventoryReducer, getInventory } from "./slices/inventorySlice";
import { userReducer, GetAllUsers, Update_User } from "./slices/userSlice";
import { reset } from "./actions";

const store = configureStore({
  reducer: {
    songs: songsReducer,
    sake: sakeReducer,
    auth: authReducer,
    inventory: inventoryReducer,
    user: userReducer,
  },
});

export {
  store,
  loggin,
  init,
  setAuthStatus,
  addSong,
  removeSong,
  addSake,
  removeSake,
  reset,
  setActiveForm,
  getInventory,
  GetAllUsers,
  Update_User,
};
