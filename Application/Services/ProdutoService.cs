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
using Infra.EmailService;

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

            Produto p = new Produto(novoProdutoViewModel.Descricao, novoProdutoViewModel.Descricao, novoProdutoViewModel.Ativo, novoProdutoViewModel.Valor, novoProdutoViewModel.DataCadastro, novoProdutoViewModel.Imagem, novoProdutoViewModel.QuantidadeEstoque, novoProdutoViewModel.EstoqueMinimo);

            await _produtoRepository.Adicionar(novoProduto);

        }

        public async Task Atualizar(Guid id, ProdutoViewModel produtoViewModel)
        {


            var buscaProduto = await _produtoRepository.ObterPorId(id);

            if (buscaProduto == null) throw new ApplicationException("Não é possível atualizar um produto que não existe!");

            buscaProduto.AlterarDescricao(produtoViewModel.Descricao);
            buscaProduto.AlterarNome(produtoViewModel.Nome);
            buscaProduto.Ativar();
            buscaProduto.Desativar();
            buscaProduto.AtualizarValor(produtoViewModel.Valor);
            //buscaProduto.AtualizarImagem(produtoViewModel.Imagem);
            buscaProduto.AtualizarEstoque(produtoViewModel.QuantidadeEstoque);

            await _produtoRepository.Atualizar(buscaProduto);
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

        public async Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            var buscaProduto = await _produtoRepository.ObterPorId(id);

            if (buscaProduto == null)
            {
                throw new ApplicationException("Produto não encontrado");
            }

            var produtoViewModel = new ProdutoViewModel
            {
                CodigoId = buscaProduto.CodigoId,
                CategoriaId = buscaProduto.CategoriaID,
                Nome = buscaProduto.Nome,
                Descricao = buscaProduto.Descricao,
                Ativo = buscaProduto.Ativo,
                Valor = buscaProduto.Valor,
                DataCadastro = buscaProduto.DataCadastro,
                QuantidadeEstoque = buscaProduto.QuantidadeEstoque,              
            };

            return produtoViewModel;
        }
        public IEnumerable<ProdutoViewModel> ObterPorNome(string nome)
        {
            var produtos = _produtoRepository.ObterPorNome(nome);

            var produtosViewModel = _mapper.Map<IEnumerable<ProdutoViewModel>>(produtos);

            return produtosViewModel;
        }

        public IEnumerable<ProdutoViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.ObterTodos());
        }

        public async Task Ativar(Guid id)
        {
            var buscaProduto = await _produtoRepository.ObterPorId(id);

            if (buscaProduto == null) throw new ApplicationException("Não é possível ativar um produto que não existe!");

            buscaProduto.Ativar();

            await _produtoRepository.Ativar(buscaProduto);

        }
        public async Task DebitarEstoque(Guid id, int quantidade)
        {
            var buscaProduto = await _produtoRepository.ObterPorId(id);

            if (buscaProduto == null) throw new ApplicationException("Não é possível debitar um produto que não existe!");

            buscaProduto.DebitarEstoque(quantidade);

            await _produtoRepository.DebitarEstoque(buscaProduto);

        }
        public async Task ReporEstoque(Guid id, int quantidade)
        {
            var buscaProduto = await _produtoRepository.ObterPorId(id);

            if (buscaProduto == null) throw new ApplicationException("Não é possível repor um produto que não existe!");

            buscaProduto.ReporEstoque(quantidade);

            await _produtoRepository.ReporEstoque(buscaProduto);

        }

        public async Task AtualizarValor(Guid id, ProdutoViewModel produtoViewModel)
        {
            var buscaProduto = await _produtoRepository.ObterPorId(id);

            if (buscaProduto == null) throw new ApplicationException("Produto não encontrado");

            buscaProduto.AtualizarValor(produtoViewModel.Valor);

            await _produtoRepository.AtualizarValor(buscaProduto);

        }
        public async Task AtualizarEstoque(Guid id, ProdutoViewModel produtoViewModel)
        {
            var buscaProduto = await _produtoRepository.ObterPorId(id);

            if (buscaProduto == null)
                throw new ApplicationException("Produto não encontrado");

            // Atualize o estoque
            buscaProduto.AtualizarEstoque(produtoViewModel.QuantidadeEstoque);

            // Verifique se o estoque está abaixo do mínimo
            if (buscaProduto.EstoqueAbaixoMinimo)
            {
                // Se sim, envie o e-mail
                string assunto = "Estoque abaixo do mínimo";
                string corpoEmailModelo = $"Olá Comprador(a), o produto {buscaProduto.Descricao} está abaixo do estoque mínimo {buscaProduto.EstoqueMinimo} definido no sistema, logo, você precisa avaliar se é necessário realizar um novo pedido de compra.";
                string destinatario = "lorayne3.8neves@gmail.com"; // Substitua pelo e-mail correto do destinatário
                EmailConfig emailConfig = new EmailConfig();
                string corpoEmail = corpoEmailModelo.Replace("{nomeCliente}", buscaProduto.Nome);

                if (!string.IsNullOrEmpty(destinatario))
                {
                    Email.Enviar(assunto, corpoEmail, destinatario, emailConfig);
                }
            }

            // Atualize o produto no repositório
            await _produtoRepository.AtualizarEstoque(buscaProduto);
        }


        #endregion
    }
}