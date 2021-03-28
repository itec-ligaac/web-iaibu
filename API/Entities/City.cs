using System.Text.Json.Serialization;

namespace API.Entities
{
    public class City : BaseEntity
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("geonameid")]
        public int Geonameid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("subcountry")]
        public string SubCountry { get; set; }
    }
}