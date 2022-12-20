import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { patientSlice } from '../features/patient';

// Define a service using a base URL and expected endpoints
export const api = createApi({
  reducerPath: patientSlice.reducer,
  baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:7197/api/' }),
  endpoints: (builder) => ({
    getPokemonByName: builder.query({
      query: (name) => `pokemon/${name}`,
    }),
  }),
})