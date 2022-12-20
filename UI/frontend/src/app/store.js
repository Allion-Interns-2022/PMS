import { configureStore } from '@reduxjs/toolkit';
import counterReducer from './counter';
import userReducer from '../features/user';
import patientReducer from '../features/patient';

export const store = configureStore({
  reducer: {
    counter: counterReducer,
    user: userReducer,
    patient: patientReducer,

  },
})