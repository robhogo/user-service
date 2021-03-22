using Microsoft.AspNetCore.Mvc;
using RoBHo_UserService.Helpers;
using RoBHo_UserService.Request;
using RoBHo_UserService.Services;
using System;
using System.Threading.Tasks;

namespace RoBHo_UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            try
            {
                var response = _userService.Authenticate(model);

                if (response == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.ToString() });
            }
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {
            try
            {
                bool response = _userService.Register(model);

                if (!response)
                    return BadRequest(new { message = "Username is already in use" });

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.ToString() });
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
