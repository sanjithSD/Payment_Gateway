using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Data.Dtos;
using PaymentGateway.Data.Entities;
using PaymentGateway.Data.Repository.Abstraction;
namespace PaymentGateway.Data.Repository.Implementation
{
    public class ProductsRepository :IProductsRepository
    {
        private readonly DataDbContext _context;
        private readonly IMapper _mapper;
        public ProductsRepository(DataDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task  AddProductsAsync(List<Products> addProducts)
        {
            try
            {
                await _context.Products.AddRangeAsync(addProducts);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding products", ex);
            }
        }
        public async Task<IEnumerable<ProductResponse>> GetProductsAsync()
        {
            var entities = await _context.Products.ToListAsync();
            return _mapper.Map<IEnumerable<ProductResponse>>(entities);
        }

    }
}
