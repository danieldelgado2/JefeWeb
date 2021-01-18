using System;
namespace Proyecto1.Core.DTO
{
    public class UsuarioDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Tipo { get; set; }
        public int ConcesionarioId { get; set; }
        public UsuarioDTO()
        {
        }
    }
}
