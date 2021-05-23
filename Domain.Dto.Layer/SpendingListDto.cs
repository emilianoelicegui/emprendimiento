using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto.Layer
{
    public class SpendingListDto
    {
        public int Id { get; set; }
        public short IdSpendingType { get; set; }
        public string NameSpendingType { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int IdCompany { get; set; }
        public string NameCompany { get; set; }
    }
}
