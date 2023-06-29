using Api.ProductsManagement.Data.Context.Contract;
using Api.ProductsManagement.Data.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.ProductsManagement.Data.Repository
{
    public class ClientRepository : Repository<Client>
    {
        public ClientRepository(IProductsManagementDBContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Return all the clients
        /// </summary>
        /// <returns>List of clients</returns>
        public override async Task<IEnumerable<Client>> GetAll() => await Entities.Include(x => x.Address).ToListAsync().ConfigureAwait(false);
    }
}