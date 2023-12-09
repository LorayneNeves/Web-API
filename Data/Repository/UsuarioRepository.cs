using AutoMapper;
using Data.Providers.MongoDb.Collections;
using Data.Providers.MongoDb.Interfaces;
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GestaoProdutoContext _context;

        public UsuarioRepository(GestaoProdutoContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Autenticar(string login, string senha)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(filtro => filtro.Login == login && filtro.Senha == senha);
        }

        
    }

}
