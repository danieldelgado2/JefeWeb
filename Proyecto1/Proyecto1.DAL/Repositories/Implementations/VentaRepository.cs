using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto1.Core.DTO;
using Proyecto1.DAL.Models;
using Proyecto1.DAL.Repositories.Contracts;

namespace Proyecto1.DAL.Repositories.Implementations
{
    public class VentaRepository : IVentaRepository
    {
        public TallerContext _context { get; set; }

        public VentaRepository(TallerContext context)
        {
            _context = context;
        }

        public IEnumerable<VentaDTO> Get()
        {
            var ventas = _context.Ventas.ToList();

            //Mapeo de Usuario a UsuarioDTO
            List<VentaDTO> ventasdto = new List<VentaDTO>();

            foreach (var v in ventas)
            {
                var venta = new VentaDTO
                {
                    usuario_id = v.UsuarioId,
                    importe = v.Importe
                };
                ventasdto.Add(venta);
            }

            return ventasdto;

        }
    }
}
