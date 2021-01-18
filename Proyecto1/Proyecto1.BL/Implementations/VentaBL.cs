using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto1.BL.Contracts;
using Proyecto1.Core.DTO;
using Proyecto1.DAL.Models;
using Proyecto1.DAL.Repositories.Contracts;

namespace Proyecto1.BL.Implementations
{
    public class VentaBL : IVentaBL
    {

        public IVentaRepository _ventaRepository { get; set; }
        public IUsuarioRepository _usuarioRepository { get; set; }
        public VentaBL(IVentaRepository ventaRepository, IUsuarioRepository usuarioRepository)
        {
            _ventaRepository = ventaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<VentaDTO> Get()
        {
            var ventas = _ventaRepository.Get();
            var usuarios = _usuarioRepository.Get();
            var ids = new List<int>();
            List<VentaDTO> ventasFinales = new List<VentaDTO>();

            foreach (var v in ventas)
            {
                foreach (var u in usuarios)
                {
                    if (v.Usuario_id == u.Id)
                    {
                        v.Nombre = u.Nombre;
                        v.Email = u.Email;
                        v.Usuario_id = u.Id;
                        v.Apellidos = u.Apellidos;
                        break;
                    }
                }
            }

          
            foreach (var v in ventas)
            {
                if (!ventasFinales.Any(venta => venta.Usuario_id == v.Usuario_id))
                {
                    ventasFinales.Add(v);
                }
                else
                {
                    ventasFinales.FirstOrDefault(venta => venta.Usuario_id == v.Usuario_id).Importe += v.Importe;
                }
            }

            return ventasFinales;
    }   }
}
