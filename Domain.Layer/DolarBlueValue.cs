using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class DolarBlueValue
    {
        public int Id { get; set; }
        public DateTime LastUpdate { get; set;}
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }
}
