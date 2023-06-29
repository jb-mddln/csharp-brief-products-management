using Api.ProductsManagement.Data.Context.Contract;
using Api.ProductsManagement.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Api.ProductsManagement.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IProductsManagementDBContext _dbContext;

        protected DbSet<T> Items => _dbContext.Set<T>();

        protected Repository(IProductsManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Items.ToListAsync().ConfigureAwait(false);
        }
    }
}