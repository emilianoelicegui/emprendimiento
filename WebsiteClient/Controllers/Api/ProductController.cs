using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dto.Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebsiteClient.Services;

namespace WebsiteClient.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #region GET 
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productService.GetProducts();

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAllByCompany")]
        public async Task<IActionResult> GetAllByCompany(string name, int? idCompany, int draw, int start, int length)
        {
            var response = await _productService.GetAllByCompany(name, idCompany, draw, start, length);

            if (response != null)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest();
            }
        }

        #endregion GET

        #region PUT 

        [HttpPut("{id}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productService.Delete(id);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        #endregion PUT 
    }
}