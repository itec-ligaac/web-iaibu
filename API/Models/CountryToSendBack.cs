using API.Entities;

namespace API.Models
{
    public class CountryToSendBack
    {
        public string Name { get; set; }
        public CountryData CountryData { get; set; }
    }
}