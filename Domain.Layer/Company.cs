using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class Company : Base
    {
        public string NameFantasy { get; set; }
        public long Cuit { get; set; }
        public int CodePostal { get; set; }
        public string Floor { get; set; }
        public string Telephone { get; set; }
        public string Department { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public int IdUser { get; set; }
        public bool IsPrincipal { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
    }
}
