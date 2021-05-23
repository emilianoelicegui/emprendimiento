using Shared.Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto.Layer
{
    public class SaleDto
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdCompany { get; set; }
        public decimal Amount { get; set; }
        public MethodPayment MethodPayment { get; set; }
        public DateTime Date { get; set; }
        public ClientDto Client { get; set; }
        public CompanyDto Company { get; set; }
        public List<ItemSaleDto> ItemSales { get; set; }
    }
}
