using System;
namespace Proyecto1.Core.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email{ get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Tipo { get; set; }
        public int ConcesionarioId { get; set; }
        public UsuarioDTO()
        {
        }
    }
}
