using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refaccionaria.Models;
namespace Refaccionaria.Helpers
{
    public interface IUserService
    {
        Empleados Authenticate(string username, string password);
        IEnumerable<Empleados> GetAll();
    }
}
