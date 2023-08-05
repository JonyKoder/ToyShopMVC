using Microsoft.AspNetCore.Http;

namespace TerminalPortal.Models
{
    public class ToyViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}
