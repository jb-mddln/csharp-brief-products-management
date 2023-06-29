using Api.ProductsManagement.Data.Context.Contract;

namespace Api.ProductsManagement.Data.Repository
{
    public class ClientReviewRepository : IClientReviewRepository
    {
        private readonly IProductsManagementDBContext _dbContext;

        public ClientReviewRepository(IProductsManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}