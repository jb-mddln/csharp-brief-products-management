namespace Api.ProductsManagement.Data.Entity.Model
{
    public class Client
    {
        public int Id { get; set; }

        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int AddressId { get; set; }

        public virtual ClientsAddress Address { get; set; } = null!;

        public virtual ICollection<ClientOrder> ClientOrders { get; set; } = new List<ClientOrder>();

        public virtual ICollection<ClientReview> ClientReviews { get; set; } = new List<ClientReview>();
    }
}
