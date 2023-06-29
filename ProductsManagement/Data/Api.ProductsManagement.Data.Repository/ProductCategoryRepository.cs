using Api.ProductsManagement.Data.Context.Contract;

namespace Api.ProductsManagement.Data.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly IProductsManagementDBContext _dbContext;

        public ProductCategoryRepository(IProductsManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}