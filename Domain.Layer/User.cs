namespace Domain.Layer
{
    public class User : Base
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsLocked { get; set; }
        public int IdRol { get; set; }
        public Rol Rol { get; set; }
    }
}
