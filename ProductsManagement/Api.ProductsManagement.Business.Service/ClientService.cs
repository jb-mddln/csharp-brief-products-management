using Api.ProductsManagement.Business.Dto.Client;
using Api.ProductsManagement.Data.Entity.Model;
using Api.ProductsManagement.Data.Repository.Contract;
using Api.ProductsManagement.Service.Contract;

namespace Api.ProductsManagement.Business.Service
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> _clientRepository;

        public ClientService(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<ReadClientDto>> GetClientsAsync()
        {
            var clients = await _clientRepository.GetAll().ConfigureAwait(false);

            return Enumerable.Empty<ReadClientDto>();
        }
    }
}