﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class ItemSale
    {
        public int Id { get; set; }
        public int IdSale { get; set; }
        public int IdProduct { get; set; }
        public int Units { get; set; }

        [JsonIgnore]
        public Sale Sale { get; set; }
        public Product Product { get; set; }
    }
}
