using HomeAccounting.src.HomeAccounting.Application.Interfaces;
using HomeAccounting.src.HomeAccounting.Domain.Entities;

namespace HomeAccounting.src.HomeAccounting.Application.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {            
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
            => await _categoryRepository.GetAllAsync();

        public async Task<Category?> GetCategoryByIdAsync(int id)
            => await _categoryRepository.GetByIdAsync(id);

        public async Task AddCategoryAsync(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                throw new ArgumentException("Toifa nomi bo‘sh bo‘lmasligi kerak!");

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveAsync();
        }
        public async Task UpdateCategoryAsync(Category category)
        {
            Category existing = await _categoryRepository.GetByIdAsync(category.Id);
            if (existing == null)
                throw new KeyNotFoundException("Bunday toifa topilmadi!");

            existing.Name = category.Name;

            _categoryRepository.Update(existing);
            await _categoryRepository.SaveAsync();
        }
        public async Task DeleteCategoryAsync(int id)
        {
            Category cat = await _categoryRepository.GetByIdAsync(id);
            if (cat == null)
                throw new KeyNotFoundException("O‘chiriladigan toifa topilmadi!");

            _categoryRepository.Delete(cat);
            await _categoryRepository.SaveAsync();
        }
    }
}
