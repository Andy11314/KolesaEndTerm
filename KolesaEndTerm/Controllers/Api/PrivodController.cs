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
    public class PrivodController : Controller
    {
        private readonly IPrivodRepository _privodRepository;

        public PrivodController(
            IPrivodRepository privodRepository)
        {
            _privodRepository = privodRepository;
        }
        
        [HttpGet("privods")]
        public IEnumerable<Privod> GetAllprivods()
        {
            return _privodRepository.GetAllPrivods();
        }
        
        [HttpGet("privods/{privodId}")]
        public Privod GetPrivod(int privodId)
        {
            return _privodRepository.GetPrivod(privodId);
        }
        
        [HttpPost("privods/add")]
        public IActionResult AddPrivod(JsonElement request)
        {
            var privodName = request.GetProperty("privodName").GetString();
            _privodRepository.Add(new Privod { Name = privodName});
            return Ok("Successful");
        }    
        
        [HttpPost("privods/update")]
        public IActionResult UpdatePrivod(JsonElement request)
        {
            var privodId = request.GetProperty("privodId").GetInt32();
            var privodName = request.GetProperty("privodName").GetString();
            var privod = _privodRepository.GetPrivod(privodId);
            if (privod == null) return BadRequest("City Not Found");
            privod.Name = privodName;
            _privodRepository.Update(privod);
            return Ok("Updated successfully");
        }
        
        [HttpDelete("privods/{privodId}")]
        public IActionResult DeletePrivod(int privodId)
        {
            var result = _privodRepository.Delete(privodId);
            if (result == null) return BadRequest("Item not found");  
            return Ok("Deleted successfully");
        }
    }
}