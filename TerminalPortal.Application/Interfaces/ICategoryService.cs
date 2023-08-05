using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalPortal.Domain.Models;

namespace TerminalPortal.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetById(int id);
        Task Add(Category category);
        Task<List<Category>> GetListAsync();
        Task Delete(int id);
    }
}
