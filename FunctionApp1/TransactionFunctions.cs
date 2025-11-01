using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureSearchTransactions
{
    public class TransactionFunctions
    {
        private readonly ILogger<TransactionFunctions> _logger;

        public TransactionFunctions(ILogger<TransactionFunctions> logger)
        {
            _logger = logger;
        }

        [FunctionName(nameof(SearchTransactions))]
        public async Task<IActionResult> SearchTransactions([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("Azure Function HTTP trigger processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            ApiTransactionSearchParameters input = null;

            try
            {
                input = JsonSerializer.Deserialize<ApiTransactionSearchParameters>(
                    requestBody,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
            }
            catch
            {
                return new BadRequestObjectResult("Invalid JSON format.");
            }

            if (input == null)
                return new BadRequestObjectResult("Request body is missing or invalid.");

            return new OkObjectResult(new
            {
                message = "Welcome to Azure Functions!",
                inputReceived = input
            });
        }
    }

    public class ApiTransactionSearchParameters
    {
        public int? PaymentIds { get; set; }
        public string? CustomerIDs { get; set; }
        public decimal? AmountLessThan { get; set; }
        public decimal? AmountGreaterThan { get; set; }
        public decimal? Number { get; set; }
        public Status? Status { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 500;
        public int TotalCount { get; set; }
    }

    public enum Status
    {
        Authorized,
        Captured,
        Failed,
        Refund,
        PartialRefund
    }
}
