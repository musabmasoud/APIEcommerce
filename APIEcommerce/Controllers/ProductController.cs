using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public string GetProducts()
        {
            return "List Of Products";
        }
        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return "One Of Product";
        }
    }
}
