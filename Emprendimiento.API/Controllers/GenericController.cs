using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Emprendimiento.API.Services;
using System.Threading.Tasks;
using Shared.Layer;

namespace Emprendimiento.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAny")]
    public class GenericController : ControllerBase
    {
        private readonly IGenericService _genericService;

        public GenericController(IGenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpGet("GetMenu")]
        public async Task<IActionResult> GetMenu()
        {
            return Ok(await _genericService.GetMenu());
        }

        [HttpGet("GetMenus")]
        public async Task<IActionResult> GetMenus()
        {
            var idRol = HttpContext.User.FindFirst("idRol").Value.ToInt();

            return Ok(await _genericService.GetMenus(idRol));
        }

        [HttpGet("GetRol")]
        public async Task<IActionResult> GetRol()
        {
            var idRol = HttpContext.User.FindFirst("idRol").Value.ToInt();

            return Ok(await _genericService.GetRol(idRol));

        }
        [HttpGet("GetRoles")]
        public IActionResult GetRoles()
        {
            return Ok(_genericService.GetRoles());
        }
    }
}