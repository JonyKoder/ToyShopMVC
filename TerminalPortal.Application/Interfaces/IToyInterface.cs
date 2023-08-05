using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalPortal.Domain.Models;

namespace TerminalPortal.Application.Interfaces
{
    public interface IToyService
    {
        Task<Toy> GetById(Guid id);
        Task<List<Toy>> GetByCategory(string category);
        Task Add(Toy toy);
        Task AddToyInCartAsync(Guid toyId,Cart cart);
        Task<List<Toy>> GetListAsync();
        Task Update(Toy toy);
        Task Delete(Guid id);
    }
}
