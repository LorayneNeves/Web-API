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

        public FornecedorRepository(IMongoRepository<FornecedorCollection> fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            await _fornecedorRepository.InsertOneAsync(_mapper.Map<FornecedorCollection>(fornecedor));
        }

        public async Task Ativar(Fornecedor fornecedor)
        {
            var buscaFornecedor = _fornecedorRepository.FilterBy(filter => filter.CodigoId == fornecedor.CodigoId);

            if (buscaFornecedor == null) throw new ApplicationException("Não é possível ativar um produto que não existe");

            var fornecedorCollection = _mapper.Map<FornecedorCollection>(fornecedor);

            fornecedorCollection.Id = buscaFornecedor.FirstOrDefault().Id;

            await _fornecedorRepository.ReplaceOneAsync(fornecedorCollection);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            var buscaFornecedor = _fornecedorRepository.FilterBy(filter => filter.CodigoId == fornecedor.CodigoId);


            if (buscaFornecedor == null) { throw new ApplicationException("Produto não encontrado"); }

            var fornecedorCollection = _mapper.Map<FornecedorCollection>(fornecedor);

            fornecedorCollection.Id = buscaFornecedor.FirstOrDefault().Id;
            fornecedorCollection.Nome = fornecedor.Nome;
            fornecedorCollection.Cnpj = fornecedor.Cnpj;
            fornecedorCollection.DataCadastro = fornecedor.DataCadastro;
            fornecedorCollection.Ativo = fornecedor.Ativo;

            await _fornecedorRepository.ReplaceOneAsync(fornecedorCollection);
        }

        public async Task Desativar(Fornecedor fornecedor)
        {
            var buscaFornecedor = _fornecedorRepository.FilterBy(filter => filter.CodigoId == fornecedor.CodigoId);

            if (buscaFornecedor == null) throw new ApplicationException("Não é possível desativar um produto que não existe");

            var fornecedorCollection = _mapper.Map<FornecedorCollection>(fornecedor);

            fornecedorCollection.Id = buscaFornecedor.FirstOrDefault().Id;

            await _fornecedorRepository.ReplaceOneAsync(fornecedorCollection);
        }

        public async Task<Fornecedor> ObterPorCnpj(string cnpj)
        {
            var resultadoBuscaCnpj =  _fornecedorRepository.FilterBy(filtro => filtro.Cnpj == cnpj)
            	.FirstOrDefault();
            return _mapper.Map<Fornecedor>(resultadoBuscaCnpj);
            

        }

        public async Task<Fornecedor> ObterPorId(Guid id)
        {
            var buscaFornecedor = _fornecedorRepository.FilterBy(filter => filter.CodigoId == id);

            var fornecedor = _mapper.Map<Fornecedor>(buscaFornecedor.FirstOrDefault());

            return fornecedor;
        }

        public IEnumerable<Fornecedor> ObterPorNome(string nome)
        {
            var buscaFornecedor = _fornecedorRepository.FilterBy(filter => filter.Nome.Contains(nome));

            if (buscaFornecedor == null || !buscaFornecedor.Any())
            {
                // Se não houver produtos encontrados, você pode retornar uma lista vazia ou lançar uma exceção apropriada.
                // Aqui, estou retornando uma lista vazia como exemplo.
                return new List<Fornecedor>();
            }

            var fornecedoresViewModel = _mapper.Map<IEnumerable<Fornecedor>>(buscaFornecedor);

            return fornecedoresViewModel;
        }


        public Task Remover(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Fornecedor> IFornecedorRepository.ObterTodosF()
        {
            var fornecedorList = _fornecedorRepository.FilterBy(filter => true);

            return _mapper.Map<IEnumerable<Fornecedor>>(fornecedorList);
        }
    }
}
