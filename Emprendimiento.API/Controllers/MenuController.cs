using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services.Layer;

namespace Emprendimiento.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAny")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("GetMenues")]
        public IActionResult GetMenues()
        {
            return Ok(_menuService.GetMenues());
        }
    }
}