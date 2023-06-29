using Api.ProductsManagement.Data.Context.Contract;
using Api.ProductsManagement.Data.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.ProductsManagement.Data.Context
{
    public class ProductsManagementDBContext : DbContext, IProductsManagementDBContext
    {
        public ProductsManagementDBContext()
        {
        }

        public ProductsManagementDBContext(DbContextOptions<ProductsManagementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<ClientOrder> ClientOrders { get; set; }

        public virtual DbSet<ClientReview> ClientReviews { get; set; }

        public virtual DbSet<ClientAddress> ClientsAddresses { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductCategory> ProductsCategories { get; set; }

        public virtual DbSet<ProductVariant> ProductsVariants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("clients_pkey");

                entity.ToTable("clients");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.AddressId).HasColumnName("address_id");
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.HasOne(d => d.Address).WithMany(p => p.Clients)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clients_address_id_fkey");
            });

            modelBuilder.Entity<ClientOrder>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("client_orders_pkey");

                entity.ToTable("client_orders");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ClientId).HasColumnName("client_id");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductVariantId)
                    .HasDefaultValueSql("'-1'::integer")
                    .HasColumnName("product_variant_id");
                entity.Property(e => e.Quantity)
                    .HasDefaultValueSql("1")
                    .HasColumnName("quantity");
                entity.Property(e => e.Statut)
                    .HasDefaultValueSql("'-1'::integer")
                    .HasColumnName("statut");

                entity.HasOne(d => d.Client).WithMany(p => p.ClientOrders)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("client_orders_client_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.ClientOrders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("client_orders_product_id_fkey");
            });

            modelBuilder.Entity<ClientReview>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("client_reviews_pkey");

                entity.ToTable("client_reviews");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ClientId).HasColumnName("client_id");
                entity.Property(e => e.Comment).HasColumnName("comment");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductVariantId)
                    .HasDefaultValueSql("'-1'::integer")
                    .HasColumnName("product_variant_id");
                entity.Property(e => e.Rating)
                    .HasDefaultValueSql("'-1'::integer")
                    .HasColumnName("rating");

                entity.HasOne(d => d.Client).WithMany(p => p.ClientReviews)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("client_reviews_client_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.ClientReviews)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("client_reviews_product_id_fkey");
            });

            modelBuilder.Entity<ClientAddress>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("clients_addresses_pkey");

                entity.ToTable("clients_addresses");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Address).HasColumnName("address");
                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");
                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .HasColumnName("country");
                entity.Property(e => e.ZipCode)
                    .HasMaxLength(50)
                    .HasColumnName("zip_code");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("products_pkey");

                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Image).HasColumnName("image");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
                entity.Property(e => e.Price)
                    .HasPrecision(8, 3)
                    .HasColumnName("price");

                entity.HasOne(d => d.Category).WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("products_category_id_fkey");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("products_categories_pkey");

                entity.ToTable("products_categories");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ProductVariant>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("products_variants_pkey");

                entity.ToTable("products_variants");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Image).HasColumnName("image");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
                entity.Property(e => e.Price)
                    .HasPrecision(8, 3)
                    .HasColumnName("price");
                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Product).WithMany(p => p.ProductsVariants)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("products_variants_product_id_fkey");
            });

            // OnModelCreatingPartial(modelBuilder);
        }

        // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
