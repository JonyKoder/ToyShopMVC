using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalPortal.Application.Interfaces;
using TerminalPortal.Domain.Models;

namespace TerminalPortal.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Add(Category category)
        {
            await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task Delete(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
        }

        public async Task<Category> GetById(int id)
        {
            var cat = await _categoryRepository.GetToyByIdAsync(id);
            return cat;
        }

        public async Task<List<Category>> GetListAsync()
        {
            return await _categoryRepository.GetListCategoryAsync();
        }
    }
}
