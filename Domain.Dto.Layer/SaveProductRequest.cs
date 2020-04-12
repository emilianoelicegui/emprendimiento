using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto.Layer
{
    public class SaveProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsDolar { get; set; }
        public int IdCompany { get; set; }
        public bool IsDelete { get; set; }
    }
}
