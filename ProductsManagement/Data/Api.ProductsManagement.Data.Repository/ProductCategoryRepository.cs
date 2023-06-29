using Api.ProductsManagement.Data.Context.Contract;
using Api.ProductsManagement.Data.Entity.Model;

namespace Api.ProductsManagement.Data.Repository
{
    public class ProductCategoryRepository : Repository<ProductCategory>
    {
        public ProductCategoryRepository(IProductsManagementDBContext dbContext) : base(dbContext)
        {
        }
    }
}