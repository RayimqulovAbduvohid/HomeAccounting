using HomeAccounting.src.HomeAccounting.Application.Services;
using HomeAccounting.src.HomeAccounting.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeAccounting.src.HomeAccounting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategorysController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategorysController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _categoryService.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cat = await _categoryService.GetCategoryByIdAsync(id);
            return cat is null ? NotFound() : Ok(cat);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await _categoryService.AddAsync(category);
            return Ok("Toifa qo‘shildi");
        }

        [Authorize(Roles = "User")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Category category)
        {
            category.Id = id;
            await _categoryService.UpdateAsync(category);
            return Ok("Toifa yangilandi");
        }
        [Authorize(Roles = "User")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok("Toifa o‘chirildi");
        }
    }
}
