import { createSlice } from "@reduxjs/toolkit";

export const userSlice = createSlice({
    name: "user",
    initialState: {
        value: {
            id: 0
            , firsName: ""
            , lastName: ""
            , username: ""
            , password: ""
            , created: ""
            , createdBy: ""
            , lastModified: ""
            , lastModifiedBy: ""
        }
    },
    reducers: {
        login: (state, action)=>{
            state.value = action.payload;
        },
        
    },
});

export default userSlice.reducer;