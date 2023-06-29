using Api.ProductsManagement.Data.Context.Contract;

namespace Api.ProductsManagement.Data.Repository
{
    public class ProductsVariantRepository : IProductsVariantRepository
    {
        private readonly IProductsManagementDBContext _dbContext;

        public ProductsVariantRepository(IProductsManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}