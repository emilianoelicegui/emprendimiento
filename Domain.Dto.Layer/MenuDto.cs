
namespace Domain.Dto.Layer
{
    public class MenuDto : BaseDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public RolDto Rol { get; set; }
    }
}
