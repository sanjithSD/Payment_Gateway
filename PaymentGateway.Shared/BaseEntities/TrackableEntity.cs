
namespace PaymentGateway.Shared.BaseEntities
{
   public class TrackableEntity : ITrackableEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
   
    }
}
