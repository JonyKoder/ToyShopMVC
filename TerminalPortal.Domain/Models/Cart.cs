﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalPortal.Domain.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Toy> Toys { get; set; }
        public Guid ToyId { get; set; }
    }
}