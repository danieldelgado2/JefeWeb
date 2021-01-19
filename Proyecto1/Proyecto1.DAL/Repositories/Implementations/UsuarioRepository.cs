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

        
        public UsuarioDTO Login(UsuarioDTO usuarioDTO)
        {
            

            var buscaUsuario = _context.Usuarios.FirstOrDefault(u=>u.Login == usuarioDTO.Login && u.Password == u.Password);

            if (buscaUsuario == null)
            {
                return null;
            }
            var encontrado = new UsuarioDTO
            {
                Login = buscaUsuario.Login,
                Password = buscaUsuario.Password,
                Nombre = buscaUsuario.Nombre,
                Apellidos = buscaUsuario.Apellidos,
                Email = buscaUsuario.Email,
                Tipo = buscaUsuario.Tipo

            };

            return encontrado;
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
                    Id = u.Id,
                    Login = u.Login,
                    Password = u.Password,
                    Nombre = u.Nombre,
                    Apellidos = u.Apellidos,
                    Email = u.Email
                };
                usuariosdto.Add(usuario);
            }

            return usuariosdto;

        }

    }
}