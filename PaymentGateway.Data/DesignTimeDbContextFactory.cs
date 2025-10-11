using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PaymentGateway.Data;
using System.IO;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataDbContext>
{
    public DataDbContext CreateDbContext(string[] args)
    {
        //var config = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsettings.json")
        //    .Build();

        var optionsBuilder = new DbContextOptionsBuilder<DataDbContext>();
        optionsBuilder.UseSqlServer("Server=DESKTOP-8TIQ9UJ;Database=PaymentGateway;Trusted_Connection=True;TrustServerCertificate=True;");

        return new DataDbContext(optionsBuilder.Options);
    }
}