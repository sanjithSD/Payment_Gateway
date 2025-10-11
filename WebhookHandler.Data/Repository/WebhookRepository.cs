using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PaymentGateway.Data;
using PaymentGateway.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebhookHandler.Data.Repository
{
    public interface IWebhookRepository { 
        Task AddPaymentAsync(Payment paymentEntity);
    }

    public class WebhookRepository : IWebhookRepository
    {
        private readonly IDbContextFactory<DataDbContext> _contextFactory;
        private readonly ILogger<WebhookRepository> _logger;

        public WebhookRepository(IDbContextFactory<DataDbContext> contextFactory, ILogger<WebhookRepository> logger)
        {
            _contextFactory = contextFactory;
            _logger = logger;
        }

        public async Task AddPaymentAsync(Payment paymentEntity)
        {
            using var context = _contextFactory.CreateDbContext();

            // Ensure Product exists
            var product = await context.Products
                .FirstOrDefaultAsync(p => p.ProductId == paymentEntity.ProductId);    
            if (product == null)
            {
                _logger.LogWarning("Payment received with invalid ProductId: {ProductId}", paymentEntity.ProductId);
                throw new InvalidOperationException($"ProductId {paymentEntity.ProductId} does not exist.");
            }
            paymentEntity.Product = product;

            var customer = await context.Customer
                .Include(c => c.Cards)
                .FirstOrDefaultAsync(c =>
                    c.Number == paymentEntity.Customer.Number);

            if (customer == null)
            {
                customer = paymentEntity.Customer;
                context.Customer.Add(customer);
            }
            else
            {
                foreach (var card in paymentEntity.Customer.Cards)
                {
                    if (!customer.Cards.Any(c => c.Id == card.Id || c.Last4 == card.Last4))
                    {
                        customer.Cards.Add(card);
                    }
                }
            }
            paymentEntity.Customer = customer;

            var existingCard = customer.Cards.FirstOrDefault(c => c.Id == paymentEntity.Card.Id);
            if (existingCard != null)
            {
                paymentEntity.Card = existingCard; 
            }

            if (paymentEntity.ProductId == 0)
            {
                _logger.LogWarning("Payment received with missing ProductId.");
                throw new InvalidOperationException("ProductId is required for payment.");
            }
            context.Payment.Add(paymentEntity);

            await context.SaveChangesAsync();
        }
    }

}
