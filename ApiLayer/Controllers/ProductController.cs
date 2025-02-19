using BusinessLogicLayer.DTO;
using BusinessLogicLayer.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetAllProducts()
        {
            IEnumerable<ProductResponse?> products = await _productService.GetProductsAsync();

            if (products.Count() == 0)
            {
                return BadRequest("No products founded");
            }

            return Ok(products);
        }

        [HttpGet("products/search/productId/{productId}")] //OK
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            ProductResponse? product = await _productService.GetProductByid(productId);

            if (product == null)
            {
                return BadRequest($"No product with id value {productId} founded");
            }

            return Ok(product);
        }

        [HttpGet("products/search/searchString/{searchString}")]
        public async Task<IActionResult> GetProductByString(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return BadRequest("Search string is required");
            }

            IEnumerable<ProductResponse?> product = await _productService.GetProductBySearchString(searchString);

            if (product.Count() == 0)
            {
                return BadRequest($"No product with the following string {searchString} founded");
            }

            return Ok(product);
        }

        [HttpPost("products")]
        public async Task<IActionResult> AddProduct(AddProductRequest productRequest)
        {
            if (productRequest == null)
            {
                return BadRequest("Invalid product data");
            }

            ProductResponse? product = await _productService.AddProductAsync(productRequest);

            if (product == null)
            {
                return BadRequest("No product added");
            }

            return Ok(product);
        }

        [HttpPut("products")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateRequest productUpdateRequest)
        {
            if (productUpdateRequest == null)
            {
                return BadRequest("Invalid data");
            }

            ProductResponse? product = await _productService.UpdateProductAsync(productUpdateRequest);

            if (product == null)
            {
                return BadRequest("No product modified");
            }

            return Ok(product);
        }

        [HttpDelete("products/{productId}")]
        public async Task<IActionResult> DeleteProductById(ProductDeleteRequest productDeleteRequest)
        {
            ProductResponse? product = await _productService.DeleteProduct(productDeleteRequest);

            if (product == null)
            {
                return BadRequest("No product deleted");
            }

            return Ok(product);
        }
    }
}