using System;
using System.Collections.Generic;

namespace Proyecto1.DAL.Models
{
    public partial class Concesionarios
    {
        public Concesionarios()
        {
            Usuarios = new HashSet<Usuarios>();
            Vehiculos = new HashSet<Vehiculos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
        public virtual ICollection<Vehiculos> Vehiculos { get; set; }
    }
}
