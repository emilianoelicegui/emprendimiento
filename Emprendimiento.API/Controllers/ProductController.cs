using System;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #region GET

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _productService.Get(id));
        }

        [HttpGet("ListByCompany/{idCompany}", Name = "GetAllProductsByCompany")]
        public async Task<IActionResult> GetAllByCompany(int idCompany)
        {
            return Ok(await _productService.GetAllByCompany(idCompany));
        }

        [HttpGet("ListByUser", Name = "GetAllProductsByUser")]
        public async Task<IActionResult> GetAllByUser()
        {
            var idUser = HttpContext.User.FindFirst("id").Value.ToInt();

            return Ok(await _productService.GetAllByUser(idUser));
        }

        #endregion

        #region POST 

        //sirve para crear o actualizar productos
        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] SaveProductRequest rq)
        {
            try
            {
                var response = await _productService.Save(rq);

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
                var response = await _productService.Delete(id);

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