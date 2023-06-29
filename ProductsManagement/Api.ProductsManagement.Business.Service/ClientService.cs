using Api.ProductsManagement.Business.Dto.Client;
using Api.ProductsManagement.Business.Mapper;
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

            return clients.Select(ClientMapper.EntityToDto);
        }

        public async Task<ReadClientDto> GetClientByIdAsync(int id)
        {
            var client = await _clientRepository.GetById(id).ConfigureAwait(false);
            if (client == null)
            {
                throw new Exception($"Client {id} not found.");
            }

            return ClientMapper.EntityToDto(client);
        }
    }
}