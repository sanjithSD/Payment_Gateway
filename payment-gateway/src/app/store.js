// src/app/store.js
import { configureStore } from '@reduxjs/toolkit';
import { productsApi } from '../services/ProductsApi';
import { TransactionsApi } from '../services/TransactionsApi';

export const store = configureStore({
  reducer: {
    [productsApi.reducerPath]: productsApi.reducer,
    [TransactionsApi.reducerPath]: TransactionsApi.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware()
      .concat(productsApi.middleware)
      .concat(TransactionsApi.middleware), 
});
