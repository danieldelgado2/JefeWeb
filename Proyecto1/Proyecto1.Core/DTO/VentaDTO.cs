using System;
namespace Proyecto1.Core.DTO
{
    public class VentaDTO
    {
        public int Id { get; set; }
        public int Usuario_id { get; set; }
        public string Email { get; set; }
        public int Importe{ get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public VentaDTO()
        {
        }

    }
}
