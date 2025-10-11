using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Application.Service.Abstraction;
using PaymentGateway.Data.Entities;
using PaymentGateway.Shared.BaseEntities;
using PaymentGateway.Shared.Enum;

namespace PaymentGateway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        private readonly ILogger<TransactionsController> _logger;
        private readonly ITransactionService _transactionsService; 
        public TransactionsController(ILogger<TransactionsController> logger, ITransactionService transactionsService)
        {
            _logger = logger;
            _transactionsService = transactionsService;
        }
        [HttpGet]
        public async Task<IActionResult> SearchTransactions(ApiTransactionSearchParameters queryparameters)
        {
            try
            {
                //var data=queryparameters.
                //var response = await _transactionsService.SearchTransactionsAsync(queryparameters);
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Error searching transactions");
                return StatusCode(500, "Internal server error");
            }
            _logger.LogInformation("Getting transactions");
            return Ok();
        }
    }
    public class ApiTransactionSearchParameters : BaseParameters
    {
     [FromQuery(Name = "paymentIds")  ]
     public int? PaymentIds { get; set; }
     [FromQuery(Name = "customerIDs")]
     public string? CustomerIDs { get; set; }
    [FromQuery(Name = "amountLessThan")]
     public decimal? AmountlessThan { get; set; }
     [FromQuery(Name = "amountGreaterThan")]    
     public decimal? AmountGreaterThan { get; set; }
     [FromQuery(Name = "number")]
     public decimal? Number { get; set; }
     [FromQuery(Name = "status")]
     public Status? Status { get; set; }
    }
}
