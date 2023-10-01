using AutoMapper;
using Domain;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class ApplicationToDomain : Profile
    {
        public ApplicationToDomain()
        {

            CreateMap<ProdutoViewModel, Produto>()
               .ConstructUsing(q => new Produto(q.Codigo, q.Nome, q.Descricao, q.Ativo, q.Valor, q.Data, q.Imagem, q.QuantidadeEstoque));

            CreateMap<NovoProdutoViewModel, Produto>()
               .ConstructUsing(q => new Produto(q.Codigo, q.Nome, q.Descricao, q.Ativo, q.Valor, q.Data, q.Imagem, q.QuantidadeEstoque));


            CreateMap<CategoriaViewModel, Categoria>()
               .ConstructUsing(q => new Categoria(q.Codigo, q.Descricao));

            CreateMap<NovaCategoriaViewModel, Categoria>()
              .ConstructUsing(q => new Categoria(q.Codigo, q.Descricao));


            CreateMap<FornecedorViewModel, Fornecedor>()
              .ConstructUsing(q => new Fornecedor(q.Codigo, q.RazaoSocial, q.Cnpj , q.Ativo, q.Data, q.Email));

            CreateMap<NovoFornecedorViewModel, Fornecedor>()
             .ConstructUsing(q => new Fornecedor(q.Codigo, q.RazaoSocial, q.Cnpj, q.Ativo, q.Data, q.Email));
        }
    }
}