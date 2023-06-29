using Api.ProductsManagement.Data.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.ProductsManagement.Data.Context.Contract
{
    public interface IProductsManagementDBContext : IDBContext
    {
        DbSet<Client> Clients { get; set; }

        DbSet<ClientOrder> ClientOrders { get; set; }

        DbSet<ClientReview> ClientReviews { get; set; }

        DbSet<ClientsAddress> ClientsAddresses { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<ProductsCategory> ProductsCategories { get; set; }

        DbSet<ProductsVariant> ProductsVariants { get; set; }
    }
}