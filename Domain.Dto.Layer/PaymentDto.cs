using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto.Layer
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public decimal Amount { get; set; }
        public DateTime Datetime { get; set; }
        public ClientDto Client { get; set; }
    }
}
