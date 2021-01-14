using System;
using System.Collections.Generic;

namespace Proyecto1.DAL.Models
{
    public partial class RepuestosReparacion
    {
        public int Id { get; set; }
        public int RepuestoId { get; set; }
        public int ReparacionId { get; set; }
        public int Cantidad { get; set; }

        public virtual Reparaciones Reparacion { get; set; }
        public virtual Repuestos Repuesto { get; set; }
    }
}
