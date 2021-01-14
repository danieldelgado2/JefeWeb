using System;
using System.Collections.Generic;

namespace Proyecto1.DAL.Models
{
    public partial class Repuestos
    {
        public Repuestos()
        {
            RepuestosReparacion = new HashSet<RepuestosReparacion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Referencia { get; set; }
        public int Precio { get; set; }

        public virtual ICollection<RepuestosReparacion> RepuestosReparacion { get; set; }
    }
}
