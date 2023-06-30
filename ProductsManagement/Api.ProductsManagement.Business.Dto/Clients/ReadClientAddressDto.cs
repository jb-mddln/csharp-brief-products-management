namespace Api.ProductsManagement.Business.Dto.Client
{
    public class ReadClientAddressDto
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }
    }
}
