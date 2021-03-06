﻿using System;
using System.Collections.Generic;
using Proyecto1.Core.DTO;

namespace Proyecto1.DAL.Repositories.Contracts
{
    public interface IUsuarioRepository
    {
        UsuarioDTO Login(UsuarioDTO usuarioDTO);
        IEnumerable<UsuarioDTO> Get();
    }
}