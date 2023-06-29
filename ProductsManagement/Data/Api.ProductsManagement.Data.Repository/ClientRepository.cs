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
        public override async Task<IEnumerable<Client>> GetAll()
        {
            return await Entities.Include(client => client.Address).ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Return null or the client with the corresponding Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<Client?> GetById(int id)
        {
            return await Entities.Include(client => client.Address).FirstOrDefaultAsync(client => client.Id == id).ConfigureAwait(false);
        }
    }
}