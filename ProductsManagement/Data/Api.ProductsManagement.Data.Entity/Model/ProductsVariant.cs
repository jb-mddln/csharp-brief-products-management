namespace Api.ProductsManagement.Data.Entity.Model
{
    public class ProductsVariant
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public string? Image { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}