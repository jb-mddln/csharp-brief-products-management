using Api.ProductsManagement.Data.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.ProductsManagement.Data.Context.Contract
{
    public interface IProductsManagementDBContext : IDBContext
    {
        DbSet<Client> Clients { get; set; }

        DbSet<ClientOrder> ClientOrders { get; set; }

        DbSet<ClientReview> ClientReviews { get; set; }

        DbSet<ClientAddress> ClientsAddresses { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<ProductCategory> ProductsCategories { get; set; }

        DbSet<ProductVariant> ProductsVariants { get; set; }
    }
}