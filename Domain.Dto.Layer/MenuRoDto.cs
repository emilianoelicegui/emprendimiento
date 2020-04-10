using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto.Layer
{
    class MenuRolDto
    {
        public int MenuId { get; set; }
        public List<MenuDto> Menues { get; set; }
        public int RolId { get; set; }
        public List<RolDto> Roles { get; set; }
    }
}
