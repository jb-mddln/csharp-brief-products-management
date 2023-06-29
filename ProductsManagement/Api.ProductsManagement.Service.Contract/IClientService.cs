using Api.ProductsManagement.Business.Dto.Client;

namespace Api.ProductsManagement.Service.Contract
{
    public interface IClientService
    {
        Task<IEnumerable<ReadClientDto>> GetClientsAsync();

    }
}