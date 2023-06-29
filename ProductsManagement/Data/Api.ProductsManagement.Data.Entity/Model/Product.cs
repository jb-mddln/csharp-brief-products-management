namespace Api.ProductsManagement.Data.Entity.Model
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? Image { get; set; }

        public virtual ProductCategory Category { get; set; } = null!;

        public virtual ICollection<ClientOrder> ClientOrders { get; set; } = new List<ClientOrder>();

        public virtual ICollection<ClientReview> ClientReviews { get; set; } = new List<ClientReview>();

        public virtual ICollection<ProductVariant> ProductsVariants { get; set; } = new List<ProductVariant>();
    }
}
