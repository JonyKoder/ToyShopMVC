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
    public class ToyRepository : IToyRepository
    {
        private AppDbContext _context;

        public ToyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Toy> GetToyByIdAsync(Guid id)
        {
            return await _context.Toys.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddToyAsync(Toy toy)
        {
            await _context.Toys.AddAsync(toy);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateToyAsync(Toy toy)
        {
            Toy existingToy = await _context.Toys.FirstOrDefaultAsync(t => t.Id == toy.Id);

            if (existingToy != null)
            {
                existingToy.Name = toy.Name;
                existingToy.Description = toy.Description;
                existingToy.Price = toy.Price;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteToyAsync(Guid id)
        {
            Toy toyToDelete = await _context.Toys.FirstOrDefaultAsync(t => t.Id == id);

            if (toyToDelete != null)
            {
                _context.Toys.Remove(toyToDelete);
            }
            await _context.SaveChangesAsync();
        }

        public Task<List<Toy>> GetListToysAsync()
        {
           return _context.Toys.ToListAsync();
        }

        public async Task<List<Toy>> GetToysByCategory(string categoryName)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Name == categoryName);
            var toys = await _context.Toys.Where(x => x.CategoryId == category.Id).ToListAsync();
            return toys;
        }

        public async Task AddProductInCartAsync(Guid toyId,Cart cart)
        {
            await _context.AddAsync(cart);
            await _context.SaveChangesAsync();
        }
    }
}
