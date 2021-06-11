using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class Payment
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public decimal Amount { get; set; }
        public DateTime Datetime { get; set; }
        public Client Client { get; set; }
    }
}
