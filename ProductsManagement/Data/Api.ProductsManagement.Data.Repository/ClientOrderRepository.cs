using Api.ProductsManagement.Data.Context.Contract;
using Api.ProductsManagement.Data.Entity.Model;

namespace Api.ProductsManagement.Data.Repository
{
    public class ClientOrderRepository : Repository<ClientOrder>
    {
        public ClientOrderRepository(IProductsManagementDBContext dbContext) : base(dbContext)
        {
        }
    }
}