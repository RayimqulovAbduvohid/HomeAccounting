using HomeAccounting.src.HomeAccounting.Application.Services;
using HomeAccounting.src.HomeAccounting.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HomeAccounting.src.HomeAccounting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _categoryService.GetAllCategoriesAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cat = await _categoryService.GetCategoryByIdAsync(id);
            return cat is null ? NotFound() : Ok(cat);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await _categoryService.AddCategoryAsync(category);
            return Ok("Toifa qo‘shildi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Category category)
        {
            category.Id = id;
            await _categoryService.UpdateCategoryAsync(category);
            return Ok("Toifa yangilandi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Toifa o‘chirildi");
        }
    }
}
