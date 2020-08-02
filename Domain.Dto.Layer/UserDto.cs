
namespace Domain.Dto.Layer
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        public string Token { get; set; }
        //public bool IsLocked { get; set; }
        public RolDto Rol { get; set; }
        public CompanyLoginDto Company { get; set; }
    }
}
