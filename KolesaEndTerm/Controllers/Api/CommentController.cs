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
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public CommentController(
            ICommentRepository commentRepository, 
            UserManager<IdentityUser> userManager, 
            ICountryRepository countryRepository)
        {
            _commentRepository = commentRepository;
            _userManager = userManager;
        }
        
        [HttpGet("comments")]
        public IEnumerable<Comment> GetAllComments()
        {
            return _commentRepository.GetAllComments();
        }
        
        [HttpGet("comments/{commentId}")]
        public Comment GetComment(int commentId)
        {
            return _commentRepository.GetComment(commentId);
        }
        
        [HttpPost("comments/add")]
        public IActionResult AddComment(JsonElement request)
        {
            var carId = request.GetProperty("carId").GetInt32();
            var text = request.GetProperty("text").GetString();
            var identityUser = request.GetProperty("IdentityUserId").GetString();
            _commentRepository.Add(new Comment() { CarId = carId, Text = text, IdentityUserId = identityUser});
            return Ok("Successful");
        }    
        
        [HttpPost("comments/update")]
        public IActionResult UpdateComment(JsonElement request)
        {
            var carId = request.GetProperty("carId").GetInt32();
            var text = request.GetProperty("text").GetString();
            var identityUser = request.GetProperty("IdentityUserId").GetString();
            var comment = new Comment();
            comment.Text = comment.Text;
            _commentRepository.Update(comment);
            return Ok("Updated successfully");
        }
        
        [HttpDelete("comments/{commentId}")]
        public IActionResult DeleteComment(int commentId)
        {
            var result = _commentRepository.Delete(commentId);
            if (result == null) return BadRequest("Item not found");  
            return Ok("Deleted successfully");
        }
    }
}