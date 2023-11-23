using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain;
using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FornecedorService : IFornecedorService
    {
        #region - Construtores
        private readonly IFornecedorRepository _fornecedorRepository;
        private IMapper _mapper;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }
        #endregion

        #region - Funções
        public async Task Adicionar(NovoFornecedorViewModel fornecedorViewModel)
        {
            var novoFornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);

            Fornecedor f = new Fornecedor(fornecedorViewModel.Nome, fornecedorViewModel.Cnpj, fornecedorViewModel.RazaoSocial, fornecedorViewModel.DataCadastro, fornecedorViewModel.Ativo);

            await _fornecedorRepository.Adicionar(novoFornecedor);
        }

        public async Task Ativar(Guid id)
        {
            var buscaFornecedor = await _fornecedorRepository.ObterPorId(id);

            if (buscaFornecedor == null) throw new ApplicationException("Não é possível ativar um produto que não existe!");

            buscaFornecedor.Ativar();

            await _fornecedorRepository.Ativar(buscaFornecedor);
        }

        public async Task Atualizar(Guid id, FornecedorViewModel fornecedor)
        {
            var buscaFornecedor = await _fornecedorRepository.ObterPorId(id);

            if (buscaFornecedor == null) throw new ApplicationException("Não é possível atualizar um produto que não existe!");

            buscaFornecedor.AlterarCNPJ(fornecedor.Cnpj);
            buscaFornecedor.AlterarNome(fornecedor.Nome);
            buscaFornecedor.AlterarRazaoSocial(fornecedor.RazaoSocial);
            buscaFornecedor.Ativar();
            buscaFornecedor.Desativar();


            await _fornecedorRepository.Atualizar(buscaFornecedor);
        }

        public async Task Desativar(Guid id)
        {
            var buscaFornecedor = await _fornecedorRepository.ObterPorId(id);

            if (buscaFornecedor == null) throw new ApplicationException("Não é possível desativar um produto que não existe!");

            buscaFornecedor.Desativar();

            await _fornecedorRepository.Desativar(buscaFornecedor);
        }

        public async Task<FornecedorViewModel> ObterPorId(Guid id)
        {
            var buscaFornecedor = await _fornecedorRepository.ObterPorId(id);

            if (buscaFornecedor == null)
            {
                throw new ApplicationException("Produto não encontrado");
            }

            var fornecedorViewModel = new FornecedorViewModel
            {
                CodigoId = buscaFornecedor.CodigoId,
                Cnpj = buscaFornecedor.Cnpj,
                Nome = buscaFornecedor.Nome,
                RazaoSocial = buscaFornecedor.RazaoSocial,
                Ativo = buscaFornecedor.Ativo,
                DataCadastro = buscaFornecedor.DataCadastro,
            };
            return fornecedorViewModel;
        }

        public IEnumerable<FornecedorViewModel> ObterPorNome(string nome)
        {
            var fornecedores = _fornecedorRepository.ObterPorNome(nome);

            var fornecedoreViewModel = _mapper.Map<IEnumerable<FornecedorViewModel>>(fornecedores);

            return fornecedoreViewModel;
        }

        public IEnumerable<FornecedorViewModel> ObterTodosF()
        {
            return _mapper.Map<IEnumerable<FornecedorViewModel>>(_fornecedorRepository.ObterTodosF());
        }
        #endregion
    }
}
