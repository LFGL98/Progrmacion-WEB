using System;
using System.Collections.Generic;

namespace Refaccionaria.Models
{
    public partial class Agricultura
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public string Ubicacion { get; set; }
        public string PalabraClave { get; set; }
        public string IdDistribuidor { get; set; }

        public virtual Distribuidores IdDistribuidorNavigation { get; set; }
    }
}
