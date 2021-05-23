using System.Collections.Generic;

namespace Domain.Layer
{
    public class SpendingType
        {
            public short Id { get; set; }
            public string Description { get; set; }
            public List<Spending> Spendings { get; set; }
        }
}