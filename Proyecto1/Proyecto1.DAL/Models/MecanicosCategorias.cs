using System;
using System.Collections.Generic;

namespace Proyecto1.DAL.Models
{
    public partial class MecanicosCategorias
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public int MecanicoId { get; set; }

        public virtual Categorias Categoria { get; set; }
        public virtual Usuarios Mecanico { get; set; }
    }
}
