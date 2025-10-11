using PaymentGateway.Shared.BaseEntities;
using PaymentGateway.Shared.Enum;

namespace PaymentGateway.Data.Entities
{
    public class Payment : TrackableEntity
    {
        public int ProductId { get; set; }
        public virtual Products Product { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int CardId { get; set; }
        public virtual Card Card { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public Status Status { get; set; }
        public string RazorpayPaymentId { get; set; }
        public string Notes { get; set; }
        public string PaymentMethod { get; set; }

    }

}
