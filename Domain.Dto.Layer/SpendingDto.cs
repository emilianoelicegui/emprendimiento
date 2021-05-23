using System;

namespace Domain.Dto.Layer
{
    public class SpendingDto
    {
        public int Id { get; set; }
        public short Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public CompanyDto Company { get; set; }
    }
}