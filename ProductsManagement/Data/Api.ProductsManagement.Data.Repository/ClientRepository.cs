using Api.ProductsManagement.Data.Context.Contract;
using Api.ProductsManagement.Data.Entity.Model;
using Api.ProductsManagement.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Api.ProductsManagement.Data.Repository
{
    public class ClientRepository : Repository<Client>, IRepository<Client>
    {
        // private readonly IProductsManagementDBContext _dbContext;

        public ClientRepository(IProductsManagementDBContext dbContext) : base(dbContext)
        {
        }

        /*public async Task<IEnumerable<Client>> GetAll()
        {
            return await _dbContext.Clients.ToListAsync().ConfigureAwait(false);
        } */
    }
}