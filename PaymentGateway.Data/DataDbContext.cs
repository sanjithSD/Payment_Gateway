using Microsoft.EntityFrameworkCore;
using PaymentGateway.Data.Entities;

namespace PaymentGateway.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Gateway> PaymentGateway { get; set; }
        public DbSet<Customer> Customer { get; set; }

    }
}
