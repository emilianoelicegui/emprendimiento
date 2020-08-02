using Microsoft.AspNetCore.Mvc;

namespace Emprendimiento.API.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Runing ...");
        }
    }
}