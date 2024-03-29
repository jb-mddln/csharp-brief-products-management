﻿namespace Api.ProductsManagement.Data.Entity.Model
{
    public class ClientAddress
    {
        public int Id { get; set; }

        public string Address { get; set; } = null!;

        public string City { get; set; } = null!;

        public string ZipCode { get; set; } = null!;

        public string Country { get; set; } = null!;

        public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

        public override string ToString() => $"{Address}, {ZipCode} {City} {Country}";
    }
}
