using Api.ProductsManagement.Business.Dto.Client;
using Api.ProductsManagement.Data.Entity.Model;

namespace Api.ProductsManagement.Business.Mapper
{
    public static class ClientMapper
    {
        public static Client DtoToEntity(CreateClientDto clientDto)
        {
            return new Client
            {
                LastName = clientDto.LastName,
                FirstName = clientDto.FirstName,
                Email = clientDto.Email,
                Password = clientDto.Password,
                AddressId = clientDto.AddressId
            };
        }

        public static ReadClientDto EntityToDto(Client client)
        {
            return new ReadClientDto
            {
                Id = client.Id,
                LastName = client.LastName,
                FirstName = client.FirstName,
                Email = client.Email,
                Password = client.Password,
                AddressId = client.AddressId,
                Address = client.Address.ToString(),
            };
        }
    }
}