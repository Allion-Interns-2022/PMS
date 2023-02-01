import { configureStore } from '@reduxjs/toolkit';
import counterReducer from './counter';
import userReducer from '../features/user';
import patientReducer from '../features/patient';

export const store = configureStore({
  reducer: {
    counter: counterReducer,
    patient: patientReducer,
    user: userReducer,

  },
})

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>;
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof store.dispatch;