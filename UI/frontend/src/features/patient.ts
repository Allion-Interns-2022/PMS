import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { useDispatch } from "react-redux";
import Axios from "axios";


interface PatientState {
  value: {
    id: number,
    name: string,
    dob: Date,
    weightKG: number,
    heightCM: number,
    address: string,
    contact: string,
    emergencyContact: string,
  }
}

// Define the initial state using that type
const initialState: PatientState = {
  value: {
    id: 0,
    name: "",
    dob: new Date,
    weightKG: 0,
    heightCM: 0,
    address: "",
    contact: "",
    emergencyContact: "",
  },
}

export const patientSlice = createSlice({
  name: "patient",
  initialState,
  reducers: {
    allPatients: (state, action: PayloadAction<PatientState["value"]>) => {
      state.value = action.payload;
    },
    addPatient: (state, action: PayloadAction<PatientState["value"]>) => {
      state.value = action.payload;
    },
  },
});

export const patientActions = patientSlice.actions;

export default patientSlice.reducer;

