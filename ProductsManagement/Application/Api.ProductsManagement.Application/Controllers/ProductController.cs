using Api.ProductsManagement.Business.Dto.Product;
using Api.ProductsManagement.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProductsManagement.Application.Controllers
{
    /// <summary>
    /// Product controller
    /// </summary>
    [Route("api/[controller]"), ApiController, Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Handle get request for retrieving all the products
        /// </summary>
        /// <returns></returns>
        [HttpGet, ProducesResponseType(typeof(IEnumerable<ReadProductDto>), 200)]
        public async Task<ActionResult> GetClientsAsync() => Ok(await _productService.GetProductsAsync());

        /// <summary>
        /// Handle get request with params for retrieving a product with his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}"), ProducesResponseType(typeof(ReadProductDto), 200)]
        public async Task<ActionResult> Get(int id) => Ok(await _productService.GetProductByIdAsync(id));

        /// <summary>
        /// Handle post request for creating a new product
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(typeof(IEnumerable<ReadProductDto>), 200)]
        public async Task<ActionResult> Post([FromBody] CreateProductDto productDto) => Ok(await _productService.AddProductAsync(productDto).ConfigureAwait(false));

        /// <summary>
        /// Handle delete request for deleting a product by his id
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns></returns>
        [HttpDelete("{id}"), ProducesResponseType(typeof(IEnumerable<ReadProductDto>), 200)]
        public async Task<ActionResult> Delete(int id) => Ok(await _productService.RemoveProductAsync(id).ConfigureAwait(false));
    }
}
