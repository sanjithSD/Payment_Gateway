using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Data.Dtos;
using PaymentGateway.Application.Service.Abstraction;

namespace PaymentGateway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProductsService productsService, ILogger<ProductsController> logger)
        {
            _productsService= productsService;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> ImportProducts([FromBody] IEnumerable<AddProductsDto> products)
        {
            _logger.LogInformation("Importing products");
            await _productsService.ImportProductsAsync(products);
            return Ok("Products imported successfully");
        }
        [HttpGet]
        public async Task<IActionResult> Products()
        {
            _logger.LogInformation("Getting products");
            var products = await _productsService.GetProductsAsync();
            return Ok(products);
        }
    }
}
