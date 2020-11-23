using System.Collections.Generic;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using KolesaEndTerm.Models;
using KolesaEndTerm.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KolesaEndTerm.Controllers.Api
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IPrivodRepository _privodRepository;
        private readonly IWheelRepository _wheelRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public CarController(ICarRepository carRepository, ICategoryRepository categoryRepository, ICityRepository cityRepository, ICommentRepository commentRepository, ICountryRepository countryRepository, IPrivodRepository privodRepository, UserManager<IdentityUser> userManager, IWheelRepository wheelRepository)
        {
            _carRepository = carRepository;
            _categoryRepository = categoryRepository;
            _cityRepository = cityRepository;
            _commentRepository = commentRepository;
            _countryRepository = countryRepository;
            _privodRepository = privodRepository;
            _userManager = userManager;
            _wheelRepository = wheelRepository;
        }

        
        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        
        [HttpGet("cars")]
        public IEnumerable<Car> GetAllCars()
        {
            return _carRepository.GetAllCars();
        }
        
        [HttpGet("cars/{carId}")]
        public Car GetCar(int carId)
        {
            return _carRepository.GetCar(carId);
        }
        
        [HttpPost("cars/add")]
        public IActionResult AddCar(JsonElement request)
        {
            var price = request.GetProperty("carPrice").GetInt32();
            var countryId = request.GetProperty("countryId").GetInt32();
            var country = _countryRepository.GetCountry(countryId);
            var cityId = request.GetProperty("cityId").GetInt32();
            var city = _cityRepository.GetCity(cityId);
            var engine = request.GetProperty("engine").GetInt32();
            var probeg = request.GetProperty("probeg").GetString();
            var wheelId = request.GetProperty("wheelId").GetInt32();
            var wheel = _wheelRepository.GetWheel(wheelId);
            var color = request.GetProperty("color").GetString();
            var privodId = request.GetProperty("privodId").GetInt32();
            var privod = _privodRepository.GetPrivod(privodId);
            var raztamojen = request.GetProperty("raztamojen").GetBoolean();
            var categoryId = request.GetProperty("categoryId").GetInt32();
            var category = _categoryRepository.GetCategory(categoryId);
            var description = request.GetProperty("description").GetString();
            var year = request.GetProperty("year").GetInt32();
            var car = new Car()
            {
                Price = price,
                CountryId = countryId,
                Country = country,
                CityId = city.Id,
                City = city,
                Engine = engine,
                Probeg = probeg,
                WheelId = wheelId,
                Wheel = wheel,
                Color = color,
                PrivodId = privodId,
                Privod = privod,
                Raztamojen = raztamojen,
                CategoryId = categoryId,
                Category = category,
                Description = description,
                Year = year
            };
            _carRepository.Add(car);
            return Ok("Created successfully");
        }
        
    }
}