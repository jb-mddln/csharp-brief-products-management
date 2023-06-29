namespace Api.ProductsManagement.Data.Entity.Model
{
    public class ClientOrder
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int ProductId { get; set; }

        public int? ProductVariantId { get; set; }

        public int Quantity { get; set; }

        public short? Statut { get; set; }

        public virtual Client Client { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
