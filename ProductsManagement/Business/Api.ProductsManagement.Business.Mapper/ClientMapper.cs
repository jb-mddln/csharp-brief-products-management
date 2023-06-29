using Api.ProductsManagement.Business.Dto.Client;
using Api.ProductsManagement.Business.Dto.Clients;
using Api.ProductsManagement.Data.Entity.Model;

namespace Api.ProductsManagement.Business.Mapper
{
    public static class ClientMapper
    {
        #region client
        public static Client DtoToEntity(CreateClientDto clientDto)
        {
            return new Client
            {
                LastName = clientDto.LastName,
                FirstName = clientDto.FirstName,
                Email = clientDto.Email,
                Password = clientDto.Password,
                Address = DtoToEntity(clientDto.Address)
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
                Address = EntityToDto(client.Address)
            };
        }
        #endregion

        #region address
        public static ClientAddress DtoToEntity(CreateClientAddressDto clientAddressDto)
        {
            return new ClientAddress
            {
                Address = clientAddressDto.Address,
                City = clientAddressDto.City,
                ZipCode = clientAddressDto.ZipCode,
                Country = clientAddressDto.Country
            };
        }

        public static ReadClientAddressDto EntityToDto(ClientAddress clientAddress)
        {
            return new ReadClientAddressDto
            {
                Id = clientAddress.Id,
                Address = clientAddress.Address,
                City = clientAddress.City,
                ZipCode = clientAddress.ZipCode,
                Country = clientAddress.Country
            };
        }
        #endregion
    }
}