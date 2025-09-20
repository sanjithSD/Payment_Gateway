import React from 'react';
import { useGetTransactionsQuery } from '../services/TransactionsApi';

function DashboardPage() {
  const { data: transactions = [], isLoading, isError, refetch } = useGetTransactionsQuery();

  if (isLoading) return <p>Loading transactions...</p>;
  if (isError) return <p>Error fetching transactions!</p>;  

  return (
    <div>
      <h1 className="mb-4">Transactions</h1>
      <table className="table table-striped table-hover">
        <thead className="table-dark">
          <tr>
            <th>ID</th>
            <th>Product</th>
            <th>Amount</th>
            <th>Currency</th>
            <th>Status</th>
            <th>Date</th>
          </tr>
        </thead>
        <tbody>
          {transactions.length === 0 ? (
            <tr>
              <td colSpan="6" className="text-center">
                No transactions found
              </td>
            </tr>
          ) : (
            transactions.map(tx => (
              <tr key={tx.id}>
                <td>{tx.id}</td>
                <td>{tx.productTitle}</td>
                <td>${tx.amount}</td>
                <td>{tx.currency}</td>
                <td>{tx.status}</td>
                <td>{new Date(tx.createdAt).toLocaleString()}</td>
              </tr>
            ))
          )}
        </tbody>
      </table>
      <button className="btn btn-primary mt-3" onClick={refetch}>Refresh</button>
    </div>
  );
}

export default DashboardPage;
