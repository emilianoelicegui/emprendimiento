using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto.Layer
{
    public class ProviderDto : BaseDto
    {
        public string Name { get; set; }
        public long Cuit { get; set; }
        public string Email { get; set; }
        public int CodePostal { get; set; }
        public string Floor { get; set; }
        public string Telephone { get; set; }
        public string Department { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public int IdUser { get; set; }
        public UserDto User { get; set; }
    }
}
