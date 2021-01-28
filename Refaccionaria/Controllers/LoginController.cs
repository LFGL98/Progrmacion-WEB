using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;


using Refaccionaria.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Ganss.XSS;
using System.Net;
using Microsoft.AspNetCore.Cors;
namespace Refaccionaria.Controllers
{
    public class EmpleadoLogin
    {
        public String id { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Telefono { get; set; }

      
    }

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] Empleados value)
        {
            bool error = false;
            string id = WebUtility.HtmlEncode(value.Id);
            string firstName = WebUtility.HtmlEncode(value.Nombre);
            string lastName = WebUtility.HtmlEncode(value.Apellidos);
            string telefono = WebUtility.HtmlEncode(value.Telefono);
            string password = WebUtility.HtmlEncode(value.Password);
          
            try
            {
                var context = new refaccionariaContext();
                Empleados employee = context.Empleados.Where<Empleados>(e => e.Id == id).FirstOrDefault<Empleados>();
                Empleados employee2 = context.Empleados.Where<Empleados>(e => e.Password == password).FirstOrDefault<Empleados>();
                if (employee == null || employee2==null)
                {
                    return new JsonResult(new { Status = "Fail" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                error = true;
            }

            if (id=="1")
            {
                return new JsonResult(new { Status = "1" });
            }
            
            var result = new
            {
                Status = !error ? "Success" : "Fail"
            };

            return new JsonResult(result);
        }
    }
}
