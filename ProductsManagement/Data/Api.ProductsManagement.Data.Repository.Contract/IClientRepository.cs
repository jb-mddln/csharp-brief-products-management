using Api.ProductsManagement.Data.Entity.Model;

namespace Api.ProductsManagement.Data.Repository.Contract
{
    public interface IClientRepository : IRepository<Client>
    {
        // Task<IEnumerable<Client>> GetClientsAsync();
    }
}