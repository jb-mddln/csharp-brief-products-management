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
        private readonly IRepository<ClientAddress> _clientAddressRepository;

        public ClientService(IRepository<Client> clientRepository, IRepository<ClientAddress> clientAddressRepository)
        {
            _clientRepository = clientRepository;
            _clientAddressRepository = clientAddressRepository;
        }

        public async Task<IEnumerable<ReadClientDto>> GetClientsAsync()
        { 
            var clients = await _clientRepository.GetAll(client => client.Address).ConfigureAwait(false);
            return clients.Select(ClientMapper.EntityToDto);
        }

        public async Task<ReadClientDto> GetClientByIdAsync(int id)
        {
            var client = await _clientRepository.GetById(id, client => client.Address).ConfigureAwait(false);
            if (client == null)
            {
                throw new Exception($"Client {id} not found.");
            }

            return ClientMapper.EntityToDto(client);
        }

        public async Task<ReadClientDto> AddClientAsync(CreateClientDto clientDto)
        {
            if (clientDto == null)
            {
                throw new ArgumentNullException(nameof(clientDto));
            }

            var clientToAdd = ClientMapper.DtoToEntity(clientDto);

            var clientAdded = await _clientRepository.Add(clientToAdd).ConfigureAwait(false);
            return ClientMapper.EntityToDto(clientAdded);
        }

        public async Task<ReadClientDto> RemoveClientAsync(int id)
        {
            var client = await _clientRepository.GetById(id).ConfigureAwait(false);
            if (client == null)
            {
                throw new Exception($"Client {id} not found.");
            }

            var clientDeleted = await _clientRepository.Remove(client).ConfigureAwait(false);
            var addressDeleted = await _clientAddressRepository.Remove(clientDeleted.Address).ConfigureAwait(false);

            // todo remove orders, reviews infos ?

            return ClientMapper.EntityToDto(clientDeleted);
        }
    }
}