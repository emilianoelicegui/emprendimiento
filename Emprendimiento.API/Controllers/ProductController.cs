using System;
using System.Collections.Generic;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #region GET

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _productService.Get(id));
        }

        [HttpGet("ListByCompany/{idCompany}", Name = "GetProductsByCompany")]
        public async Task<IActionResult> GetAllByCompany(int idCompany)
        {
            return Ok(await _productService.GetAllByCompany(idCompany));
        }

        [HttpGet("ListByUser", Name = "GetProductsByUser")]
        public async Task<IActionResult> GetAllByUser()
        {
            var idUser = HttpContext.User.FindFirst("id").Value.ToInt();

            return Ok(await _productService.GetAllByUser(idUser));
        }

        #endregion

        #region POST 

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] SaveProductRequest rq)
        {
            try
            {
                return Ok(await _productService.SaveProduct(rq));
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
                return Ok(await _productService.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion PUT
    }
}