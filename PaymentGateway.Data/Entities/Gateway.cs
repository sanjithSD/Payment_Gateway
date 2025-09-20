
namespace PaymentGateway.Data.Entities
{
    public class Gateway
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
        public bool IsActive { get; set; }
    }

}


