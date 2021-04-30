using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Emprendimiento.API.Services;
using System.Threading.Tasks;
using Shared.Layer;

namespace Emprendimiento.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAny")]
    public class CompanyController : BaseController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        #region GET

        //obtener una company
        [HttpGet("{id}", Name = "GetCompany")]
        public async Task<IActionResult> Get(int id)
        {
            return ResponseResult(await _companyService.Get(id));
        }

        //obtener companys de un usuario
        [HttpGet("GetAllByUser")]
        public async Task<IActionResult> GetAllByUser()
        {

            var idUser = HttpContext.User.FindFirst("id").Value.ToInt();

            return ResponseResult(await _companyService.GetAllByUser(idUser));
        }

        #endregion GET
    }
}