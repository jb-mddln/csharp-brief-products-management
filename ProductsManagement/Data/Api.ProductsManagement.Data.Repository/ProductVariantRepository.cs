using Api.ProductsManagement.Data.Context.Contract;
using Api.ProductsManagement.Data.Entity.Model;

namespace Api.ProductsManagement.Data.Repository
{
    public class ProductVariantRepository : Repository<ProductVariant>
    {
        public ProductVariantRepository(IProductsManagementDBContext dbContext) : base(dbContext)
        {
        }
    }
}