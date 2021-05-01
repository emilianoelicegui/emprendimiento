using Shared.Layer;
using System;
using System.Collections.Generic;

namespace Domain.Layer
{
    public class Sale
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdCompany{ get; set; }
        public decimal Amount { get; set; }
        public MethodPayment MethodPayment { get; set; }
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public Company Company { get; set; }
        public List<ItemSale> ItemSales { get; set; }

    }
}
