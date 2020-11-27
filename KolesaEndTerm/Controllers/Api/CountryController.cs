using System.Collections.Generic;
using System.Net.Mime;
using System.Text.Json;
using KolesaEndTerm.Models;
using KolesaEndTerm.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KolesaEndTerm.Controllers.Api
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public CountryController(
            UserManager<IdentityUser> userManager, 
            ICountryRepository countryRepository)
        {
            _userManager = userManager;
            _countryRepository = _countryRepository;
        }
        
        [HttpGet("countries")]
        public IEnumerable<Country> GetAllCountries()
        {
            return _countryRepository.GetAllCountries();
        }
        
        [HttpGet("countries/{countryId}")]
        public Country GetCountry(int countryId)
        {
            return _countryRepository.GetCountry(countryId);
        }
        
        [HttpPost("countries/add")]
        public IActionResult AddCountry(JsonElement request)
        {
            var countryId = request.GetProperty("countryId").GetInt32();
            var countryName = request.GetProperty("cityName").GetString();
            _countryRepository.Add(new Country() { Name = countryName});
            return Ok("Successful");
        }    
        
        [HttpPost("countries/update")]
        public IActionResult UpdateCountry(JsonElement request)
        {
            var countryId = request.GetProperty("countryId").GetInt32();
            var countryName = request.GetProperty("countryName").GetString();
            var country = _countryRepository.GetCountry(countryId);
            if (country == null) return BadRequest("City Not Found");
            country.Name = country.Name;
            _countryRepository.Update(country);
            return Ok("Updated successfully");
        }
        
        [HttpDelete("countries/{countryId}")]
        public IActionResult DeleteCountry(int countryId)
        {
            var result = _countryRepository.Delete(countryId);
            if (result == null) return BadRequest("Item not found");  
            return Ok("Deleted successfully");
        }   
    }
}