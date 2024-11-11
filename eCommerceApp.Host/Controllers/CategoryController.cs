using eCommerceApp.Application.DTOs.Category;
using eCommerceApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApp.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService _category) : ControllerBase
    {
        [HttpGet("all-categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var data = await _category.GetAllAsync();
            return data.Any() ? Ok(data) : NotFound(data);
        }

        [HttpGet("get-category/{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var data = await _category.GetByIdAsync(id);
            return data != null ? Ok(data) : NotFound(data);
        }

        [HttpPost("add-category")]
        public async Task<IActionResult> AddCategory(CreateCategory category)
        {
            var result = await _category.AddAsync(category);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update-category")]
        public async Task<IActionResult> UpdateProduct(UpdateCategory category)
        {
            var result = await _category.UpdateAsync(category);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete-category/{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var result = await _category.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest();
        }
    }
}
