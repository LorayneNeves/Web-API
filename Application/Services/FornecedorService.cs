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
        private readonly IFornecedorRepository _fornecedorRepository;
        private IMapper _mapper;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }
        public void Adicionar(NovoFornecedorViewModel novoFornecedorViewModel)
        {
            var novoFornecedor = _mapper.Map<Fornecedor>(novoFornecedorViewModel);
            _fornecedorRepository.Adicionar(novoFornecedor);
        }

        public Fornecedor BuscarPorId(int codigo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fornecedor> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fornecedor> BuscarTodosAtivos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fornecedor> BuscarTodosInativos()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FornecedorViewModel>> ObterPorCategoria(int codigo)
        {
            throw new NotImplementedException();
        }

        public Task<FornecedorViewModel> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FornecedorViewModel>> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
