using Microsoft.AspNetCore.Mvc;
using WebhookHandler.Application.Service.Abstraction;

namespace PaymentGateway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RazorpayWebhookController : ControllerBase
    {
        private readonly ILogger<RazorpayWebhookController> _logger;
        private readonly IWebhookService _webhookService;

        public RazorpayWebhookController(
            ILogger<RazorpayWebhookController> logger,
            IWebhookService webhookService)
        {
            _logger = logger;
            _webhookService = webhookService;
        }

        [HttpPost]
        public async Task<IActionResult> HandleWebhook()
        {
            _logger.LogInformation("Received Razorpay webhook");
            string body;
            using (var reader = new StreamReader(Request.Body))
            {
                body = await reader.ReadToEndAsync();
            }

            var signature = Request.Headers["X-Razorpay-Signature"].ToString();
            if (string.IsNullOrEmpty(signature))
            {
                _logger.LogWarning("Missing X-Razorpay-Signature header");
                return BadRequest("Missing signature");
            }
            var isValid = await _webhookService.ProcessWebhookAsync(body, signature);

            if (!isValid)
            {
                _logger.LogWarning("Invalid Razorpay signature");
                return Unauthorized("Invalid signature");
            }

            _logger.LogInformation("Webhook verified and processed successfully");
            return Ok();
        }
    }
}
