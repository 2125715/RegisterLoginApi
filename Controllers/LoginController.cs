using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterLoginApi.Models;
using System.ComponentModel.DataAnnotations;

namespace RegisterLoginApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserContext _context;
        public LoginController(UserContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          
            var user = _context.Users.FirstOrDefault(u => u.UserName == loginRequest.UserName &&  u.Password == loginRequest.Password);
            if (user == null)
            {
                ModelState.AddModelError("UserName", "Invalid Credentials");
                return BadRequest(ModelState);
            }
            if(!IsPasswordValid(user.Password,loginRequest.Password)) 
            {
                ModelState.AddModelError("Password", "Invalid Password");
                return BadRequest(ModelState);
            }
            return Ok(user);
        }
        private bool IsPasswordValid(string storedPassword,string enteredPassword)
        {
            return storedPassword == enteredPassword;
        }

    }
    public class LoginRequest
    {
       

        [Required(ErrorMessage = "username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }


    }
}
