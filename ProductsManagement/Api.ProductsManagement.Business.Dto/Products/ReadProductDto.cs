namespace Api.ProductsManagement.Business.Dto.Product
{
    public class ReadProductDto : CreateProductDto
    {
        public int Id { get; set; }

        public ReadProductCategoryDto Category { get; set; }
    }
}
