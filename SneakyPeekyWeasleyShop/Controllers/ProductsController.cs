using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SneakyPeekyWeasleyShop.Models;
using SneakyPeekyWeasleyShop.Services;

namespace SneakyPeekyWeasleyShop.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileMagicProductService jsonFileMagicProductService)
        {
            _jsonFileMagicProductService = jsonFileMagicProductService;
        }

        private JsonFileMagicProductService _jsonFileMagicProductService;

        [HttpGet]
        public IEnumerable<MagicProduct> Get()
        {
            return _jsonFileMagicProductService.GetMagicProducts();
        }

        [Route("ratings")]
        [HttpPatch]
        public ActionResult GetRatings([FromQuery] string productName, [FromQuery] int rating)
        {
            if (productName is null)
                return BadRequest();

            _jsonFileMagicProductService.AddRaiting(productName, rating);
            return Ok();
        }

    }
}
