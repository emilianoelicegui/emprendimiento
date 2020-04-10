using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class Rol
    {
        public int RolId { get; set; }
        public string Nombre { get; set; }
        public MenuRol MenuRol { get; set; }
    }
}
