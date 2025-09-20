using AutoMapper;
using Microsoft.Extensions.Logging;
using PaymentGateway.Application.Service.Abstraction;
using PaymentGateway.Data.Dtos;
using PaymentGateway.Data.Entities;
using PaymentGateway.Data.Repository.Abstraction;

public class ProductsService : IProductsService
{
    private readonly IProductsRepository _productsRepository;
    private readonly ILogger<ProductsService> _logger;
    private readonly IMapper _mapper;

    public ProductsService(
        IProductsRepository productsRepository,
        ILogger<ProductsService> logger,
        IMapper mapper)
    {
        _productsRepository = productsRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task ImportProductsAsync(IEnumerable<AddProductsDto> products)
    {
        try
        {
            var productEntities = _mapper.Map<List<Products>>(products);
            await _productsRepository.AddProductsAsync(productEntities);
            _logger.LogInformation("Products imported successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error importing products");
        }
    }
    public Task<IEnumerable<ProductResponse>> GetProductsAsync()
    {
        return _productsRepository.GetProductsAsync();
    }

}
