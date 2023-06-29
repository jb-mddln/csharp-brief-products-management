using Api.ProductsManagement.Business.Service;
using Api.ProductsManagement.Data.Context;
using Api.ProductsManagement.Data.Context.Contract;
using Api.ProductsManagement.Data.Entity.Model;
using Api.ProductsManagement.Data.Repository;
using Api.ProductsManagement.Data.Repository.Contract;
using Api.ProductsManagement.Service.Contract;
using Microsoft.EntityFrameworkCore;

namespace Api.ProductsManagement.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // Add services to the container.
            var connectionString = configuration.GetConnectionString("DatabaseConnection");
            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("No connection string found api can't start");

            builder.Services.AddDbContext<IProductsManagementDBContext, ProductsManagementDBContext>(
                options => options.UseNpgsql(connectionString)
            );

            builder.Services.AddScoped<IRepository<Client>, ClientRepository>();
            builder.Services.AddScoped<IRepository<ClientOrder>, ClientOrderRepository>();
            builder.Services.AddScoped<IRepository<ClientReview>, ClientReviewRepository>();
            builder.Services.AddScoped<IRepository<ClientAddress>, ClientAddressRepository>();
            builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
            builder.Services.AddScoped<IRepository<ProductCategory>, ProductCategoryRepository>();
            builder.Services.AddScoped<IRepository<ProductVariant>, ProductVariantRepository>();

            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IClientOrderService, ClientOrderService>();
            builder.Services.AddScoped<IClientReviewService, ClientReviewService>();
            builder.Services.AddScoped<IClientAddressService, ClientAddressService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
            builder.Services.AddScoped<IProductVariantService, ProductVariantService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}