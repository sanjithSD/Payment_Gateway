using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
    }
}
