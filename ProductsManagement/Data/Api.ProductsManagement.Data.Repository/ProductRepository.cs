using Api.ProductsManagement.Data.Context.Contract;

namespace Api.ProductsManagement.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductsManagementDBContext _dbContext;

        public ProductRepository(IProductsManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}