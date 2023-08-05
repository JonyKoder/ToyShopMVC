using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalPortal.Application.Interfaces;
using TerminalPortal.Domain.Models;

namespace TerminalPortal.Application.Services
{
    public class ToyService : IToyService
    {
        private readonly IToyRepository _toyRepository;

        public ToyService(IToyRepository toyRepository)
        {
            _toyRepository = toyRepository;
        }

        public async Task Add(Toy toy)
        {
          await _toyRepository.AddToyAsync(toy);
        }

        public async Task AddToyInCartAsync(Guid toyId,Cart cart)
        {
            await _toyRepository.AddProductInCartAsync(toyId,cart);
        }

        public async Task Delete(Guid id)
        {
            await _toyRepository.DeleteToyAsync(id);
        }

        public Task<List<Toy>> GetByCategory(string category)
        {
          var filterToys = _toyRepository.GetToysByCategory(category);
            return filterToys;
        }

        public async Task<Toy> GetById(Guid id)
        {
            var toy = await _toyRepository.GetToyByIdAsync(id);
            return toy;
        }

        public async Task<List<Toy>> GetListAsync()
        {
           var toys = await _toyRepository.GetListToysAsync();
            return toys;
        }

        public async Task Update(Toy toy)
        {
           await _toyRepository.UpdateToyAsync(toy);
        }
    }

}
