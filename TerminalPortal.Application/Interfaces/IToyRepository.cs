using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalPortal.Domain.Models;

namespace TerminalPortal.Application.Interfaces
{
    public interface IToyRepository
    {
        Task<Toy> GetToyByIdAsync(Guid id);
        Task AddToyAsync(Toy toy);
        Task AddProductInCartAsync(Guid toyId,Cart cart);
        Task<List<Toy>> GetListToysAsync();
        Task UpdateToyAsync(Toy toy);   
        Task<List<Toy>> GetToysByCategory(string categoryName);
        Task DeleteToyAsync(Guid id);
    }
}
