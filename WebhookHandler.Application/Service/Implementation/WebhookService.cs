
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebhookHandler.Application.Service.Abstraction;
using WebhookHandler.Data.Dtos;
using WebhookHandler.Data.Repository;
using WebhookHandler.Data.Utils;

namespace WebhookHandler.Application.Service.Implementation
{
    public class WebhookService : IWebhookService
    {
        private readonly string _secret;
        private readonly ILogger<WebhookService> _logger;
        private readonly IWebhookRepository _webhookRepository; 

        public WebhookService(IConfiguration configuration, ILogger<WebhookService> logger, IWebhookRepository webhookRepository)
        {
            _secret = configuration["webhooksecretkey"];
            _webhookRepository = webhookRepository;
            _logger = logger;
        }

        public async Task<bool> ProcessWebhookAsync(string body, string signature)
        {
            if (!VerifySignature(body, signature, _secret))
            {
                _logger.LogWarning("Invalid signature");
                return false;
            }
            var webhook = JsonSerializer.Deserialize<RazorpayWebhook>(body,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, true) }
            });

            if (webhook == null)
            {
                _logger.LogError("Webhook payload deserialization failed");
                return false;
            }
            var paymentEntity = RazorpayWebhookMapper.MapToPayment(webhook);
            await _webhookRepository.AddPaymentAsync(paymentEntity);

            return true;
        }
        private bool VerifySignature(string body, string signature, string secret)
        {
            //Have to check
            //var secretBytes = Encoding.UTF8.GetBytes(secret);
            //using var hmac = new HMACSHA256(secretBytes);
            //var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(body));

            //// Convert to lowercase hex string
            //var generatedSignature = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();

            //return generatedSignature == signature;
            return true;
        }
    }

}
