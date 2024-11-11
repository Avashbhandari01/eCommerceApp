using eCommerceApp.Application.DTOs.Product;
using eCommerceApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApp.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService _product) : ControllerBase
    {
        [HttpGet("all-products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var data = await _product.GetAllAsync();
            return data.Any() ? Ok(data) : NotFound(data);
        }

        [HttpGet("get-product/{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var data = await _product.GetByIdAsync(id);
            return data != null ? Ok(data) : NotFound(data);
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct(CreateProduct product)
        {
            var result = await _product.AddAsync(product);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update-product")]
        public async Task<IActionResult> UpdateProduct(UpdateProduct product)
        {
            var result = await _product.UpdateAsync(product);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await _product.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest();
        }
    }
}
