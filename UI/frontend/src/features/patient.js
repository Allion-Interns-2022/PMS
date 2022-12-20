import { createSlice } from "@reduxjs/toolkit";
import { useDispatch } from "react-redux";

const Axios = require("axios");

export const patientSlice = createSlice({
    name: "patient",
    initialState: {
        value: {
            id: 0
            , name: ""
            , dob: ""
            , weightKG: 0
            , heightCM: 0
            , address: ""
            , contact: ""
            , emergencyContact: ""
        }
    },
    reducers: {
        allPatients: (state, action) => {
            state.value = action.payload;
        },
        addPatient: (state, action) => {
            state.value = [action.payload];
        },

    },
});

export const { addPatient, allPatients } = patientSlice.actions;



// export const allPatientsAsync = () => async () => {
//     // try {
//     //     const response = await axios.get("https://localhost:7197/api/patients");
//     //     dispatch(allPatients(response));dispatch(allPatients(response));
//     //     console.log(response);
//     // } catch (err) {
//     //     console.log(err);
//     //     throw new Error(err);
//     // }
    
//     Axios.get("https://localhost:7197/api/patients")
//             .then((response) => {
//                 dispatch(allPatients(response));
//                 const setPatientsList = response.data;
//                 console.log(setPatientsList);
//             })
// };

export const AllPatientsAsync = () => {
    const dispatch = useDispatch();
    return ( 
        Axios.get("https://localhost:7197/api/patients")
            .then((response) => {
                dispatch(allPatients(response));
                const setPatientsList = response.data;
                // console.log(setPatientsList);
            })
     );
};


// export const addPatientAsync = (value) => async (dispatch) => {
//     try {
//         // console.log(data);
//         const response = await axios.post("https://localhost:7197/api/patients", value);
//         // console.log(response);
//         dispatch(addPatient(response.value));
//     } catch (err) {
//         throw new Error(err);
//     }
// };

export default patientSlice.reducer;

export const patientDetails = (state) => state.patient.value;