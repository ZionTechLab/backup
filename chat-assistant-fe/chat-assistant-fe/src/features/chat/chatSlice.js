import { createSlice } from "@reduxjs/toolkit";
import { initChat, sendMessage } from "./chatThunks";

const initialState = {
  currentThreadId: null,
  isLoading: false,
  isError: false,
  error: null,
  threadData: [],
};

const chatSlice = createSlice({
  name: "chat",
  initialState,
  reducers: {
    setCurrentThreadId: (state, action) => {
      state.currentThreadId = action.payload;
    },
    clearCurrentThreadId: (state) => {
      state.currentThreadId = null;
      // state.threadData = null;
    },
     setThreadData: (state, action) => {
      state.threadData.push(  
      action.payload
      );
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(initChat.pending, (state) => {
        state.isLoading = true;
        state.error = null;
      })
      .addCase(initChat.fulfilled, (state, action) => {
        console.log(action);
        state.isLoading = false;
        state.currentThreadId = action.payload.threadId;
        // state.threadData = action.payload.data;
      })
      .addCase(initChat.rejected, (state, action) => {
        console.log(action);
        return {
          ...state,
          isLoading: false,
          isError: true,
          error: action.payload,
        };
      })

      .addCase(sendMessage.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(sendMessage.fulfilled, (state, action) => {
        state.isLoading = false;
        state.threadData.push(      {
        id: Date.now(),
        text:  action.payload.message.response   ,
        sender: "assistant",
      }          );




      })
      .addCase(sendMessage.rejected, (state, action) => {
        state.isLoading = false;
        state.isError = true;
        state.error = action.payload;
      });
  },
});

export const { setCurrentThreadId, clearCurrentThreadId } = chatSlice.actions;
export const { setThreadData } = chatSlice.actions;
export default chatSlice.reducer;

export const selectCurrentThreadId = (state) => state.chat.currentThreadId;
export const selectChatIsLoading = (state) => state.chat.isLoading;
export const selectChatError = (state) => state.chat.error;
export const selectThreadData = (state) => state.chat.threadData;
