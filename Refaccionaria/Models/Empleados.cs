using System;
using System.Collections.Generic;

namespace Refaccionaria.Models
{
    public partial class Empleados
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
