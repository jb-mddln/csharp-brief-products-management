using Api.ProductsManagement.Data.Context.Contract;
using Api.ProductsManagement.Data.Entity.Model;

namespace Api.ProductsManagement.Data.Repository
{
    public class ClientReviewRepository : Repository<ClientReview>
    {
        public ClientReviewRepository(IProductsManagementDBContext dbContext) : base(dbContext)
        {
        }
    }
}