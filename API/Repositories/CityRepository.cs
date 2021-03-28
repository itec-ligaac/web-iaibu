using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public interface ICityRepository
    {
        Task<IReadOnlyList<City>> getCitiesByCountryName(string name);
    }

    public class CityRepository : ICityRepository
    {
        private readonly DataContext _context;
        public CityRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<City>> getCitiesByCountryName(string name)
        {
            return await _context.Cities.Where(city => city.Country.ToLower() == name.ToLower()).ToListAsync();
        }
    }
}