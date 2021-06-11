using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class Client : Base
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public long Dni { get; set; }
        public long Cuit { get; set; }
        public string CodArea { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int IdCompany { get; set; }
        public Company Company { get; set; }
        public List<Sale> Sales { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
