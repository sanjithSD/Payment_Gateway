using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentGateway.Shared.Enum;

namespace PaymentGateway.Data.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Products Product { get; set; }

        public int PaymentGatewayId { get; set; }
        public  Gateway PaymentGateway { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public Status Status { get; set; }
        public string RazorpayPaymentId { get; set; }
        public string Notes { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
