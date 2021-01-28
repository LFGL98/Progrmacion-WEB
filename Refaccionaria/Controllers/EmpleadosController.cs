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
    public class Empleado
    {
        public String id { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Telefono { get; set; }
       
        //public DateTime DepaEmpleado { get; set; }
        //public DateTime DepaManager { get; set; }
    }

    //[Authorize]
    [Route("api/[controller]")]
    //[EnableCors (Startup.MY_CORS)]  
    public class EmpleadosController : Controller
    {
        private const string EMPLOYEES_KEY = "employeeKey";
        private const string EMPLOYEES_LIST = "employeeList";
        private IMemoryCache cache;

        public EmpleadosController(IMemoryCache cache, IDataProtectionProvider provider)
        {
            this.cache = cache;
        }

        [HttpGet]
        public IEnumerable<Empleado> Get()
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
            var empleados = from e in context.Empleados
                                //join s in context.Salaries on e.EmpNo equals s.EmpNo
                                //join t in context.Titles on e.EmpNo equals t.EmpNo
                            orderby e.Id ascending
                            select new Empleado
                            {
                                Nombre = e.Nombre,
                                id = WebUtility.HtmlEncode(e.Id),
                                Apellidos = WebUtility.HtmlEncode(e.Apellidos),
                                Telefono = e.Telefono,
                            };


            //var options = new MemoryCacheEntryOptions {
            //    Priority = CacheItemPriority.High,
            //    AbsoluteExpiration = DateTime.Now.AddMinutes (3)
            //};

            //cache.Set (EMPLOYEES_LIST, employees.ToList (), options);

            return empleados;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Empleados Get(string id)
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

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Empleados value)
        {
            bool error = false;
            string id = WebUtility.HtmlEncode(value.Id);
            string firstName = WebUtility.HtmlEncode(value.Nombre);
            string lastName = WebUtility.HtmlEncode(value.Apellidos);
            string telefono = WebUtility.HtmlEncode(value.Telefono);
            string password = WebUtility.HtmlEncode(value.Password);
            string token = "sdf";
            value.Token = token;
            try
            {
                var context = new refaccionariaContext();

                context.Empleados.Add(value);
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
        public IActionResult Put(string id, [FromBody] Empleados value)
        {
            bool error = false;

            try
            {
                var context = new refaccionariaContext();

                var employee = context.Empleados.Where<Empleados>(e => e.Id == id).FirstOrDefault();
                if (employee == null)
                {
                    return new JsonResult(new { Status = "Fail" });
                }

                employee.Nombre = WebUtility.HtmlEncode(value.Nombre);
                employee.Apellidos = WebUtility.HtmlEncode(value.Apellidos);
                employee.Telefono = WebUtility.HtmlEncode(value.Telefono);
                employee.Password = WebUtility.HtmlEncode(value.Password);

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

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            try
            {
                var context = new refaccionariaContext();
                var employee = context.Empleados.Where(e => e.Id == id).FirstOrDefault();
                if (employee == null) return;

                context.Empleados.Remove(employee);
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
