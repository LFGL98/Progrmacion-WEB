using System;
using System.Text;
using Refaccionaria.Helpers;
using Refaccionaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesWebService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserService _userService;
        private IDataProtector protector;

        public UsersController(IUserService userService, IDataProtectionProvider provider)
        {
            _userService = userService;
            this.protector = provider.CreateProtector("ProtectorID");
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] Empleados userParam)
        {
            var user = _userService.Authenticate(userParam.Id, userParam.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or Password is incorrect!" });
            }

            var foo = new Empleados();

            var bar = this.protector.Protect(user.Id);
            foo.Id = bar;

            //bar = this.protector.Protect (System.Text.Encoding.UTF8.GetBytes (user.UserName));
            //foo.UserName = System.Text.Encoding.UTF8.GetString (bar);

            /*foo.FirstName = user.FirstName;
            foo.LastName = user.LastName;
            foo.Password = user.Password;*/
            foo.Token = user.Token;

            return Ok(foo);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("getuser/{cipherID}")]
        public Empleados GetUser(string cipherID)
        {
            var id = this.protector.Unprotect(cipherID);
            return null;
        }
    }
}
