"use client"; //this is a client side component

import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  users: [],
  genreFilter: [],
  sortAge: [],
  averageAge: 0,
};

export const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    GET_USERS: (store, action) => { 
        store.users = action.payload
    }
  },
});

export const { GET_USERS } = userSlice.actions

export default userSlice.reducer;