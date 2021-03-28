using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Models;

namespace API.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetCountriesFullWithdata();
        Task<List<string>> GetCountrieNamesList();
        Task<Country> GetCountryByName(string name);
        Task<Country> GetCountryByNameAndDate(string name, DateTime? from = null, DateTime? until = null);
        Task<CountryToSendBack> GetCountryWithLatestData(string name);

    }
}