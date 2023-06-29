namespace Api.ProductsManagement.Business.Dto.Client
{
    public class CreateClientDto
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int AddressId { get; set; }
    }
}