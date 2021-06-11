using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto.Layer
{
    public class PaymentListDto
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public string NameClient { get; set; }
        public int IdCompany { get; set; }
        public string NameCompany { get; set; }
        public decimal Mount { get; set; }
        public DateTime Datetime { get; set; }
    }
}
