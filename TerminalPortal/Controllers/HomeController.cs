using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TerminalPortal.Domain.Models;
using TerminalPortal.Models;

namespace TerminalPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var toy = new List<Toy>() { new Toy(Guid.NewGuid(), "Машинка", "Просто такая обычная", 200.0), new Toy(Guid.NewGuid(), "Машинка", "Просто такая обычная", 700.0),
            new Toy(Guid.NewGuid(), "Машинка", "Просто такая обычная", 600.0),
            new Toy(Guid.NewGuid(), "Машинка", "Просто такая обычная", 800.0),
            new Toy(Guid.NewGuid(), "Машинка", "Просто такая обычная", 100.0)};

            var toyDto = _mapper.Map<List<ToyViewModel>>(toy);
            return View(toyDto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}