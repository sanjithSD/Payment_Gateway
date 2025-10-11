
using PaymentGateway.Shared.BaseEntities;

namespace PaymentGateway.Data.Entities
{
    public class Products : TrackableEntity
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public bool isSold { get; set; } 
    }

}
