using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class Rol : Base
    {
        public string Name { get; set; }
        public List<Menu> Menus { get; set; }
        public List<User> Users { get; set; }
    }
}
