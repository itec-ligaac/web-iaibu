using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetCountrieNamesList()
        {
            return await _context.Countries.Select(x => x.Name).ToListAsync();
        }

        public async Task<List<Country>> GetCountriesFullWithdata()
        {
            return await _context.Countries.Include(x => x.Data).ToListAsync();
        }

        public async Task<Country> GetCountryByName(string name)
        {
            return await _context.Countries.Include(x => x.Data).FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<CountryToSendBack> GetCountryWithLatestData(string name)
        {
            Country country = await GetCountryByName(name);
            CountryData latestCountryData = country.Data[country.Data.Count - 1];
            CountryToSendBack countryToSendBack = new CountryToSendBack { Name = country.Name, CountryData = latestCountryData };
            return countryToSendBack;
        }

        public async Task<Country> GetCountryByNameAndDate(string name, DateTime? from = null, DateTime? until = null)
        {
            Country country = await GetCountryByName(name);
            if (from != null || until != null)
                country.Data = country.Data.Where(x => x.Date > from && x.Date < until).ToList();
            return country;
        }




        // public async Task<CountryData> GetCountryDataByDateAsync(DateTime date){

        // }
    }
}