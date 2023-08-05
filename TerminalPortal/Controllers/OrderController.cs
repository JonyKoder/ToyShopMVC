using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bots.Http;
using Telegram.Bots.Types;
using TerminalPortal.Application;
using TerminalPortal.Application.Interfaces;
using TerminalPortal.Domain.Models;

namespace TerminalPortal.Controllers
{
    public class OrderController : Controller
    {
        private readonly IToyService toyService;
        private readonly ICategoryService categoryService;
        private readonly AppDbContext _context;

        public OrderController(IToyService toyService, AppDbContext context, ICategoryService categoryService)
        {
            this.toyService = toyService;
            _context = context;
            this.categoryService = categoryService;
        }

        private static readonly string BotToken = "6320316014:AAFbhXPCayZjxGpq8qRg7R5OOQKmUDnAys4";
        public async Task<IActionResult> SendOrder(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            var botClient = new TelegramBotClient(BotToken);
            var toy = await CreateOrderText(cart);

            var chatId = 2012045006;
            Console.WriteLine($"Received a message from chatId: {chatId}");
            // здесь вы можете сохранить chatId в вашей системе, если вам нужно.
            await botClient.SendTextMessageAsync(chatId, $"Заказ {toy.Id}, Товар: {toy.Name} Цена: {toy.Price} ");

            using (FileStream fileStream = System.IO.File.OpenRead(toy.Image))
            {
                var stream = Telegram.Bot.Types.InputFile.FromStream(fileStream);
                // Отправка изображения
                await botClient.SendPhotoAsync(chatId, stream);
            }

            return NoContent();
        }

        private async Task<Toy> CreateOrderText(Cart cart)
        {
            var toy = await toyService.GetById(cart.ToyId);
            var category = await categoryService.GetById(toy.CategoryId);
           
            return toy;
        }
    }
}
