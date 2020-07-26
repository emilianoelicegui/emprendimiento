using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class MenuRol : Base
    {
        public int IdMenu { get; set; }
        public int IdRol { get; set; }

        public Menu Menu { get; set; }
        public Rol Rol { get; set; }
    }
}
