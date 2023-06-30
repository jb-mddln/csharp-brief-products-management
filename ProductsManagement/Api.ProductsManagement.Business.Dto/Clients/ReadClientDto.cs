namespace Api.ProductsManagement.Business.Dto.Client
{
    public class ReadClientDto : CreateClientDto
    {
        public int Id { get; set; }

        public ReadClientAddressDto Address { get; set; }
    }
}
