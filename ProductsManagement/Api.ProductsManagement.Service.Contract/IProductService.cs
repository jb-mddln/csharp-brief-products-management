using Api.ProductsManagement.Business.Dto.Product;

namespace Api.ProductsManagement.Service.Contract
{
    public interface IProductService
    {
        Task<IEnumerable<ReadProductDto>> GetProductsAsync();

        Task<ReadProductDto> GetProductByIdAsync(int id);

        Task<ReadProductDto> AddProductAsync(CreateProductDto productDto);

        Task<ReadProductDto> RemoveProductAsync(int id);
    }
}