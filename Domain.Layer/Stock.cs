using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class Stock
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int ProviderId { get; set; }
        public int Units { get; set; }
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
