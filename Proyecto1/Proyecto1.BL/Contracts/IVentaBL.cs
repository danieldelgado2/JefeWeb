using Proyecto1.Core.DTO;
using Proyecto1.DAL.Models;
using System.Collections.Generic;

namespace Proyecto1.BL.Contracts
{
    public interface IVentaBL
    {        
    IEnumerable<VentaDTO> Get();
    }
}
