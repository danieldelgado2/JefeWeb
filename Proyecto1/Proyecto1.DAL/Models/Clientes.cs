using System;
using System.Collections.Generic;

namespace Proyecto1.DAL.Models
{
    public partial class Clientes
    {
        public Clientes()
        {
            Propuestas = new HashSet<Propuestas>();
            Reparaciones = new HashSet<Reparaciones>();
            Ventas = new HashSet<Ventas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Propuestas> Propuestas { get; set; }
        public virtual ICollection<Reparaciones> Reparaciones { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
