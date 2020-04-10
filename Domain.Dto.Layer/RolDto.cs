
using System.Collections.Generic;

namespace Domain.Dto.Layer
{
    public class RolDto
    {
        public string Name { get; set; }
        public List<MenuDto> Menus { get; set; }
    }
}
