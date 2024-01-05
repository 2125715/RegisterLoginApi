using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterLoginApi.Models;

namespace RegisterLoginApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserContext _context;
        public RegisterController(UserContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(_context.Users.Any(u=>u.UserName == user.UserName))
            {
                return BadRequest(new {message="Username already taken"});
            }
          
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
        [HttpGet("check-username")]
        public IActionResult CheckUsernameAvailability([FromQuery] string username) 
        { 
            var isTaken=_context.Users.Any(u => u.UserName == username);
            return Ok(!isTaken);
        }

       
    }
}
