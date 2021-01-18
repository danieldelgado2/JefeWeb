﻿using System;
using System.Collections.Generic;
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
            return ventas;
        }
    }
}