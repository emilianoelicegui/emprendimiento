using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Emprendimiento.API.Services;
using System.Threading.Tasks;
using Shared.Layer;
using Emprendimiento.API.Services.Recurring;

namespace Emprendimiento.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAny")]
    public class GenericController : BaseController
    {
        private readonly IGenericService _genericService;
        private readonly IRecurringService _recurringService;

        public GenericController(IGenericService genericService, IRecurringService recurringService)
        {
            _genericService = genericService;
            _recurringService = recurringService;
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
        public async Task<IActionResult> GetRoles()
        {
            return ResponseResult(await _genericService.GetRoles());
        }

        //get valor dolar blue
        [HttpGet("GetDolarBlue")]
        public async Task<IActionResult> GetDolarBlue()
        {
            return ResponseResult(await _recurringService.GetDolarBlue());
        }
    }
}