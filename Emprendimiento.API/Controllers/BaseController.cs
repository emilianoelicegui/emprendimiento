using Domain.Dto.Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Emprendimiento.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ServiceResponse ValidateModel (ModelStateDictionary keyValuePairs)
        {
            var sr = new ServiceResponse();

            if (!keyValuePairs.IsValid)
            {
                foreach (var k in keyValuePairs.Values)
                {
                    sr.AddErrorValidation(k.Errors.Select(x => x.ErrorMessage).First());
                }
            }

            return sr;
        }

        protected IActionResult ResponseResult(ServiceResponse sr)
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
    }
}
