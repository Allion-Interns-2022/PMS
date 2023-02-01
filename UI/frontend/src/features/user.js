import { createSlice } from "@reduxjs/toolkit";

export const userSlice = createSlice({
  name: "user",
  initialState: {
    value: {
      id: 0,
      firsName: "",
      lastName: "",
      username: "",
      password: "",
      created: "",
      createdBy: "",
      lastModified: "",
      lastModifiedBy: "",
    },
    isAuthenticated: false,
  },
  reducers: {
    login: (state) => {
      state.isAuthenticated = true;
    },

    logout: (state, action) => {
      state.isAuthenticated = false;
    },

    signup: (state, action) => {
      state.value = action.payload;
    },
  },
});

export const userActions = userSlice.actions;
export default userSlice.reducer;
