    import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

    export const TransactionsApi = createApi({
    reducerPath: 'TransactionsApi',
    baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:7253/api/' }),
    endpoints: (builder) => ({
        getTransactions: builder.query({
        query: () => 'transactions', 
        }),
    }),
    });

    export const { useGetTransactionsQuery } = TransactionsApi;
