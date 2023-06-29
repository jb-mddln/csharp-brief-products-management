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
    }
}