using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class MenuRol
    {
        public int MenuRolId { get; set; }
        public int MenuId { get; set; }
        public List<Menu> Menues { get; set; }
        public int RolId { get; set; }
        public List<Rol> Roles { get; set; }
    }
}
