using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class Provider : Base
    {
        public string Name { get; set; }
        public long Cuit { get; set; }
        public string Email { get; set; }
        public int CodePostal { get; set; }
        public string Floor { get; set; }
        public string Telephone { get; set; }
        public string Department { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public int IdUser { get; set; }
        
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual List<Stock> Stocks { get; set; }
    }
}
