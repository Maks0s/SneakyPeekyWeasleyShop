using SneakyPeekyWeasleyShop.Models;
using System.Text.Json;


namespace SneakyPeekyWeasleyShop.Services
{
    public class JsonFileMagicProductService
    {
        public JsonFileMagicProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get
            {
                return Path.Combine(WebHostEnvironment.WebRootPath, "data", "magicProducts.Json");
            }
        }

        public IEnumerable<MagicProduct> GetMagicProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<MagicProduct[]>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }
    }
}
