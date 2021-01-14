using System;
using System.Collections.Generic;

namespace Proyecto1.DAL.Models
{
    public partial class Ventas
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public int VehiculoId { get; set; }
        public DateTime? Fecha { get; set; }
        public int Importe { get; set; }
        public DateTime? FechaLimite { get; set; }

        public virtual Clientes Cliente { get; set; }
        public virtual Usuarios Usuario { get; set; }
        public virtual Vehiculos Vehiculo { get; set; }
    }
}
