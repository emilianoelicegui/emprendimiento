using System.Collections.Generic;

namespace Domain.Layer
{
    public class User : Base
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public bool IsLocked { get; set; }
        public int IdRol { get; set; }
        public Rol Rol { get; set; }
        public List<Company> Companys { get; set; }
        public List<Provider> Providers { get; set; }
    }
}
