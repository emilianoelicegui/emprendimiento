using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto.Layer
{
    public class ClientListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long Dni { get; set; }
        public long Cuit { get; set; }
        public string CodArea { get; set; }
        public string Phone { get; set; }
        public string PhoneComplete { get; set; }
        public string Email { get; set; }
        public int IdCompany { get; set; }
        public string NameCompany { get; set; }
    }
}
