
namespace Domain.Dto.Layer
{
    public class LoginResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public RolDto Rol { get; set; }
    }
}
