using System;
using Proyecto1.BL.Contracts;
using Proyecto1.Core.DTO;

namespace Proyecto1.BL.Implementations
{
    public class UsuarioBL : IUsuarioBL
    {
        public UsuarioBL()
        {
        }

        public bool Login(UsuarioDTO usuarioDTO)
        {
            return usuarioDTO.Login == "ventas" && usuarioDTO.Password == "1234";
        }
    }
}
