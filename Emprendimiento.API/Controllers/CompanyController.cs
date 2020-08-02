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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        #region GET

        [HttpGet("{id}", Name = "GetCompany")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _companyService.Get(id));
        }

        [HttpGet("ListByUser", Name = "GetAllCompanysByUser")]
        public async Task<IActionResult> GetAllByUser()
        {

            var idUser = HttpContext.User.FindFirst("id").Value.ToInt();

            return Ok(await _companyService.GetAllByUser(idUser));
        }

        #endregion GET
    }
}