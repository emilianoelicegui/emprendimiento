﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Layer;
using Shared.Layer;
using System.Threading.Tasks;

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

        [HttpGet("{id}", Name = "GetCompany")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _companyService.Get(id));
        }

        [HttpGet("List", Name = "GetCompanies")]
        public async Task<IActionResult> GetAll()
        {

            var idUser = HttpContext.User.FindFirst("id").Value.ToInt();

            return Ok(await _companyService.GetAll(idUser));
        }
    }
}