using Api.ProductsManagement.Data.Context.Contract;
using Api.ProductsManagement.Data.Entity.Model;

namespace Api.ProductsManagement.Data.Repository
{
    public class ClientAddressRepository : Repository<ClientsAddress>
    {
        public ClientAddressRepository(IProductsManagementDBContext dbContext) : base(dbContext)
        {
        }
    }
}