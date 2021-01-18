using System;
using System.Collections.Generic;
using Proyecto1.BL.Contracts;
using Proyecto1.Core.DTO;
using Proyecto1.DAL.Repositories.Contracts;

namespace Proyecto1.BL.Implementations
{
    public class UsuarioBL : IUsuarioBL
    {
        public IUsuarioRepository _usuarioRepository;
        public UsuarioBL(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool Login(UsuarioDTO usuarioDTO)
        {
            return usuarioDTO.Login == "ventas" && usuarioDTO.Password == "1234";
        }

          public IEnumerable<UsuarioDTO> Get()
        {
            return _usuarioRepository.Get();
        }
    }
}
