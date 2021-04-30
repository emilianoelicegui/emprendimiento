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
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #region GET

        //buscar producto por id
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            return ResponseResult(await _productService.Get(id));
        }

        //busqueda de productos por usuario
        [HttpGet("GetAllByUser")]
        public async Task<IActionResult> GetAllByUser()
        {
            var idUser = HttpContext.User.FindFirst("id").Value.ToInt();

            return ResponseResult(await _productService.GetAllByUser(idUser));
        }

        //busqueda de productos con filtros 
        [HttpGet("GetAllByCompany")]
        public async Task<IActionResult> GetAllByCompany(string name, int? idCompany, int start, int length)
        {
            var idUser = HttpContext.User.FindFirst("id").Value.ToInt();

            return ResponseResult(await _productService.GetAllByCompany(name, idCompany, idUser, start, length));
        }

        #endregion

        #region POST 

        //crear productos
        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] SaveProductRequest rq)
        {
            return ResponseResult(await _productService.Save(rq));
        }

        #endregion

        #region PUT

        //eliminar un producto
        [HttpPut("{id}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return ResponseResult(await _productService.Delete(id));
        }

        #endregion PUT
    }
}