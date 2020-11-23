using System.Collections.Generic;
using System.Net.Mime;
using System.Text.Json;
using KolesaEndTerm.Models;
using KolesaEndTerm.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EndTerm.Controllers.Api
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    public class CityController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public CityController(
            ICityRepository cityRepository, 
            UserManager<IdentityUser> userManager, 
            ICountryRepository countryRepository)
        {
            _cityRepository = cityRepository;
            _userManager = userManager;
            _countryRepository = _countryRepository;
        }
        
        [HttpGet("cities")]
        public IEnumerable<City> GetAllCities()
        {
            return _cityRepository.GetAllCities();
        }
        
        [HttpGet("cities/{cityId}")]
        public City GetCity(int cityId)
        {
            return _cityRepository.GetCity(cityId);
        }
        
        [HttpPost("cities/add")]
        public IActionResult AddCity(JsonElement request)
        {
            var countryId = request.GetProperty("countryId").GetInt32();
            var cityName = request.GetProperty("cityName").GetString();
            var country = _countryRepository.GetCountry(countryId);
            if (country == null) return BadRequest("Country Not Found");
            _cityRepository.Add(new City { Name = cityName, CountryId = countryId, Country = country});
            return Ok("Successful");
        }    
        
        [HttpPost("cities/update")]
        public IActionResult UpdateCity(JsonElement request)
        {
            var cityId = request.GetProperty("cityId").GetInt32();
            var cityName = request.GetProperty("cityName").GetString();
            var city = _cityRepository.GetCity(cityId);
            if (city == null) return BadRequest("City Not Found");
            city.Name = cityName;
            _cityRepository.Update(city);
            return Ok("Updated successfully");
        }
        
        [HttpDelete("cities/{cityId}")]
        public IActionResult DeleteCity(int cityId)
        {
            var result = _cityRepository.Delete(cityId);
            if (result == null) return BadRequest("Item not found");  
            return Ok("Deleted successfully");
        }
        
    }
}