using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class Menu : Base
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int IdRol { get; set; }
        public Rol Rol { get; set; }
    }
}
