using Api.ProductsManagement.Data.Context.Contract;
using Api.ProductsManagement.Data.Entity.Model;

namespace Api.ProductsManagement.Data.Repository
{
    public class ClientRepository : Repository<Client>
    {
        public ClientRepository(IProductsManagementDBContext dbContext) : base(dbContext)
        {
        }
    }
}