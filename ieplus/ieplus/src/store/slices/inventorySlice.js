import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import * as Config from '../../Common/Config';
import axios from 'axios';
import linq from "linq";



export const getInventoryAsync = createAsyncThunk(
  'inventory/getInventoryAsync',
  async (payload) => {

    console.log(payload);


    let url = Config.API_URL + 'Inventory/Get_Inventory';
    const response = await axios.get(url);
    console.log(response.data);

    console.log(payload);
    let data = JSON.parse(localStorage.getItem("itemPricing"));
    const result = data.filter(
      (p) => p.route_Code.toUpperCase() == payload.route
    );

    const result3 = linq
    .from(JSON.parse(localStorage.getItem("items")))
    .join(
      response.data,
      (pk) => pk.item_ID,
      (fk) => fk.item_ID,
      (left, right) => ({ ...left, ...right })
    ).join(
      result,
      (pk) => pk.item_ID,
      (fk) => fk.item_ID,
      (left, right) => ({ ...left, ...right })
    )
    .toArray();
    //console.log(result3);

    return result3;
    
  }
);







const inventorySlice = createSlice({
  name: 'inventory',
  initialState: { init: [],stock: [], status: 'idle' },
  reducers: {
    test(state, action) {
      state.push(action.payload);
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getInventoryAsync.pending, (state) => {
        return {...state,
          status:'Processing',
        };
      })
      .addCase(getInventoryAsync.fulfilled, (state, action) => {
        return {...state,
          status:'pass',
          stock : action.payload
        };

      })  ;
  },
});

// export const { test } = inventorySlice.actions;
export const inventoryReducer = inventorySlice.reducer;

export const getInventory = (payload) => (dispatch) => {
  dispatch(getInventoryAsync(payload));
};
