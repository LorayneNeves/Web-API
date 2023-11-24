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
               .ConstructUsing(q => new Produto(q.Nome, q.Descricao, q.Ativo, q.Valor, q.DataCadastro, q.Imagem, q.QuantidadeEstoque));

            CreateMap<NovoProdutoViewModel, Produto>()
               .ConstructUsing(q => new Produto(q.Nome, q.Descricao, q.Ativo, q.Valor, q.DataCadastro, q.Imagem, q.QuantidadeEstoque));

            CreateMap<CategoriaViewModel, Categoria>()
               .ConstructUsing(q => new Categoria(q.Descricao, q.Ativo));

            CreateMap<NovaCategoriaViewModel, Categoria>()
               .ConstructUsing(q => new Categoria(q.Descricao, q.Ativo));

            CreateMap<FornecedorViewModel, Fornecedor>()
               .ConstructUsing(q => new Fornecedor(q.Nome, q.Cnpj, q.RazaoSocial, q.DataCadastro, q.Ativo));

            CreateMap<NovoFornecedorViewModel, Fornecedor>()
               .ConstructUsing(q => new Fornecedor(q.Nome, q.Cnpj, q.RazaoSocial, q.DataCadastro, q.Ativo));

        }
    }
}