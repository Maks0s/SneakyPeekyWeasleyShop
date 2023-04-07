using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SneakyPeekyWeasleyShop.Models;
using SneakyPeekyWeasleyShop.Services;

namespace SneakyPeekyWeasleyShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly JsonFileMagicProductService _magicProductService;
        public IEnumerable<MagicProduct> MagicProducts { get; private set; }

        public IndexModel(ILogger<IndexModel> logger,
            JsonFileMagicProductService magicProductService)
        {
            _logger = logger;
            _magicProductService = magicProductService;
        }

        public void OnGet()
        {
            MagicProducts = _magicProductService.GetMagicProducts();
        }
    }
}