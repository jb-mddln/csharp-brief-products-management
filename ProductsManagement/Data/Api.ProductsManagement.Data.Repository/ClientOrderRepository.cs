using Api.ProductsManagement.Data.Context.Contract;

namespace Api.ProductsManagement.Data.Repository
{
    public class ClientOrderRepository : IClientOrderRepository
    {
        private readonly IProductsManagementDBContext _dbContext;

        public ClientOrderRepository(IProductsManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}