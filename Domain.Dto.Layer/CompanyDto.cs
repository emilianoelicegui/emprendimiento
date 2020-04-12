
using System.Collections.Generic;

namespace Domain.Dto.Layer
{
    public class CompanyDto : BaseDto
    {
        public string NameFantasy { get; set; }
        public long Cuit { get; set; }
        public int CodePostal { get; set; }
        public string Floor { get; set; }
        public string Telephone { get; set; }
        public string Department { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public int IdUser { get; set; }
    }
}
