using Proyecto1.Core.DTO;
using System.Collections.Generic;

namespace Proyecto1.BL.Contracts
{
    public interface IUsuarioBL
    {
        UsuarioDTO Login(UsuarioDTO usuarioDTO);
        IEnumerable<UsuarioDTO> Get();
    }
}
