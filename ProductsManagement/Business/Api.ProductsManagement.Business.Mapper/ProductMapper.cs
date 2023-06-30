using Api.ProductsManagement.Business.Dto.Product;
using Api.ProductsManagement.Data.Entity.Model;

namespace Api.ProductsManagement.Business.Mapper
{
    public static class ProductMapper
    {
        #region Product
        public static Product DtoToEntity(CreateProductDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Image = productDto.Image,
                Category = DtoToEntity(productDto.Category),
                Price = productDto.Price
            };
        }

        public static ReadProductDto EntityToDto(Product product)
        {
            return new ReadProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Image = product.Description,
                Category = EntityToDto(product.Category),
                Price = product.Price
            };
        }
        #endregion

        #region Category
        public static ProductCategory DtoToEntity(CreateProductCategoryDto categoryDto)
        {
            return new ProductCategory
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };
        }

        public static ReadProductCategoryDto EntityToDto(ProductCategory category)
        {
            return new ReadProductCategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };
        }
        #endregion
    }
}