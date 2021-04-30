using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Emprendimiento.API.Services;
using System.Threading.Tasks;
using Shared.Layer;

namespace Emprendimiento.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAny")]
    public class GenericController : BaseController
    {
        private readonly IGenericService _genericService;

        public GenericController(IGenericService genericService)
        {
            _genericService = genericService;
        }

        //obtener el menu para cada usuario, por su rol
        [HttpGet("GetMenus")]
        public async Task<IActionResult> GetMenus()
        {
            var idRol = HttpContext.User.FindFirst("idRol").Value.ToInt();

            return ResponseResult(await _genericService.GetMenus(idRol));
        }

        //obtener un rol especifico
        [HttpGet("GetRol")]
        public async Task<IActionResult> GetRol()
        {
            var idRol = HttpContext.User.FindFirst("idRol").Value.ToInt();

            return ResponseResult(await _genericService.GetRol(idRol));

        }

        //obtener listado de roles
        [HttpGet("GetRoles")]
        public IActionResult GetRoles()
        {
            return ResponseResult(_genericService.GetRoles());
        }
    }
}