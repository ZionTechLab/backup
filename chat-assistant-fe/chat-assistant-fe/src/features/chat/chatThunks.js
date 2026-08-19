import { createAsyncThunk } from "@reduxjs/toolkit";
import {
  initChatSession,
  sendMessageToThread,
} from "../../services/chatApiService";
import { setThreadData } from "../../features/chat/chatSlice";

export const initChat = createAsyncThunk(
  "chat/initChat",
  async (_, thunkAPI) => {

    console.log("Initializing chat...");
    const state = thunkAPI.getState();
    const currentThreadId = state.chat.currentThreadId;

    if (!currentThreadId) {
      try {
        const data = await initChatSession(); // API call

        if (!data.threadId) {
          return thunkAPI.rejectWithValue("No threadId received from server.");
        }
        return {
          threadId: data.threadId,
        };
      } catch (error) {
        return thunkAPI.rejectWithValue(
          error.message || "Error initializing chat"
        );
      }
    }

    // If thread already exists, just skip
    return thunkAPI.rejectWithValue("Chat already initialized.");
  }
);

export const sendMessage = createAsyncThunk(
  "chat/sendMessage",
  async (message, thunkAPI) => {
    try {

      const state = thunkAPI.getState();
      let threadId = state.chat.currentThreadId;
      console.log("send message called");
         console.log(message);
      if (!threadId) {
       const initResult = await thunkAPI.dispatch(initChat());

        if (initChat.rejected.match(initResult)) {
          return thunkAPI.rejectWithValue("Failed to initialize chat.");
        }

        threadId = initResult.payload.threadId;
            console.log("thread initialized:", threadId);
      } 
    await thunkAPI.dispatch(setThreadData(

{
            id: Date.now(),
            text: message,
            sender: "user",
          }

    ));
      const response = await sendMessageToThread(threadId, message);
      console.log(response);
      return { threadId, message: response };
    } catch (err) {
      return thunkAPI.rejectWithValue(err.message);
    }
  }
);
