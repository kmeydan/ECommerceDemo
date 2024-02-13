using Business.Abstract.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUrunlerServices _urunlerServices;

        public ProductController(IUrunlerServices urunlerServices)
        {
            _urunlerServices = urunlerServices;
        }
        [HttpGet("AllProducts")]
        public IActionResult AllProducts()
        {
            return Ok(_urunlerServices.GetAll());
        }
    }
}
