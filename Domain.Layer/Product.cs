using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class Product : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsDolar { get; set; }
        public int IdCompany { get; set; }
        public Company Company { get; set; }
    }
}
