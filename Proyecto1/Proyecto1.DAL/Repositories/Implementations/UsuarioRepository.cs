using System;
using System.Collections.Generic;
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
            return _context.Usuarios.Any(u => u.Login == usuarioDTO.Login && u.Password == usuarioDTO.Password);
        }

        public IEnumerable<UsuarioDTO> Get()
        {
            var usuarios = _context.Usuarios.ToList();

            //Mapeo de Usuario a UsuarioDTO
            List<UsuarioDTO> usuariosdto = new List<UsuarioDTO>();

            foreach (var u in usuarios)
            {
                var usuario = new UsuarioDTO
                {
                    Login = u.Login,
                    Password = u.Password
                   /* Name = u.Name,
                    Apellidos = u.Apellidos,
                    Email = u.Email,
                    Tipo = u.Rol*/
                };
                usuariosdto.Add(usuario);
            }

            return usuariosdto;

        }

    }
}
