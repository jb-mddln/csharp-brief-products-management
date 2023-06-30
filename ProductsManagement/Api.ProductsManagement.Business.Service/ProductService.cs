using Api.ProductsManagement.Business.Dto.Product;
using Api.ProductsManagement.Business.Mapper;
using Api.ProductsManagement.Data.Entity.Model;
using Api.ProductsManagement.Data.Repository.Contract;
using Api.ProductsManagement.Service.Contract;

namespace Api.ProductsManagement.Business.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ReadProductDto>> GetProductsAsync()
        {
            var products = await _productRepository.GetAll().ConfigureAwait(false);
            return products.Select(ProductMapper.EntityToDto);
        }

        public async Task<ReadProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetById(id).ConfigureAwait(false);
            if (product == null)
            {
                throw new Exception($"Product {id} not found.");
            }

            return ProductMapper.EntityToDto(product);
        }

        public async Task<ReadProductDto> AddProductAsync(CreateProductDto productDto)
        {
            if (productDto == null)
            {
                throw new ArgumentNullException(nameof(productDto));
            }

            var productToAdd = ProductMapper.DtoToEntity(productDto);

            var productAdded = await _productRepository.Add(productToAdd).ConfigureAwait(false);
            return ProductMapper.EntityToDto(productAdded);
        }

        public async Task<ReadProductDto> RemoveProductAsync(int id)
        {
            var product = await _productRepository.GetById(id).ConfigureAwait(false);
            if (product == null)
            {
                throw new Exception($"Product {id} not found.");
            }

            var productDeleted = await _productRepository.Remove(product).ConfigureAwait(false);

            // todo removing in cascade ?

            return ProductMapper.EntityToDto(productDeleted);
        }
    }
}