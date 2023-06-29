using Api.ProductsManagement.Data.Context.Contract;
using Api.ProductsManagement.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Api.ProductsManagement.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IProductsManagementDBContext _dbContext;

        protected DbSet<T> Entities => _dbContext.Set<T>();

        protected Repository(IProductsManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await Entities.ToListAsync().ConfigureAwait(false);
        }
    }
}