using System.Collections.Generic;
using System.Net.Mime;
using System.Text.Json;
using KolesaEndTerm.Models;
using KolesaEndTerm.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KolesaEndTerm.Controllers.Api
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    public class WheelController : Controller
    {
        private readonly IWheelRepository _wheelRepository;

        public WheelController(
            IWheelRepository wheelRepository)
        {
            _wheelRepository = wheelRepository;
        }
        
        [HttpGet("wheels")]
        public IEnumerable<Wheel> GetAllwheels()
        {
            return _wheelRepository.GetAllWheels();
        }
        
        [HttpGet("wheels/{wheelId}")]
        public Wheel GetWheel(int wheelId)
        {
            return _wheelRepository.GetWheel(wheelId);
        }
        
        [HttpPost("wheels/add")]
        public IActionResult AddWheel(JsonElement request)
        {
            var wheelName = request.GetProperty("wheelName").GetString();
            _wheelRepository.Add(new Wheel { Name = wheelName});
            return Ok("Successful");
        }    
        
        [HttpPost("wheels/update")]
        public IActionResult UpdateWheel(JsonElement request)
        {
            var wheelId = request.GetProperty("wheelId").GetInt32();
            var wheelName = request.GetProperty("wheelName").GetString();
            var wheel = _wheelRepository.GetWheel(wheelId);
            if (wheel == null) return BadRequest("City Not Found");
            wheel.Name = wheelName;
            _wheelRepository.Update(wheel);
            return Ok("Updated successfully");
        }
        
        [HttpDelete("wheels/{wheelId}")]
        public IActionResult DeleteWheel(int wheelId)
        {
            var result = _wheelRepository.Delete(wheelId);
            if (result == null) return BadRequest("Item not found");  
            return Ok("Deleted successfully");
        }
    }
}