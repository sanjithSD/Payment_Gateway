using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Cryptography;
using WebhookHandler.Application.Service.Abstraction;

namespace PaymentGateway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RazorpayWebhookController : ControllerBase
    {
        private readonly ILogger<RazorpayWebhookController> _logger;
        private readonly IWebhookService _webhookService;
        public RazorpayWebhookController(IConfiguration configuration, ILogger<RazorpayWebhookController> logger, IWebhookService webhookService)
        {
            _webhookService = webhookService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> HandleWebhook()
        {
            _logger.LogInformation("Received webhook");
            using var reader = new StreamReader(Request.Body);
            var body = await reader.ReadToEndAsync();
            var signature = Request.Headers["X-Razorpay-Signature"].ToString();

            var response = await _webhookService.ProcessWebhookAsync(body, signature);

            return response ? Ok() : BadRequest("Invalid webhook");
        }
    }
}
