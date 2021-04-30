using Domain.Dto.Layer;
using Emprendimiento.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shared.Layer;
using System.Threading.Tasks;

namespace Emprendimiento.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAny")]
    public class ClientController : BaseController
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        #region GET

        //buscar producto por id
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return ResponseResult(await _clientService.Get(id));
        }

        //busqueda de clientes por usuario
        [HttpGet("GetAllByUser")]
        public async Task<IActionResult> GetAllByUser()
        {
            var idUser = HttpContext.User.FindFirst("id").Value.ToInt();

            return ResponseResult(await _clientService.GetAllByUser(idUser));
        }

        //busqueda de clientes con filtros 
        [HttpGet("GetAllByCompany")]
        public async Task<IActionResult> GetAllByCompany(string name, int? idCompany, int start, int length)
        {
            var idUser = HttpContext.User.FindFirst("id").Value.ToInt();

            return ResponseResult(await _clientService.GetAllByCompany(name, idCompany, idUser, start, length));
        }

        #endregion

        #region POST 

        //registrar clientes
        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] SaveClientRequest rq)
        {
            return ResponseResult(await _clientService.Save(rq));
        }

        #endregion

        #region PUT

        //eliminar un cliente
        [HttpPut("{id}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return ResponseResult(await _clientService.Delete(id));
        }

        #endregion PUT
    }
}
