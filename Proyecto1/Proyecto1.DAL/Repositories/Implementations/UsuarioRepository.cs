using System;
using System.Linq;
using Proyecto1.Core.DTO;
using Proyecto1.DAL.Models;
using Proyecto1.DAL.Repositories.Contracts;

namespace Proyecto1.DAL.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public TallerContext _context { get; set; }

        public UsuarioRepository(TallerContext context)
        {
            _context = context;
        }

        public bool Login(UsuarioDTO usuarioDTO)
        {
            return _context.Usuarios.Any(u => u.Login == usuarioDTO.Username && u.Password == usuarioDTO.Password);
        }

    }
}
