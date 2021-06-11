using Domain.Dto.Layer;
using Emprendimiento.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shared.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprendimiento.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAny")]
    
    public class SaleController : BaseController
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        #region GET

        //buscar venta por id
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return ResponseResult(await _saleService.Get(id));
        }

        [HttpGet("GetItems/{idSale}")]
        public async Task<IActionResult> GetItems(int idSale)
        {
            return ResponseResult(await _saleService.GetItems(idSale));
        }

        //busqueda de ventas por usuario
        [HttpGet("GetAllByUser")]
        public async Task<IActionResult> GetAllByUser()
        {
            var idUser = HttpContext.User.FindFirst("id").Value.ToInt();

            return ResponseResult(await _saleService.GetAllByUser(idUser));
        }

        //busqueda de ventas con filtros 
        [HttpGet("GetAllByCompany")]
        public async Task<IActionResult> GetAllByCompany(int? idCompany, int start, int length)
        {
            var idUser = HttpContext.User.FindFirst("id").Value.ToInt();

            return ResponseResult(await _saleService.GetAllByCompany(idCompany, idUser, start, length));
        }

        #endregion

        #region POST 

        //crear venta 
        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] SaveSaleRequest rq)
        {
            return ResponseResult(await _saleService.Save(rq));
        }

        #endregion

        #region PUT

        //eliminar un venta
        [HttpPut("{id}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return ResponseResult(await _saleService.Delete(id));
        }

        #endregion PUT
    }
}
