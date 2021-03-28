using System;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class CountryData : BaseEntity
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("total_vaccinations")]
        public int TotalVaccinations { get; set; }

        [JsonPropertyName("people_vaccinated")]
        public int PeopleVaccinated { get; set; }

        [JsonPropertyName("total_vaccinations_per_hundred")]
        public decimal TotalVaccinationsPerHunderd { get; set; }

        [JsonPropertyName("people_vaccinated_per_hundred")]
        public decimal PeopleVaccinatedPerHunderd { get; set; }

        [JsonPropertyName("people_fully_vaccinated")]
        public int PeopleFullyVaccinated { get; set; }
        [JsonPropertyName("people_fully_vaccinated_per_hundred")]
        public decimal PeopleFullyVaccinatedPerHundred { get; set; }

        [JsonPropertyName("daily_vaccinations")]
        public int DailyVaccinations { get; set; }

        [JsonPropertyName("daily_vaccinations_raw")]
        public int DailyVaccinationsRaw { get; set; }

        [JsonPropertyName("daily_vaccinations_per_million")]
        public int DailyVaccinationsPerMilion { get; set; }

        [JsonPropertyName("daily_vaccinated_per_hundred")]
        public int DailyVaccinationsPerHundred { get; set; }
    }
}