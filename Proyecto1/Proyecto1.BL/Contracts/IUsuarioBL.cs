using Proyecto1.Core.DTO;

namespace Proyecto1.BL.Contracts
{
    public interface IUsuarioBL
    {
        bool Login(UsuarioDTO usuarioDTO);
    }
}
