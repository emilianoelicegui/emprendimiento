using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class ItemSale
    {
        public int Id { get; set; }
        public int IdSale { get; set; }
        public Sale Sale { get; set; }
    }
}
