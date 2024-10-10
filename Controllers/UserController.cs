using Microsoft.AspNetCore.Mvc;
using Web_Api_Project.Interface;
using Web_Api_Project.Models;
using Web_Api_Project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Web_Api_Project.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("{userId}")]
        public IActionResult Get(int userId)
        {
            return Ok(_userService.Get(userId));
        }

        [HttpPost("{currentUserId}/post")]
        public IActionResult post(int currentUserId, User user)
        {
            var currentUser = _userService.Get(currentUserId);
            if (currentUser == null)
            {
                return NotFound("Current user not found.");

            }
            if (currentUser.Role != "Admin")
            {
                return Unauthorized("Only administrators can add users.");
            }

            var result = _userService.Post(currentUser, user);
            if (result.Success)
            {
                return Ok(result.Message);

            }
            else
            {
                return BadRequest(result.Message);

            }
        }

        [HttpDelete("{currentUserId}/delete/{userId}")]
        public IActionResult Delete(int currentUserId, int userId)
        {
            var currentUser = _userService.Get(currentUserId);
            if (currentUser == null)
            {
                return NotFound("Current user not found.");
            }

            if (currentUser.Role != "Admin")
            {
                return Unauthorized("Only administrators can delete users.");
            }

            var result = _userService.Delete(currentUser, userId);
            if (result.Success)
            {
                return Ok(result.Message);

            }
            else
            {
                return BadRequest(result.Message);

            }
        }
    }
}

