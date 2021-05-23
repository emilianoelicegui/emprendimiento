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

        [JsonIgnore]
        public Sale Sale { get; set; }
    }
}
