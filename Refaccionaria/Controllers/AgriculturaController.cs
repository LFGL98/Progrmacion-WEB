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
    public class Agriculturas
    {
        public String id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public float Precio { get; set; }
        public String Ubicacion { get; set; }
        public String PalabraClave { get; set; }
        public String IdDistribuidor { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class AgriculturaController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Agriculturas> Get()
        {
            var context = new refaccionariaContext();
            var agricultura = from e in context.Agricultura
                              join s in context.Distribuidores on e.IdDistribuidor equals s.Id
                              orderby e.Id ascending
                              select new Agriculturas
                              {
                                  id = e.Id,
                                  Nombre = e.Nombre,
                                  Descripcion = e.Descripcion,
                                  Precio = e.Precio,
                                  Ubicacion = e.Ubicacion,
                                  PalabraClave = e.PalabraClave,
                                  IdDistribuidor = s.Id
                              };
            return agricultura;
        }


        [HttpPost]
        public IActionResult Post([FromBody] Agricultura value)
        {
            bool error = false;
            String id = WebUtility.HtmlEncode(value.Id);
            String nombre = WebUtility.HtmlEncode(value.Nombre);
            String descripcion = WebUtility.HtmlEncode(value.Descripcion);
            float precio = value.Precio;
            String ubicacion = WebUtility.HtmlEncode(value.Ubicacion);
            String palabra = WebUtility.HtmlEncode(value.PalabraClave);
            String distribuidor = WebUtility.HtmlEncode(value.IdDistribuidor);

           
            try
            {
                var context = new refaccionariaContext();

                context.Agricultura.Add(value);
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

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Agriculturas value)
        {
            bool error = false;

            try
            {
                var context = new refaccionariaContext();

                var agri = context.Agricultura.Where<Agricultura>(e => e.Id == id).FirstOrDefault();
                if (agri == null)
                {
                    return new JsonResult(new { Status = "Fail" }); ;
                }

                agri.Nombre = WebUtility.HtmlEncode(value.Nombre);
                agri.Descripcion = WebUtility.HtmlEncode(value.Descripcion);
                agri.Precio = value.Precio;
                agri.Ubicacion = WebUtility.HtmlEncode(value.Ubicacion);
                agri.PalabraClave = WebUtility.HtmlEncode(value.PalabraClave);
                agri.IdDistribuidor= WebUtility.HtmlEncode(value.IdDistribuidor);
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

        [HttpGet("{id}")]
        public Agricultura Get2(string id)
        {
            //var cachado = cache.Get<Employees> (id);

            //if (cachado != null) {
            //    return cachado;
            //}  

            var context = new refaccionariaContext();

            Agricultura agri = context.Agricultura.Where<Agricultura>(e => e.Id == id).FirstOrDefault<Agricultura>();
            if (agri == null)
            {
                return null;
            }

            //var options = new MemoryCacheEntryOptions {
            //     Priority = CacheItemPriority.Normal,
            //     AbsoluteExpiration = DateTime.Now.AddMinutes (30)
            //};

            //cache.Set<Employees>(employee.EmpNo, employee, options);


            return agri;
        }

        [HttpGet("{palabra}")]
        public Agricultura Get(string palabra)
        {
            //var cachado = cache.Get<Employees> (id);

            //if (cachado != null) {
            //    return cachado;
            //}  

            var context = new refaccionariaContext();

            Agricultura agri = context.Agricultura.Where<Agricultura>(e => e.PalabraClave == palabra).FirstOrDefault<Agricultura>();
            if (agri == null)
            {
                return null;
            }

            //var options = new MemoryCacheEntryOptions {
            //     Priority = CacheItemPriority.Normal,
            //     AbsoluteExpiration = DateTime.Now.AddMinutes (30)
            //};

            //cache.Set<Employees>(employee.EmpNo, employee, options);


            return agri;
        }


        [HttpDelete("{id}")]
        public void Delete(string id)
        {

            try
            {
                var context = new refaccionariaContext();
                var agriculturas = context.Agricultura.Where(e => e.Id == id).FirstOrDefault();
                if (agriculturas == null) return;

                context.Agricultura.Remove(agriculturas);
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
