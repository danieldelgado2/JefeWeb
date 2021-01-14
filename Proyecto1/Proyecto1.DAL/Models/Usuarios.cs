using System;
using System.Collections.Generic;

namespace Proyecto1.DAL.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            MecanicosCategorias = new HashSet<MecanicosCategorias>();
            Propuestas = new HashSet<Propuestas>();
            Reparaciones = new HashSet<Reparaciones>();
            Ventas = new HashSet<Ventas>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Tipo { get; set; }
        public int ConcesionarioId { get; set; }

        public virtual Concesionarios Concesionario { get; set; }
        public virtual ICollection<MecanicosCategorias> MecanicosCategorias { get; set; }
        public virtual ICollection<Propuestas> Propuestas { get; set; }
        public virtual ICollection<Reparaciones> Reparaciones { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
