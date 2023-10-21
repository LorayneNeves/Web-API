using Application.Interfaces;
using AutoMapper;
using Domain.Interface;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.Services
{
    public class ProdutoService : IProdutoService
    {
        #region - Construtores
        private readonly IProdutoRepository _produtoRepository;
        private IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }
        #endregion

        #region - Funções
        public async Task Adicionar(NovoProdutoViewModel novoProdutoViewModel)
        {
            var novoProduto = _mapper.Map<Produto>(novoProdutoViewModel);

            Produto p = new Produto(novoProdutoViewModel.Descricao, novoProdutoViewModel.Descricao, novoProdutoViewModel.Ativo, novoProdutoViewModel.Valor, novoProdutoViewModel.DataCadastro, novoProdutoViewModel.Imagem, novoProdutoViewModel.QuantidadeEstoque);

            await _produtoRepository.Adicionar(novoProduto);

        }

        public void Atualizar(ProdutoViewModel produto)
        {
            throw new NotImplementedException();
        }

        public async Task Desativar(Guid id)
        {
            var buscaProduto = await _produtoRepository.ObterPorId(id);

            if (buscaProduto == null) throw new ApplicationException("Não é possível desativar um produto que não existe!");

            buscaProduto.Desativar();

            await _produtoRepository.Desativar(buscaProduto);

        }

        public Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdutoViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.ObterTodos());
        }
        #endregion
    }
}