﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEcommerce.Domain.Models.DTOs
{
    public class ProductAddDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string Model { get; set; }

        public string Author { get; set; }

        public double Price { get; set; }
        public double OfferPrice { get; set; }

        public Guid CategoryId { get; set; }
    }
}
