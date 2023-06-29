using Api.ProductsManagement.Data.Context.Contract;
using Api.ProductsManagement.Data.Entity.Model;

namespace Api.ProductsManagement.Data.Repository
{
    public class ProductsVariantRepository : Repository<ProductsVariant>
    {
        public ProductsVariantRepository(IProductsManagementDBContext dbContext) : base(dbContext)
        {
        }
    }
}