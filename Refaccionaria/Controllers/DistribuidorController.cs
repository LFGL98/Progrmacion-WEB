using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
    public class Distribuidor
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Rfc { get; set; }
        public string Telefono { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class DistribuidorController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Distribuidor> Get()
        {
            var context = new refaccionariaContext();
            var distri = from e in context.Distribuidores
                                orderby e.Id ascending
                                select new Distribuidor
                                {
                                    Id = e.Id,
                                    Nombre = e.Nombre,
                                    Rfc = e.Rfc,
                                    Telefono = e.Telefono
                                };
            return distri;
        }

        [HttpGet("{id}")]
        public Distribuidores Get(string id)
        {
            //var cachado = cache.Get<Employees> (id);

            //if (cachado != null) {
            //    return cachado;
            //}  

            var context = new refaccionariaContext();

            Distribuidores distri = context.Distribuidores.Where<Distribuidores>(e => e.Id == id).FirstOrDefault<Distribuidores>();
            if (distri == null)
            {
                return null;
            }

            //var options = new MemoryCacheEntryOptions {
            //     Priority = CacheItemPriority.Normal,
            //     AbsoluteExpiration = DateTime.Now.AddMinutes (30)
            //};

            //cache.Set<Employees>(employee.EmpNo, employee, options);


            return distri;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Distribuidor value)
        {
            bool error = false;

            try
            {
                var context = new refaccionariaContext();

                var distri = context.Distribuidores.Where<Distribuidores>(e => e.Id == id).FirstOrDefault();
                if (distri == null)
                {
                    return new JsonResult(new { Status = "Fail" }); ;
                }

                distri.Nombre = WebUtility.HtmlEncode(value.Nombre);
                distri.Rfc = WebUtility.HtmlEncode(value.Rfc);
                distri.Telefono = WebUtility.HtmlEncode(value.Telefono);
                

                context.SaveChanges();
            }
            catch
            {
                error = true;
            }

            var result = new
            {
                Status = !error ? "Success" : "Fail"
            };

            return new JsonResult(result);
        }



        [HttpPost]
        public IActionResult Post([FromBody] Distribuidores value)
        {
            bool error = false;
            String id = WebUtility.HtmlEncode(value.Id);
            String nombre = WebUtility.HtmlEncode(value.Nombre);
            String rfc = WebUtility.HtmlEncode(value.Rfc);
            String telefono = WebUtility.HtmlEncode(value.Telefono);
          


            try
            {
                var context = new refaccionariaContext();

                context.Distribuidores.Add(value);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                error = true;
            }

            var result = new
            {
                Status = !error ? "Success" : "Fail"
            };

            return new JsonResult(result);
        }





        [HttpDelete("{id}")]
        public void Delete(string id)
        {

            try
            {
                var context = new refaccionariaContext();
                var distri = context.Distribuidores.Where(e => e.Id == id).FirstOrDefault();
                if (distri == null) return;

                context.Distribuidores.Remove(distri);
                context.SaveChanges();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return;
            }
        }
    }
}
