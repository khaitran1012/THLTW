﻿using System.ComponentModel.DataAnnotations;

namespace TranQuangKhai_2280601379_LTW.Models
{
        public class Product
        {
            public int Id { get; set; }
            [Required, StringLength(100)]
            public string Name { get; set; }
          
            public decimal Price { get; set; }
            public string Description { get; set; }
            public string? ImageUrl { get; set; }
            public List<ProductImage>? Images { get; set; }
            public int CategoryId { get; set; }

            public Category? Category { get; set; }
        }
}
