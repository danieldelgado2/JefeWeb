using System;
using Proyecto1.BL.Contracts;
using Proyecto1.Core.DTO;
using Proyecto1.DAL.Repositories.Contracts;

namespace Proyecto1.BL.Implementations
{
    public class UsuarioBL : IUsuarioBL
    {
        public IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioBL(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool Login(UsuarioDTO usuarioDTO)
        {
            return _usuarioRepository.Login(usuarioDTO);
        }
    }
}
