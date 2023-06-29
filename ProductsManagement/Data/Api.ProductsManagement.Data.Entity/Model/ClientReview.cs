namespace Api.ProductsManagement.Data.Entity.Model
{
    public class ClientReview
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int ProductId { get; set; }

        public int? ProductVariantId { get; set; }

        public string Comment { get; set; } = null!;

        public short? Rating { get; set; }

        public virtual Client Client { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
