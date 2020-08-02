using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.Layer;
using WebsiteClient.Services;

namespace WebsiteClient.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        #region GET 

        [HttpGet("GetAllByUser")]
        public async Task<IActionResult> GetAllByUser()
        {
            //este metodo devuelve el listado completo de companys, y excluye la que tiene en session
            var response = await _companyService.GetAllByUser();
            var listCompanys = JsonConvert.DeserializeObject<List<CompanyDto>>(response.Data.ToString());

            listCompanys.Remove(listCompanys
                        .Where(x => x.Id == HttpContext.User.FindFirst("IdCompany").Value.ToInt()).First());

            response.Data = listCompanys;

            return Ok(response);
        }

        #endregion GET 
    }
}