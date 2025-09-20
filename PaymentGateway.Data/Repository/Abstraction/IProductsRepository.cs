using PaymentGateway.Data.Dtos;
using PaymentGateway.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Data.Repository.Abstraction
{
    public interface IProductsRepository
    {
        public Task AddProductsAsync(List<Products> addProducts);
        public Task<IEnumerable<ProductResponse>> GetProductsAsync();
    }
}
