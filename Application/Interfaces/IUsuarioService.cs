using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<string> Autenticar(AutenticarUsuarioViewModel autenticarUsuarioViewModel);
        //Task Cadastrar(UsuarioViewModel usuario);
    }
}
