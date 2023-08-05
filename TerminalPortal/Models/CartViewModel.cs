using TerminalPortal.Domain.Models;

namespace TerminalPortal.Models
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Toy Toy { get; set; }
        public Guid ToyId { get; set; }
    }
}
