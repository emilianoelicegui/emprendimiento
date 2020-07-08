using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Layer;
using Shared.Layer;

namespace Emprendimiento.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAny")]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        #region GET

        [HttpGet("{id}", Name = "GetProvider")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _providerService.Get(id));
        }

        [HttpGet("ListByUser", Name = "GetAllProvidersByUser")]
        public async Task<IActionResult> GetAllByUser()
        {
            var idUser = HttpContext.User.FindFirst("id").Value.ToInt();

            return Ok(await _providerService.GetAllByUser(idUser));
        }

        #endregion

        #region POST 

        //sirve para crear o actualizar proveedores
        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] SaveProviderRequest rq)
        {
            try
            {
                var response = await _providerService.Save(rq);

                if (response.Status != true)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrio un error al realizar la solicitud");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region PUT

        [HttpPut("{id}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _providerService.Delete(id);

                if (response.Status != true)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrio un error al realizar la solicitud");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion PUT
    }
}