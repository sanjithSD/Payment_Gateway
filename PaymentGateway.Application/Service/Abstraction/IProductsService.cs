using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Data.Dtos;

namespace PaymentGateway.Application.Service.Abstraction
{
    public interface IProductsService
    {
        public Task ImportProductsAsync(IEnumerable<AddProductsDto> products);
        public Task<IEnumerable<ProductResponse>> GetProductsAsync();
    }
}
