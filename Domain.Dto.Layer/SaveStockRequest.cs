using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto.Layer
{
    public class SaveStockRequest
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int ProviderId { get; set; }
        public int Units { get; set; }
    }
}
