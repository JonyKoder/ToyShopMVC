using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalPortal.Domain.Models;

namespace TerminalPortal.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetToyByIdAsync(int id);
        Task AddCategoryAsync(Category category);
        Task<List<Category>> GetListCategoryAsync();
        Task DeleteCategoryAsync(int id);
    }
}
