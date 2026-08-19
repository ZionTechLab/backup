import{createSlice} from '@reduxjs/toolkit'
import {reset} from '../actions'

const sakeSlice = createSlice({
    name: 'sake',
    initialState: ['PK', 'GK'],
    reducers: {
      addSake(state, action) {
        state.push(action.payload);
      },
      removeSake(state, action) {
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
        })
 

  export const {addSake,removeSake}=sakeSlice.actions;
export const sakeReducer= sakeSlice.reducer;