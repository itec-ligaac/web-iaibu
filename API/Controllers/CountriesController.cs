using System;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CountriesController : BaseController
    {
        private readonly ICountryRepository _countryRepo;
        private readonly ICityRepository _cityRepository;
        public CountriesController(ICountryRepository countryRepo, ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
            _countryRepo = countryRepo;
        }

        [HttpGet("countryNames")]
        public async Task<IActionResult> GetCountriesNames()
        {
            return Ok(await _countryRepo.GetCountrieNamesList());
        }

        [HttpGet]
        public async Task<IActionResult> GetCountriesFull()
        {
            return Ok(await _countryRepo.GetCountriesFullWithdata());
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetCountryByName([FromQuery] string name)
        {
            return Ok(await _countryRepo.GetCountryWithLatestData(name));
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetCountryFull([FromBody] FilterDto filterDto)
        {
            DateTime? from = null;
            DateTime? until = null;
            if (!string.IsNullOrEmpty(filterDto.DateFrom))
            {
                from = DateTime.Parse(filterDto.DateFrom);
            }
            if (!string.IsNullOrEmpty(filterDto.DateUntil))
            {
                until = DateTime.Parse(filterDto.DateUntil);
            }
            return Ok(await _countryRepo.GetCountryByNameAndDate(filterDto.Name, from, until));
        }

        [HttpGet("city/{countryName}")]
        public async Task<IActionResult> GetCitiesByCountryName(string countryName)
        {
            var cities = await _cityRepository.getCitiesByCountryName(countryName);
            if (cities == null || cities.Count == 0) return NotFound("No city found");
            return Ok(cities);
        }



    }
}