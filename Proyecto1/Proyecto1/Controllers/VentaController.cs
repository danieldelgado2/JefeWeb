using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Proyecto1.BL.Contracts;
using Proyecto1.Core.DTO;
using Proyecto1.DAL.Models;

namespace Proyecto1.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {
        public IVentaBL _ventaBL { get; set; }

        public VentaController(IVentaBL venta)
        {
            _ventaBL = venta;
        }

        [HttpPost]
        public IEnumerable<VentaDTO> Get()
        {
            return _ventaBL.Get();
        }
    }
}
