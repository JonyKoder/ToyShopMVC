using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalPortal.Application.Interfaces;
using TerminalPortal.Domain.Models;

namespace TerminalPortal.Application.Repositoryes
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            _appDbContext.Categories.Remove(category);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Category>> GetListCategoryAsync()
        {
            return await _appDbContext.Categories.ToListAsync(); 
        }

        public async Task<Category> GetToyByIdAsync(int id)
        {
            var cat = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return cat;
        }
    }
}
