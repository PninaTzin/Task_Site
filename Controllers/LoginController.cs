using Microsoft.AspNetCore.Mvc;
using Web_Api_Project.Services;
using Web_Api_Project.Models;
using Microsoft.AspNetCore.Identity.Data;
using Web_Api_Project.Interface;

namespace Web_Api_Project.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        // private readonly IUserService _userService;
        private readonly ILoginService _loginService; // עדכון לשירות ההזדהות

        public LoginController(ILoginService loginService)
        {
            this._loginService = loginService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            // קריאה לפונקציית ההזדהות ב-LoginService
            // try
            // {
            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Username or password is missing");
            }

            var user = _loginService.Authenticate(request.UserName, request.Password);
            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }
            return Ok(new { token = "your_generated_token_here" }); // החזרת טוקן מתאימה

            // החזרת תגובה אם הזדהות הצליחה
            // return Ok(new { Message = "Login successful" });
            // }
            // catch (Exception ex)
            // {
            //     // רישום השגיאה ליומנים והחזרת תגובה עם שגיאה כללית
            //     Console.Error.WriteLine($"Error during login: {ex.Message}");
            //     return StatusCode(500, "An error occurred while processing your request.");
            // }
        }
    }

    public class UserLoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}




