
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PaymentGateway.Data;
using WebhookHandler.Application.Service.Abstraction;
using WebhookHandler.Application.Service.Implementation;
using WebhookHandler.Data.Repository;

namespace WebhookHandler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContextFactory<DataDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IWebhookService, WebhookService>();
            builder.Services.AddScoped<IWebhookRepository, WebhookRepository>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
  
            app.UseAuthorization();
                

            app.MapControllers();

            app.Run();
        }
    }
}
