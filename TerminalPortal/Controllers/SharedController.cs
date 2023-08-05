using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TerminalPortal.Application;
using TerminalPortal.Models;

namespace TerminalPortal.Controllers
{
    public class SharedController : Controller
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public SharedController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

  
        public async Task<IActionResult> Layout()
        {
            var carts = await _context.Carts.ToListAsync();

            var cartDto = _mapper.Map<List<CartViewModel>>(carts);
            return View(cartDto);
        }
    }
}
