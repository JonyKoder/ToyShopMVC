using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TerminalPortal.Application;
using TerminalPortal.Models;

namespace TerminalPortal.Views.Shared.Components
{
    // В папке ViewComponents
    public class CartViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public CartViewComponent(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var carts = await _context.Carts.ToListAsync();

            var cartDto = _mapper.Map<List<CartViewModel>>(carts);
            return View(cartDto);
        }
    }
}
