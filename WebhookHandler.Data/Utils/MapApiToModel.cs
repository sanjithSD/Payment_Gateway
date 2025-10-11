using PaymentGateway.Data.Entities;
using PaymentGateway.Shared.Enum;
using WebhookHandler.Data.Dtos;

namespace WebhookHandler.Data.Utils
{
    public static class RazorpayWebhookMapper
    {
        public static Payment MapToPayment(RazorpayWebhook webhook)
        {
            var paymentDto = webhook.Payload.Payment.Entity;

            var cardEntity = new PaymentGateway.Data.Entities.Card
            {
                Last4 = paymentDto.Card?.Last4,
                Network = paymentDto.Card?.Network,
                Type = paymentDto.Card?.Type,   
                Issuer = paymentDto.Card?.Issuer,
                Created = DateTime.UtcNow,
                LastModified = DateTime.UtcNow
            };

            var customerEntity = new Customer
            {
                Email = paymentDto.Email,
                Number = decimal.Parse(paymentDto.Contact), 
                Address = paymentDto.Notes?.Address,
                Cards = new List<PaymentGateway.Data.Entities.Card> { cardEntity },
                Created = DateTime.UtcNow,
                LastModified = DateTime.UtcNow
            };

            var paymentEntity = new Payment
            {
                Customer = customerEntity,
                Card = cardEntity,
                Description = paymentDto.Description,
                Amount = paymentDto.Amount, 
                Currency = paymentDto.Currency,
                Status = MapStatus(paymentDto.Status),
                RazorpayPaymentId = paymentDto.Id,
                PaymentMethod = paymentDto.Method,
                Notes = paymentDto.Notes?.Address,
                Created = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
                ProductId = paymentDto.Notes?.productID != null ? int.Parse(paymentDto.Notes.productID) : 0 
            };

            return paymentEntity;
        }

        private static Status MapStatus(PaymentStatus status)
        {
            return status switch
            {
                PaymentStatus.Authorized => Status.Authorized,
                PaymentStatus.Captured => Status.Captured,
                PaymentStatus.Failed => Status.Failed,
                PaymentStatus.Refunded => Status.Refund,
                _ => Status.Failed
            };
        }
    }
}
