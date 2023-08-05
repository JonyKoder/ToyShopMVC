using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using TerminalPortal.Application;
using TerminalPortal.Application.Interfaces;
using TerminalPortal.Domain.Models;
using TerminalPortal.Models;

namespace TerminalPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IToyService _toyService;
        private ICategoryService _categoryService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, IToyService toyService, ICategoryService categoryService, AppDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _toyService = toyService;
            _categoryService = categoryService;
            _context = context;
        }

        public async Task<IActionResult> Index(string category = null)
        {
            var toys = await _toyService.GetListAsync();
            if (category != null && category != "null")
            {
                toys = await _toyService.GetByCategory(category);
            }
            
            var toyDto = _mapper.Map<List<ToyViewModel>>(toys);
            return View(toyDto);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var toy = await _toyService.GetById(id);
            var viewModel = new ToyViewModel
            {
                Id = toy.Id,
                Name = toy.Name,
                CategoryId = toy.CategoryId,
                Description = toy.Description,
                Image = toy.Image,
                Price = toy.Price

                // Здесь можно добавить дополнительные свойства для редактирования,
                // например, Description, Price, и так далее.
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ToyViewModel viewModel)
        {
           
            var toy = await _toyService.GetById(viewModel.Id);

            if (toy == null)
            {
                return NotFound();
            }
            if (viewModel.ImageFile != null)
            {

                string uploadsFolder = Path.Combine(Path.GetTempPath(), "images");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await viewModel.ImageFile.CopyToAsync(fileStream);
                }
                toy.Name = viewModel.Name;
                toy.Description = viewModel.Description;
                toy.Price = viewModel.Price;
                toy.Image = filePath;
            }
            else
            {
                toy.Name = viewModel.Name;
                toy.Description = viewModel.Description;
                toy.Price = viewModel.Price;
            }
          
            


            await _toyService.Update(toy);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            await _toyService.Delete(id);
            return NoContent();
        }
        public async Task<IActionResult> AddToyInCart(Guid id)
        {
            
            var toy = await _toyService.GetById(id);
            var cart = new Cart()
            {
                Description = $"Игрушка '{toy.Name}'",
                Title = $"Номер заказа {id}",
                ToyId = id
            };
            await _toyService.AddToyInCartAsync(id, cart);
            return NoContent();
        }
        public IActionResult GetImage(string imagePath)
        {
            // Проверьте наличие файла перед чтением из него.
            if (System.IO.File.Exists(imagePath))
            {
                //.imagePath содержит абсолютный путь к файлу на сервере
                //Например: "C:\\wwwroot\\images\\image.jpg"
                string fileExtension = Path.GetExtension(imagePath);
                var contentType = $"image/{fileExtension.ToLower().Substring(1)}"; // Определение типа содержимого MIME исходя из расширения файла
                var fileBytes = System.IO.File.ReadAllBytes(imagePath);
                return File(fileBytes, contentType);
            }

            // Возвращайте исключение или ошибку HTTP, если файл не существует
            return NotFound("Requested image not found.");
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var cat = await _categoryService.GetListAsync();
            var selectList = new List<SelectListItem>();
            foreach (var item in cat)
            {
                selectList.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }

            ViewData["cat"] = selectList;
            return View();
        }
        public async Task<IActionResult> OpenCart()
        {
            var carts = await _context.Carts.ToListAsync();

            var cartDto = _mapper.Map<List<CartViewModel>>(carts);
            return View(cartDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ToyViewModel toyViewModel)
        {
            if (toyViewModel.ImageFile != null)
            {

                string uploadsFolder = Path.Combine(Path.GetTempPath(), "images");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + toyViewModel.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await toyViewModel.ImageFile.CopyToAsync(fileStream);
                }
                var toy = new Toy(Guid.NewGuid(), toyViewModel.Name, toyViewModel.Description, toyViewModel.Price, toyViewModel.CategoryId, filePath);
                await _toyService.Add(toy);
            }
            else
            {
                var toy = new Toy(Guid.NewGuid(), toyViewModel.Name, toyViewModel.Description, toyViewModel.Price, toyViewModel.CategoryId);
                await _toyService.Add(toy);
            }
           
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}