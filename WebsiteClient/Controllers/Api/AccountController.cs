﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Dto.Layer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

            if (response.Id > 0)
            {
                var model = new UserDto
                {
                    Name = response.Name,
                    Surname = response.Surname,
                    Email = response.Email,
                    Token = response.Token,
                    Rol = response.Rol
                };

                AddSession(model);

                return Ok(response);
            }
            else
            {
                return BadRequest("El usuario no existe o se encuentra bloqueado");
            }
        }

        public async void AddSession(UserDto model)
        {
            var claims = new List<Claim>
                {
                    new Claim("Name", model.Name),
                    new Claim("Surname", model.Surname),
                    new Claim("Email", model.Email),
                    new Claim("Token", model.Token),
                    new Claim("Rol", model.Rol.Name),
                };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {

            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);

        }

        [HttpGet("SignOut")]
        public async void SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}