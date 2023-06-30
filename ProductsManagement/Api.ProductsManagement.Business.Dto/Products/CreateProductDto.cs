namespace Api.ProductsManagement.Business.Dto.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? Image { get; set; }

        public CreateProductCategoryDto Category { get; set; }
    }
}