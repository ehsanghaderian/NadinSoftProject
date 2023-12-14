using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace NadinSoftProject.Host.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductsController : BaseApiController
    {
        [HttpGet("")]

        public IActionResult Index()
        {
            return Ok("salam");
        }
    }
}
