using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalPortal.Domain.Models
{
    public class Toy
    {
        public Toy(Guid id, string name, string description, double price, int categoryId, string image = null)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            Image = image;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
