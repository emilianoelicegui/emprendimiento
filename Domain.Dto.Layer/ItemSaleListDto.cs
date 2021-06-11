using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto.Layer
{
    public class ItemSaleListDto
    {
        public int Id { get; set; }
        public int IdSale { get; set; }
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public decimal PriceProduct { get; set; }
        public int Units { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
