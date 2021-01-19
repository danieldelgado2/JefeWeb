using System;
using Microsoft.AspNetCore.Mvc;
using Proyecto1.BL.Contracts;
using Proyecto1.Core.DTO;

namespace Proyecto1.API.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        public IUsuarioBL _usuarioBL { get; set; }

        public LoginController(IUsuarioBL usuarioBL)
        {
            _usuarioBL = usuarioBL;
        }


        [HttpPost]
        public UsuarioDTO Login(UsuarioDTO usuarioDTO)
        {
            return _usuarioBL.Login(usuarioDTO);
        }

        [HttpGet]
        public string Login()
        {
            return "Estas en el login";
        }

    }
}
