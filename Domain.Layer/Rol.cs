using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Layer
{
    public class Rol : Base
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public List<MenuRol> MenuRoles { get; set; }
    }
}
