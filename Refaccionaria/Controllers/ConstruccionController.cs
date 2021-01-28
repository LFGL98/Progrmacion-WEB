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
    public class Construcciones
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public string Ubicacion { get; set; }
        public string PalabraClave { get; set; }
        public string IdDistribuidor { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class ConstruccionController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Construcciones> Get()
        {
            var context = new refaccionariaContext();
            var construccions = from e in context.Construccion
                              join s in context.Distribuidores on e.IdDistribuidor equals s.Id
                              orderby e.Id ascending
                              select new Construcciones
                              {
                                  Id = e.Id,
                                  Nombre = e.Nombre,
                                  Descripcion = e.Descripcion,
                                  Precio = e.Precio,
                                  Ubicacion = e.Ubicacion,
                                  PalabraClave = e.PalabraClave,
                                  IdDistribuidor = s.Id
                              };
            return construccions;
        }


       
        [HttpPost]
        public IActionResult Post([FromBody] Construccion value)
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

                context.Construccion.Add(value);
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
        [HttpGet("{palabra}")]
        public Construccion Get(string palabra)
        {
            //var cachado = cache.Get<Employees> (id);

            //if (cachado != null) {
            //    return cachado;
            //}  

            var context = new refaccionariaContext();

            Construccion constre = context.Construccion.Where<Construccion>(e => e.PalabraClave==palabra).FirstOrDefault<Construccion>();
            if (constre == null)
            {
                return null;
            }

            //var options = new MemoryCacheEntryOptions {
            //     Priority = CacheItemPriority.Normal,
            //     AbsoluteExpiration = DateTime.Now.AddMinutes (30)
            //};

            //cache.Set<Employees>(employee.EmpNo, employee, options);


            return constre;
        }


        [HttpGet("{id}")]
        public Empleados Get2(string id)
        {
            //var cachado = cache.Get<Employees> (id);

            //if (cachado != null) {
            //    return cachado;
            //}  

            var context = new refaccionariaContext();

            Empleados employee = context.Empleados.Where<Empleados>(e => e.Id == id).FirstOrDefault<Empleados>();
            if (employee == null)
            {
                return null;
            }

            //var options = new MemoryCacheEntryOptions {
            //     Priority = CacheItemPriority.Normal,
            //     AbsoluteExpiration = DateTime.Now.AddMinutes (30)
            //};

            //cache.Set<Employees>(employee.EmpNo, employee, options);


            return employee;
        }

        [HttpGet("{palabra}")]
        public Construccion Get3(string palabra)
        {
            //var cachado = cache.Get<Employees> (id);

            //if (cachado != null) {
            //    return cachado;
            //}  

            var context = new refaccionariaContext();

            Construccion constr = context.Construccion.Where<Construccion>(e => e.PalabraClave == palabra).FirstOrDefault<Construccion>();
            if (constr == null)
            {
                return null;
            }

            //var options = new MemoryCacheEntryOptions {
            //     Priority = CacheItemPriority.Normal,
            //     AbsoluteExpiration = DateTime.Now.AddMinutes (30)
            //};

            //cache.Set<Employees>(employee.EmpNo, employee, options);


            return constr;
        }


        [HttpDelete("{id}")]
        public void Delete(string id)
        {

            try
            {
                var context = new refaccionariaContext();
                var constr = context.Construccion.Where(e => e.Id == id).FirstOrDefault();
                if (constr == null) return;

                context.Construccion.Remove(constr);
                context.SaveChanges();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return;
            }
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Construccion value)
        {
            bool error = false;

            try
            {
                var context = new refaccionariaContext();

                var constru = context.Construccion.Where<Construccion>(e => e.Id == id).FirstOrDefault();
                if (constru == null)
                {
                    return new JsonResult(new { Status = "Fail" }); ;
                }

                constru.Nombre = WebUtility.HtmlEncode(value.Nombre);
                constru.Descripcion = WebUtility.HtmlEncode(value.Descripcion);
                constru.Precio = value.Precio;
                constru.Ubicacion = WebUtility.HtmlEncode(value.Ubicacion);
                constru.PalabraClave = WebUtility.HtmlEncode(value.PalabraClave);
                constru.IdDistribuidor = WebUtility.HtmlEncode(value.IdDistribuidor);
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

    }
}
