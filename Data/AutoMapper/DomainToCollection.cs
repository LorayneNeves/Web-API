using AutoMapper;
using Data.Providers.MongoDb.Collections;
using Domain.Entities;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AutoMapper
{
    public class DomainToCollection : Profile
    {
        public DomainToCollection()
        {
            CreateMap<Produto, ProdutoCollection>();
            CreateMap<Categoria, CategoriaCollection>();
            CreateMap<Fornecedor, FornecedorCollection>();
            CreateMap<Usuario, UsuarioCollection>();
        }
    }
}
