﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EccomerceWeb.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }
        public string ImagePath { get; set; }
    }
}