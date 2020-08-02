using System;
using System.Threading.Tasks;
using Domain.Dto.Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Emprendimiento.API.Services;
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

        [HttpGet("ListByUser", Name = "GetAllProductsByUser")]
        public async Task<IActionResult> GetAllByUser()
        {
            var idUser = HttpContext.User.FindFirst("id").Value.ToInt();

            return Ok(await _productService.GetAllByUser(idUser));
        }

        //busqueda de productos con filtros 
        [HttpGet("GetAllByCompany")]
        public async Task<IActionResult> GetAllByCompany(string name, int? idCompany, int draw, int start, int length)
        {
            try
            {
                var idUser = HttpContext.User.FindFirst("id").Value.ToInt();

                var response = await _productService.GetAllByCompany(name, idCompany, idUser, draw, start, length);

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
                    return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrio un error al realizar la solicitud" );
                }

                response.SuccessMessage = "El producto se registró correctamente."; 

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