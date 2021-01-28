using System;
using System.Collections.Generic;

namespace Refaccionaria.Models
{
    public partial class Distribuidores
    {
        public Distribuidores()
        {
            Agricultura = new HashSet<Agricultura>();
            Automoviles = new HashSet<Automoviles>();
            Construccion = new HashSet<Construccion>();
        }

        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Rfc { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Agricultura> Agricultura { get; set; }
        public virtual ICollection<Automoviles> Automoviles { get; set; }
        public virtual ICollection<Construccion> Construccion { get; set; }
    }
}
