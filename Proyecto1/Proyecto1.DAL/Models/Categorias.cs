using System;
using System.Collections.Generic;

namespace Proyecto1.DAL.Models
{
    public partial class Categorias
    {
        public Categorias()
        {
            MecanicosCategorias = new HashSet<MecanicosCategorias>();
            Vehiculos = new HashSet<Vehiculos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<MecanicosCategorias> MecanicosCategorias { get; set; }
        public virtual ICollection<Vehiculos> Vehiculos { get; set; }
    }
}
