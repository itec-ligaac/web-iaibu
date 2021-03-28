using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class Country : BaseEntity
    {
        [JsonPropertyName("country")]
        public string Name { get; set; }

        [JsonPropertyName("iso_code")]
        public string IsoCode { get; set; }

        [JsonPropertyName("data")]
        public List<CountryData> Data { get; set; } = new List<CountryData>();
    }
}