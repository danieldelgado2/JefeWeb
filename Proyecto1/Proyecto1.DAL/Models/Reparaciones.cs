using System;
using System.Collections.Generic;

namespace Proyecto1.DAL.Models
{
    public partial class Reparaciones
    {
        public Reparaciones()
        {
            RepuestosReparacion = new HashSet<RepuestosReparacion>();
        }

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int VehiculoId { get; set; }
        public int ClienteId { get; set; }
        public DateTime? Fecha { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }

        public virtual Clientes Cliente { get; set; }
        public virtual Usuarios Usuario { get; set; }
        public virtual Vehiculos Vehiculo { get; set; }
        public virtual ICollection<RepuestosReparacion> RepuestosReparacion { get; set; }
    }
}
