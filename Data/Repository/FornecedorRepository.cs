using AutoMapper;
using Data.Providers.MongoDb.Collections;
using Data.Providers.MongoDb.Interfaces;
using Domain;
using Domain.Entities;
using Domain.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {

        private readonly IMongoRepository<FornecedorCollection> _fornecedorRepository;
        private readonly IMapper _mapper;

        public FornecedorRepository(IMongoRepository<FornecedorCollection> fornecedorRepository,
            IMapper mapper
            )
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            var novoFornecedorCollection = _mapper.Map<FornecedorCollection>(fornecedor);
            await _fornecedorRepository.InsertOneAsync(novoFornecedorCollection);
        }

        public Task Atualizar(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }

        public Task<Fornecedor> ObterPorCnpj(string cnpj)
        {
            throw new NotImplementedException();
        }

        public Task<Fornecedor> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Fornecedor>> ObterTodos()
        {
            var listaDeFornecedores = _fornecedorRepository.FilterBy(filtro => true);

            return _mapper.Map<IEnumerable<Fornecedor>>(listaDeFornecedores);

        }

        public Task Remover(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }
    }
}
