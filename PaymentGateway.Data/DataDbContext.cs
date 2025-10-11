using Microsoft.EntityFrameworkCore;
using PaymentGateway.Data.Entities;

namespace PaymentGateway.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Card> Card { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Number)
                .IsUnique();

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Products>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Number)
                .HasPrecision(18, 0);
        }
    }
}
