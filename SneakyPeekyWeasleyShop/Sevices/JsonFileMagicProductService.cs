using Microsoft.AspNetCore.Mvc;
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

        public void AddRaiting(string productName, int rating)
        {
            var magicProducts = GetMagicProducts();
            var conreteProduct = magicProducts.First(x => x.Name == productName);
            
            if(conreteProduct.Ratings is null)
            {
                conreteProduct.Ratings = Array.Empty<int>();
            }

            conreteProduct.Ratings = conreteProduct.Ratings.Append(rating).ToArray();

            using var outputStream = File.OpenWrite(JsonFileName);

            JsonSerializer.Serialize<IEnumerable<MagicProduct>>(
                new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = true,
                    Indented = true
                }),
                magicProducts
            );
        }
    }
}
