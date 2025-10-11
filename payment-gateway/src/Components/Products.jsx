import React, { useState } from 'react';
import { useGetProductsQuery } from '../services/ProductsApi';

function Products() {
  const [selectedProduct, setSelectedProduct] = useState(null);

  // Use RTK Query
  const { data: products = [], isLoading, isError } = useGetProductsQuery();

  const handleSelectProduct = (product) => setSelectedProduct(product);

  const handlePay = () => {
    if (!selectedProduct) return;

    const options = {
      key: "rzp_test_RJnt7ZIdyUZQzi",
      amount: selectedProduct.price * 100,
      currency: "USD",
      name: "Acme Corp",
      description: "Test Transaction",
      handler: function (response) {
        alert(`Payment Successful! ID: ${response.razorpay_payment_id}`);
      },
      notes: { address: "Razorpay Corporate Office",product_id: selectedProduct.productId.toString(),
},    
      theme: { color: "#3399cc" }
    };
    console.log("product ID fromoptions:", selectedProduct.productId); // Debugging line

    const rzp1 = new window.Razorpay(options);
    rzp1.open();

    rzp1.on('payment.failed', function (response) {
      alert(`Payment failed: ${response.error.description}`);
    });
  };

  if (isLoading) return <p className="text-center mt-5">Loading products...</p>;
  if (isError) return <p className="text-center mt-5 text-danger">Failed to load products!</p>;

  // Render selected product
  if (selectedProduct) {
    return (
      <div className="container mt-5 d-flex justify-content-center">
        <div className="d-flex border border-3 p-3" style={{ maxWidth: '850px', gap: '20px' }}>
          <img
            src={selectedProduct.imageUrl}
            className="card-img-top"
            style={{ width: '414px', height: '414px', objectFit: 'cover' }}
            alt={selectedProduct.title}
          />
          <div className="card-body">
            <h5 className="fw-bold mt-3">{selectedProduct.title}</h5>
            <p className="card-text">{selectedProduct.description}</p>
            <p><strong>Price: ${selectedProduct.price}</strong></p>
            <button className="btn btn-primary me-2" onClick={handlePay}>Pay Now</button>
            <button className="btn btn-danger" onClick={() => setSelectedProduct(null)}>Back</button>
          </div>
        </div>
      </div>
    );
  }

  // Render product list
  return (
    <>
      <h1 className="mb-5 text-center title">Products</h1>
      <div className="row">
        {products.map(product => (
          <div className="col-6 col-md-3 mb-4" key={product.productId}>
            <div
              className="card h-100 shadow-sm hover-card"
              onClick={() => handleSelectProduct(product)}
              style={{ cursor: 'pointer' }}
            >
              <div className="product-img-wrapper">
                <img
                  src={product.imageUrl}
                  className="card-img-top product-img"
                  alt={product.title}
                />
              </div>
              <div className="card-body text-center">
                <h5 className="card-title">{product.title}</h5>
                <p className="card-text fw-bold">${product.price}</p>
              </div>
            </div>
          </div>
        ))}
      </div>
    </>
  );
}

export default Products;
