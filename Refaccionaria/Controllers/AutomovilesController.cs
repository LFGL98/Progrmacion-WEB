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
    public class Automovil
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
    public class AutomovilesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Automovil> Get()
        {
            //var cachado = cache.Get<List<Empleado>>(EMPLOYEES_LIST);
            //if (cachado != null) {
            //    return cachado;
            //}

            var context = new refaccionariaContext();
            //var employees = context.Employees.Where<Employees>(e => e.LastName.Contains("Smith"));

            //
            // SELECT employees.first_name, employees.last_name, titles.title, salaries.salary
            // FROM employees INNER JOIN titles ON employees.emp_no = titles.emp_no
            // INNER JOIN salaries ON employees.emp_no = salaries.emp_no
            // INNER JOIN inner join dept_emp ON employees.emp_no = dept_emp.emp_no
            // INNER JOIN dept_manager ON employees.emp_no = dept_manager.emp_no
            // WHERE employees.last_name like 'smith'
            var autos = from e in context.Automoviles
                        join s in context.Distribuidores on e.IdDistribuidor equals s.Id
                                //join s in context.Salaries on e.EmpNo equals s.EmpNo
                                //join t in context.Titles on e.EmpNo equals t.EmpNo
                            orderby e.Id ascending
                            select new Automovil
                            {
                                Id= e.Id,
                                Nombre = e.Nombre,
                                Descripcion = e.Descripcion,
                                Precio = e.Precio,
                                Ubicacion = e.Ubicacion,
                                PalabraClave = e.PalabraClave,
                                IdDistribuidor = s.Id
                            };

            return autos;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Automoviles value)
        {
            bool error = false;

            try
            {
                var context = new refaccionariaContext();

                var agri = context.Automoviles.Where<Automoviles>(e => e.Id == id).FirstOrDefault();
                if (agri == null)
                {
                    return new JsonResult(new { Status = "Fail" }); ;
                }

                agri.Nombre = WebUtility.HtmlEncode(value.Nombre);
                agri.Descripcion = WebUtility.HtmlEncode(value.Descripcion);
                agri.Precio = value.Precio;
                agri.Ubicacion = WebUtility.HtmlEncode(value.Ubicacion);
                agri.PalabraClave = WebUtility.HtmlEncode(value.PalabraClave);
                agri.IdDistribuidor = WebUtility.HtmlEncode(value.IdDistribuidor);
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
        public Automoviles Get(string id)
        {
            //var cachado = cache.Get<Employees> (id);

            //if (cachado != null) {
            //    return cachado;
            //}  

            var context = new refaccionariaContext();

            Automoviles aut = context.Automoviles.Where<Automoviles>(e => e.Id == id).FirstOrDefault<Automoviles>();
            if (aut == null)
            {
                return null;
            }

            //var options = new MemoryCacheEntryOptions {
            //     Priority = CacheItemPriority.Normal,
            //     AbsoluteExpiration = DateTime.Now.AddMinutes (30)
            //};

            //cache.Set<Employees>(employee.EmpNo, employee, options);


            return aut;
        }

        [HttpGet("{PalabraClave}")]
        public Automoviles Get2(string palabra)
        {
            //var cachado = cache.Get<Employees> (id);

            //if (cachado != null) {
            //    return cachado;
            //}  

            var context = new refaccionariaContext();

            Automoviles auto = context.Automoviles.Where<Automoviles>(e => e.PalabraClave == palabra).FirstOrDefault<Automoviles>();
            if (auto == null)
            {
                return null;
            }

            //var options = new MemoryCacheEntryOptions {
            //     Priority = CacheItemPriority.Normal,
            //     AbsoluteExpiration = DateTime.Now.AddMinutes (30)
            //};

            //cache.Set<Employees>(employee.EmpNo, employee, options);


            return auto;
        }


        [HttpPost]
        public IActionResult Post([FromBody] Automoviles value)
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

                context.Automoviles.Add(value);
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
                var auto = context.Automoviles.Where(e => e.Id == id).FirstOrDefault();
                if (auto == null) return;

                context.Automoviles.Remove(auto);
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
