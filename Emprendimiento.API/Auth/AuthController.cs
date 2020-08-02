using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Emprendimiento.API.Services.Auth;
using Domain.Dto.Layer;
using Shared.Layer;

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
            model.Password = model.Password.ToMd5();

            return Ok(await _authService.Authenticate(model));
        }
    }
}