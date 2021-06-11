using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public List<ItemSale> ItemSales { get; set; }
    }
}
