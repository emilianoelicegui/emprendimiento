using Shared.Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto.Layer
{
    public class SaleListDto
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public string NameClient { get; set; }
        public int IdCompany { get; set; }
        public string NameCompany { get; set; }
        public decimal Amount { get; set; }
        public MethodPayment MethodPayment { get; set; }
        public string MethodPaymentDesc { get; set; }
        public DateTime Date { get; set; }
    }
}
