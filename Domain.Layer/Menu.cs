using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class Menu
    {
        public int MenuId { get; set; } 
        public string Nombre { get; set; }
        public string Url { get; set; }
        public Rol Rol { get; set; }
    }
}
