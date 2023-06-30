using Api.ProductsManagement.Business.Dto.Product;
using Api.ProductsManagement.Data.Entity.Model;

namespace Api.ProductsManagement.Business.Mapper
{
    public static class ProductMapper
    {
        public static Product DtoToEntity(CreateProductDto productDto)
        {
            return new Product
            {
            };
        }

        public static ReadProductDto EntityToDto(Product product)
        {
            return new ReadProductDto
            {
            };
        }
    }
}