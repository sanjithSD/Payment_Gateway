import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const productsApi = createApi({
  reducerPath: 'productsApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:7253/api/' }),
  endpoints: (builder) => ({
    addProducts: builder.mutation({
      query: (products) => ({
        url: 'products',      
        method: 'POST',       
        body: products,       
      }),
    }),
    getProducts: builder.query({   
      query: () => 'products',     
    }),
  }),
});

export const { useAddProductsMutation, useGetProductsQuery } = productsApi; 
