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
    public class SpendingController : BaseController
    {

        private readonly ISpendingService _spendingService;

        public SpendingController(ISpendingService spendingService)
        {
            _spendingService = spendingService;
        }

        #region GET 

        //obtener gastos por usuario (todas sus companys)
        [HttpGet("GetAllByUser")]
        public async Task<IActionResult> GetAllByUser()
        {
            var idUser = HttpContext.User.FindFirst("id").Value.ToInt();

            return ResponseResult(await _spendingService.GetAllByUser(idUser));
        }

        //obtener gastos por company
        [HttpGet("GetAllByCompany/{idCompany}")]
        public async Task<IActionResult> GetAllByCompany(int idCompany)
        {
            return ResponseResult(await _spendingService.GetAllByCompany(idCompany));
        }

        #endregion GET

        #region POST

        //registrar gasto por company
        [HttpPost("Save")]
        public async Task<IActionResult> Save(SaveSpendingRequest rq)
        {
            //if (!ModelState.IsValid)
            //    return ResponseResult(ValidateModel(ModelState));

            return ResponseResult(await _spendingService.Save(rq));
        }

        #endregion POST
    }
}
