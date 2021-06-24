using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto.Layer
{
    public class DebtorListDto
    {
        public bool Debtor { get; set; }
        public decimal Amount { get; set; }
        public List<SaleListDto> Sales { get; set; }
        public List<PaymentListDto> Payments { get; set; }
    }
}
