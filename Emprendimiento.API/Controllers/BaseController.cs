using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emprendimiento.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IActionResult ResponseResult(ServiceResponse sr)
        {
            if (sr.StatusCode == StatusCodes.Status403Forbidden)
                return Forbid();

            if (sr.StatusCode == StatusCodes.Status400BadRequest)
                return StatusCode(StatusCodes.Status400BadRequest, sr);

            if (sr.StatusCode == StatusCodes.Status500InternalServerError)
                return StatusCode(StatusCodes.Status500InternalServerError, sr);
            else
                return Ok(sr);
        }

        public bool RequestValid(ServiceResponse sr)
        {
            return !sr.Errors.Any();
        }
    }
}
