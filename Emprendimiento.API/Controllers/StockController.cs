using Domain.Dto.Layer;
using Emprendimiento.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
    public class StockController : BaseController
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        #region POST

        //registrar gasto por company
        [HttpPost("Save")]
        public async Task<IActionResult> Save(SaveStockRequest rq)
        {
            //if (!ModelState.IsValid)
            //    return ResponseResult(ValidateModel(ModelState));

            return ResponseResult(await _stockService.Save(rq));
        }

        #endregion POST
    }
}
