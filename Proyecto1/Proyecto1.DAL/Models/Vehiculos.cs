using System;
using System.Collections.Generic;

namespace Proyecto1.DAL.Models
{
    public partial class Vehiculos
    {
        public Vehiculos()
        {
            Propuestas = new HashSet<Propuestas>();
            Reparaciones = new HashSet<Reparaciones>();
            Ventas = new HashSet<Ventas>();
        }

        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public int ConcesionarioId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Matricula { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Vendido { get; set; }
        public string Combustible { get; set; }
        public int Km { get; set; }

        public virtual Categorias Categoria { get; set; }
        public virtual Concesionarios Concesionario { get; set; }
        public virtual ICollection<Propuestas> Propuestas { get; set; }
        public virtual ICollection<Reparaciones> Reparaciones { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
