using PaymentGateway.Shared.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Data.Entities
{
    public class Customer : TrackableEntity
    {
        public string Email { get; set; }
        public decimal Number { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
