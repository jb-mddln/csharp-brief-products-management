using Api.ProductsManagement.Data.Context.Contract;

namespace Api.ProductsManagement.Data.Repository
{
    public class ClientAddressRepository : IClientAddressRepository
    {
        private readonly IProductsManagementDBContext _dbContext;

        public ClientAddressRepository(IProductsManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}