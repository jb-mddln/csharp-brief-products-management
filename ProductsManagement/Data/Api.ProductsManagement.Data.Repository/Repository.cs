using Api.ProductsManagement.Data.Context.Contract;
using Api.ProductsManagement.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.ProductsManagement.Data.Repository
{
    /// <summary>
    /// Base class for all our repository
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IProductsManagementDBContext _dbContext;

        protected DbSet<T> Entities => _dbContext.Set<T>();

        protected Repository(IProductsManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Return all the entities of type T, can be override to add Include
        /// </summary>
        /// <returns>List of entities of type T</returns>
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await Entities.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Return null or the entity of type T with the corresponding Id
        /// </summary>
        /// <param name="id">Id of the entity</param>
        /// <returns>Entity of type T</returns>
        /// <exception cref="InvalidOperationException">Throw InvalidOperationException if entity of type T does not have a Id property</exception>
        public virtual async Task<T?> GetById(int id)
        {
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty == null)
            {
                throw new InvalidOperationException($"Entity {typeof(T)} does not have an 'Id' property.");
            }
            
            var parameter = Expression.Parameter(typeof(T), "entity");
            var property = Expression.Property(parameter, "Id");
            var equality = Expression.Equal(property, Expression.Constant(id));

            var lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);

            return await Entities.FirstOrDefaultAsync(lambda).ConfigureAwait(false);
        }

        public virtual async Task<T> Add(T entity)
        {
            // should not happen ?
            if (entity.GetType() != typeof(T))
            {
                throw new InvalidOperationException("Invalid entity type");
            }

            var elementAdded = await Entities.AddAsync(entity).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        public virtual async Task<T> Remove(T entity)
        {
            var elementDeleted = Entities.Remove(entity);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;
        }
    }
}