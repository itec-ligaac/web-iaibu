using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public static class CountryService
    {
        private readonly static string countryPath = Path.Combine(Directory.GetCurrentDirectory(), "JsonData", "vaccinations.json");
        private readonly static string cityPath = Path.Combine(Directory.GetCurrentDirectory(), "JsonData", "world-cities_json.json");
        public static async Task SeedData(DataContext context)
        {
            if (!await context.Countries.AnyAsync())
            {
                var data = JsonSerializer.Deserialize<Country[]>(File.ReadAllText(countryPath), new JsonSerializerOptions { IncludeFields = true });
                foreach (var country in data)
                {
                    context.Countries.Add(country);
                }
                await context.SaveChangesAsync();
            }

            if (!await context.Cities.AnyAsync())
            {
                var data = JsonSerializer.Deserialize<City[]>(File.ReadAllText(cityPath), new JsonSerializerOptions { IncludeFields = true });
                foreach (var city in data)
                {
                    context.Cities.Add(city);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}