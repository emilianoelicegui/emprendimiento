using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Dto.Layer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Shared.Layer;
using WebsiteClient.Common;
using WebsiteClient.Services;

namespace WebsiteClient.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto rq)
        {
            var response = await _accountService.Authenticate(rq);
            
            if (response.Data != null)
            {
                //agrego en las cookies y oculto el token
                response.Data = AddSession(JsonConvert.DeserializeObject<UserDto>(response.Data.ToString()));

                return Ok(response);
            }
            else
            {
                if (response.Errors.Count() > 0)
                {
                    return BadRequest(response.Errors.First().ErrorMessage);
                }
                else
                {
                    return BadRequest("Ocurrio un error al intentar iniciar sesión");
                }
            }
        }

        [HttpPost("RefreshCompany")]
        public async void RefreshCompany(CompanyLoginDto newCompany)
        {
            var user = await HttpContext.GetUserContext();

            user.Company = newCompany;

            await AddSession(HttpContext.RefreshLoginAsync(user).Result);
        }

        private async Task<UserDto> AddSession(UserDto model)
        {
            var claims = new List<Claim>
                {
                    new Claim("Id", model.Id.ToString()),
                    new Claim("Name", model.Name.Trim()),
                    new Claim("Surname", model.Surname.Trim()),
                    new Claim("Email", model.Email.Trim()),
                    new Claim("Token", model.Token),
                    new Claim("IdRol", model.Rol.Id.ToString()),
                    new Claim("Rol", model.Rol.Name.Trim()),
                    new Claim("IdCompany", model.Company.Id.ToString()),
                    new Claim("NameCompany", model.Company.NameFantasy.Trim())
                };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {

            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);

            model.Token = null;

            return model;
        }

        [HttpGet("SignOut")]
        public async void SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}