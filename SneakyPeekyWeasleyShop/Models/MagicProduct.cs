using System.Text.Json.Serialization;
using System.Text.Json;

namespace SneakyPeekyWeasleyShop.Models
{
    public class MagicProduct
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("img")]
        public string? Image { get; set; }

        [JsonPropertyName("url")]
        public string? URL { get; set; }

        public override string ToString() => JsonSerializer.Serialize<MagicProduct>(this);
    }
}
