using Microsoft.AspNetCore.Mvc;
using RoBHo_UserService.Request;
using RoBHo_UserService.Services;
using System;

namespace RoBHo_UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IAuthLogic _authLogic;

        public UserController(IAuthLogic authLogic)
        {
            _authLogic = authLogic;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            try
            {
                var response = _authLogic.Authenticate(model);

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
                bool response = _authLogic.Register(model);

                if (!response)
                    return BadRequest(new { message = "Username is already in use" });

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.ToString() });
            }
        }
    }
}
