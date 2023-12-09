﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Autenticar(string login, string senha);
        // public Task Cadastrar(Usuario usuario);
    }
}
