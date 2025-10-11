using PaymentGateway.Shared.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Data.Entities
{
    public  class Card:TrackableEntity
    {
        public string Last4 { get; set; }
        public string Network { get; set; }
        public string Type { get; set; }
        public string Issuer { get; set; }
    }
}
