using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class Spending
    {
        public int Id { get; set; }
        public short Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int IdCompany { get; set; }
        public Company Company { get; set; }
    }
}
