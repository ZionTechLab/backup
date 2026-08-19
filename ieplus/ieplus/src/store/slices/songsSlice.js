import { createSlice } from '@reduxjs/toolkit';
import { reset } from '../actions';

const songsSlice = createSlice({
  name: 'song',
  initialState: ['PK', 'GK'],
  reducers: {
    addSong(state, action) {
      state.push(action.payload);
    },
    removeSong(state, action) {
      const index = state.indexOf(action.payload);
      if (index !== -1) {
        state.splice(index, 1);
      }
    },
  },
  extraReducers: (builder) => {
    builder.addCase(reset, (state, action) => {
      return [];
    });
  },
});

export const { addSong, removeSong } = songsSlice.actions;
export const songsReducer = songsSlice.reducer;
