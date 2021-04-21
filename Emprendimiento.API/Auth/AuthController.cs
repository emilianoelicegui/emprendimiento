using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Emprendimiento.API.Services.Auth;
using Domain.Dto.Layer;
using Shared.Layer;
using System;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Emprendimiento.API.Auth
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAny")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto model)
        {
            try
            {
                model.Password = model.Password.ToMd5();

                var response = await _authService.Authenticate(model);

                if (!response.Status)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, response.Errors.First().ErrorMessage);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}